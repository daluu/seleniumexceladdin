// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using mshtml;
using SHDocVw;

namespace SeleniumExcelAddIn.Recorder
{
    public class CommandRecorder
    {
        private readonly object syncObj = new object();
        private readonly SynchronizedCollection<InternetExplorer> browserList = new SynchronizedCollection<InternetExplorer>();
        private readonly string remarkGuid = Guid.NewGuid().ToString("N");
        private const string RemarkAttr = "data-selenium-excel-addin";
        private RecordingForm form;

        public event EventHandler Started;
        public event EventHandler Stopped;
        public event EventHandler<CommandRecorderEventArgs> CommandRecording;

        public bool IsRecording
        {
            get;
            private set;
        }

         public void Start()
        {
            if (true == this.IsRecording)
            {
                throw new InvalidOperationException();
            }

            if (0 == IE.Count)
            {
                InternetExplorer ie = IE.NewBrowser(IE.AboutBlankSchema);
                IE.WindowMaximize(ie);
                ie.GoHome();
            }

            if (null == this.form)
            {
                this.form = new RecordingForm()
                {
                    Recorder = this,
                };
            }

            IE.WaitForReadyStateComplete();
            IE.Activate();
            form.Show();
            this.IsRecording = true;
            this.AttachBrowser();
            this.OnStarted();

            Uri url = new Uri(IE.ActiveBrowser.LocationURL);
            UriBuilder ub = new UriBuilder();
            ub.Scheme = url.Scheme;
            ub.Host = url.Host;
            ub.Port = url.Port;

//            this.OnCommandRecording("setBaseUrl", ub.ToString());
            this.OnCommandRecording("open", url.PathAndQuery);
        }

        public void Stop()
        {
            if (false == this.IsRecording)
            {
                throw new InvalidOperationException();
            }

            if (null != this.form)
            {
                this.form.Hide();
            }

            this.IsRecording = false;
            this.DetachBrowser();
            this.OnStopped();
        }

        public void OnCommandRecording(string command, string target = "", string value = "")
        {
            Log.Logger.DebugFormat("command = {0}, {1}, {2}", command, target, value);

            if (false == this.IsRecording)
            {
                return;
            }

            if (null == this.CommandRecording)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentNullException("command");
            }

            SynchronizationDispatcher.Invoke(() =>
            {
                this.CommandRecording(this, new CommandRecorderEventArgs(command, target, value));
            });
        }

        private void AttachBrowser()
        {
            lock (this.syncObj)
            {
                foreach (InternetExplorer ie in IE.FindAll())
                {
                    if (this.browserList.Contains(ie))
                    {
                        continue;
                    }

                    this.AttachWindow(((IHTMLDocument2)ie.Document).parentWindow);

                    ie.DocumentComplete += delegate(object disp, ref object url)
                    {
                        if (false == this.IsRecording)
                        {
                            return;
                        }

                        IHTMLDocument2 doc = ie.Document;
                        Uri u = new Uri(doc.url);

                        SynchronizationDispatcher.Invoke(() =>
                        {
                            do
                            {
                                Thread.Sleep(500);
                            }
                            while (!IE.IsReadyStateComplete(ie));

                            //this.OnCommandRecording("assertTitle", doc.title);
                            //this.OnCommandRecording("assertLocation", u.AbsolutePath);
                            this.AttachWindow(((IHTMLDocument2)ie.Document).parentWindow);
                        });
                    };
                }
            }
        }

        private void DetachBrowser()
        {
            IE.Element.Event.DetachAll();
        }

        private void AttachWindow(IHTMLWindow2 win)
        {
            if (false == this.IsRecording)
            {
                return;
            }

            if (true == this.IsRemarked(win))
            {
                return;
            }

            Debug.Print("Recorder.AttachWindow = {0}", win.location.href);

            this.SetRemark(win);

#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif

            IHTMLDocument2 doc = win.document;

            this.AttachInputElements(doc);
            this.AttachAnchorElements(doc);
            this.AttachTextAreaElements(doc);
            this.AttachSelectElements(doc);
            this.AttachLabelElements(doc);
            this.AttachButtonElements(doc);

            if (null == win.frames)
            {
                return;
            }

            for (int i = 0; i < win.frames.length; i++)
            {
                IHTMLFrameBase2 frame = win.frames.item(i) as IHTMLFrameBase2;

                if (null == frame)
                {
                    continue;
                }

                this.AttachWindow(frame.contentWindow);
            }

#if DEBUG
            sw.Stop();
            Debug.Print("{0}", sw.Elapsed);
#endif
        }

        private bool IsRemarked(IHTMLWindow2 win)
        {
            IHTMLElement html = ((IHTMLDocument3)win.document).documentElement;

            return this.remarkGuid == IE.Element.GetAttribute(html, RemarkAttr);
        }

        private void SetRemark(IHTMLWindow2 win)
        {
            IHTMLElement html = ((IHTMLDocument3)win.document).documentElement;
            IE.Element.SetAttribute(html, RemarkAttr, this.remarkGuid);
#if DEBUG
            Debug.Assert(this.remarkGuid == IE.Element.GetAttribute(html, RemarkAttr), "remark error");
#endif
        }

        #region Input Elements

        private void AttachInputElements(IHTMLDocument2 doc)
        {
            IHTMLElementCollection elementCollection = ((IHTMLDocument3)doc).getElementsByTagName("input");

            foreach (IHTMLElement element in elementCollection)
            {
                string type = IE.Element.GetAttribute(element, "type").ToLower();

                switch (type)
                {
                    case "text":
                    case "password":
                        IE.Element.Event.Attach(element, "blur", this.DoInputBlur);
                        break;

                    case "radio":
                    case "checkbox":
                        IE.Element.Event.Attach(element, "click", this.DoInputCheckboxOrRadioClick);
                        break;

                    default:
                        IE.Element.Event.Attach(element, "click", this.DoInputButtonClick);
                        break;
                }
            }
        }

        private void DoInputBlur(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            IHTMLInputElement input = element as IHTMLInputElement;

            string locator = LocateDetector.Detect(element);
            string value = IE.Element.GetValue(element);

            this.OnCommandRecording("sendkeys", locator, value);
        }

        private void DoInputCheckboxOrRadioClick(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            string locator = LocateDetector.Detect(element);

            if (IE.Element.IsChekced(element))
            {
                this.OnCommandRecording("check", locator);
            }
            else
            {
                this.OnCommandRecording("uncheck", locator);
            }
        }

        private void DoInputButtonClick(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            IHTMLInputElement input = element as IHTMLInputElement;
            string locator = LocateDetector.Detect(element);
            string value = IE.Element.GetValue(element);

            this.OnCommandRecording("click", locator);
        }

        #endregion

        #region Anchor Elements

        private void AttachAnchorElements(IHTMLDocument2 doc)
        {
            IHTMLElementCollection elementCollection = ((IHTMLDocument3)doc).getElementsByTagName("a");

            foreach (IHTMLElement element in elementCollection)
            {
                IE.Element.Event.Attach(element, "click", this.DoAnchorClick);
            }
        }

        private void DoAnchorClick(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            string locator = LocateDetector.Detect(element);

            this.OnCommandRecording("click", locator);
        }

        #endregion

        #region TextArea Elements

        private void AttachTextAreaElements(IHTMLDocument2 doc)
        {
            IHTMLElementCollection elementCollection = ((IHTMLDocument3)doc).getElementsByTagName("textarea");

            foreach (IHTMLElement element in elementCollection)
            {
                IE.Element.Event.Attach(element, "blur", this.DoTextAreaBlur);
            }
        }

        private void DoTextAreaBlur(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            string locator = LocateDetector.Detect(element);
            string value = ((IHTMLTextAreaElement)element).value;

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Trim();
            }

            this.OnCommandRecording("sendkeys", locator, value);
        }

        #endregion

        #region Select Elements

        private void AttachSelectElements(IHTMLDocument2 doc)
        {
            IHTMLElementCollection elementCollection = ((IHTMLDocument3)doc).getElementsByTagName("select");

            foreach (IHTMLElement element in elementCollection)
            {
                IE.Element.Event.Attach(element, "change", this.DoSelectChange);
            }
        }

        private void DoSelectChange(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            string locator = LocateDetector.Detect(element);

            IHTMLSelectElement select = element as IHTMLSelectElement;
            IHTMLOptionElement option = IE.Element.GetOption(select, string.Format("index={0}", select.selectedIndex));

            if (null == option)
            {
                return;
            }

            this.OnCommandRecording("select", locator, "label=" + option.text);
        }

        #endregion

        #region Label Elements

        private void AttachLabelElements(IHTMLDocument2 doc)
        {
            IHTMLElementCollection elementCollection = ((IHTMLDocument3)doc).getElementsByTagName("label");

            foreach (IHTMLElement element in elementCollection)
            {
                IE.Element.Event.Attach(element, "click", this.DoLabelClick);
            }
        }

        private void DoLabelClick(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            string locator = LocateDetector.Detect(element);
            string b = IE.Element.IsChekced(element).ToString().ToLower();

            this.OnCommandRecording("click", locator, b);
        }

        #endregion

        #region Button Elements

        private void AttachButtonElements(IHTMLDocument2 doc)
        {
            IHTMLElementCollection elementCollection = ((IHTMLDocument3)doc).getElementsByTagName("button");

            foreach (IHTMLElement element in elementCollection)
            {
                IE.Element.Event.Attach(element, "click", this.DoButtonClick);
            }
        }

        private void DoButtonClick(object sender, IHTMLEventObj evt)
        {
            IHTMLElement element = evt.srcElement;
            IHTMLButtonElement input = element as IHTMLButtonElement;
            string locator = LocateDetector.Detect(element);
            string value = IE.Element.GetValue(element);

            this.OnCommandRecording("click", locator);
        }

        #endregion

        private IHTMLLabelElement GetLabel(IHTMLElement element)
        {
            string id = element.id;

            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            IHTMLElementCollection elements = ((IHTMLDocument3)element.document).getElementsByTagName("label");

            for (int i = 0; i < elements.length; i++)
            {
                IHTMLLabelElement label = elements.item(Type.Missing, i);

                if (!string.IsNullOrWhiteSpace(label.htmlFor))
                {
                    if (label.htmlFor == id)
                    {
                        return label;
                    }
                }
            }

            return null;
        }

        private bool ParentIsNotLabel(IHTMLElement element)
        {
            return !(element.parentElement is IHTMLLabelElement);
        }

        private void OnStarted()
        {
            if (null == this.Started)
            {
                return;
            }

            this.Started(this, EventArgs.Empty);
        }

        private void OnStopped()
        {
            if (null == this.Stopped)
            {
                return;
            }

            this.Stopped(this, EventArgs.Empty);
        }
    }
}
