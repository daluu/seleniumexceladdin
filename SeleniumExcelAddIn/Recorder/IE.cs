// Copyright (c) 2012 Takashi Yoshizawa 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using Accessibility;
using Microsoft.Win32;
using mshtml;
using SHDocVw;

namespace SeleniumExcelAddIn.Recorder
{

    /// <summary>
    /// Internet Explorer Automation Class
    /// </summary>
    internal static class IE
    {
        public const string AboutBlankSchema = "about:blank";

        private const int SleepTime = 1000;
        private const int GetActiveWindowRetryLimit = 10;
        private const int NavigateOk = 0;

        private const string InternetExplorerExeFile = "iexplore.exe";
        private const string InternetExplorerProcessName = "iexplore";
        private const string DialogWindowClassName32770 = "#32770";
        private const string IEFrameWindowClassName = "IEFrame";

        private const string ScrollLeftPropertyName = "scrollLeft";
        private const string ScrollTopPropertyName = "scrollTop";
        private const string ScrollWidthPropertyName = "scrollWidth";
        private const string ScrollHeightPropertyName = "scrollHeight";
        private const string ClientWidthPropertyName = "clientWidth";
        private const string ClientHeightPropertyName = "clientHeight";

        private static string fullVersion = string.Empty;
        private static int majorVersion = 0;
        private static int timeoutSeconds = 60;
        private static Guid guidTopLevelBrowser = new Guid(0x4C96BE40, 0x915C, 0x11CF, 0x99, 0xD3, 0x00, 0xAA, 0x00, 0x4A, 0xE8, 0x37);
        private static Guid guidWebBrowserApp = new Guid(0x0002DF05, 0x0000, 0x0000, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46);
        private static Guid guidIHTMLDocument = new Guid("626FC520-A41E-11CF-A731-00A0C9082637");
        private static string scriptErrorLogDirectory = string.Empty;

        /// <summary>
        /// wait delegate
        /// </summary>
        /// <returns>result of condition</returns>
        public delegate bool WaitCondition();

        [ComImport, Guid("6d5140c1-7436-11ce-8034-00aa006009fa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            uint QueryService(
                ref Guid guidService,
                ref Guid riid,
                [MarshalAs(UnmanagedType.Interface)]out object ppvObject);
        }

        [TypeLibType(4160)]
        [Guid("30510417-98B5-11CF-BB82-00AA00BDCE0B")]
        private interface IHTMLDocument6
        {
            [DispId(1103)]
            IHTMLDocumentCompatibleInfoCollection compatible { get; }
            [DispId(1104)]
            dynamic documentMode { get; }
            [DispId(-2147412012)]
            dynamic onstorage { get; set; }
            [DispId(-2147412011)]
            dynamic onstoragecommit { get; set; }

            [DispId(1107)]
            IHTMLElement2 getElementById(string bstrId);
            [DispId(1109)]
            void updateSettings();
        }

        private interface IHTMLDocumentCompatibleInfoCollection
        {
            [DispId(1001)]
            int length { get; }

            [DispId(0)]
            IHTMLDocumentCompatibleInfo item(int index);
        }

        private interface IHTMLDocumentCompatibleInfo
        {
            [DispId(1001)]
            string userAgent { get; }

            [DispId(1002)]
            string version { get; }
        }

        public static string ScriptErrorLogDirectory
        {
            get
            {
                return scriptErrorLogDirectory;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (!Directory.Exists(value))
                    {
                        throw new DirectoryNotFoundException(value);
                    }
                }

                scriptErrorLogDirectory = value;
            }
        }

        public static int Count
        {
            get
            {
                return GetIEServerAll().Count();
            }
        }

        public static string FullVersion
        {
            get
            {
                if (string.IsNullOrWhiteSpace(fullVersion))
                {
                    using (RegistryKey reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer", RegistryKeyPermissionCheck.ReadSubTree))
                    {
                        fullVersion = (string)reg.GetValue("Version", null);
                        reg.Close();
                    }
                }

                return fullVersion;
            }
        }

        /// <summary>
        /// Gets major version number of Internet Explorer
        /// </summary>
        public static int MajorVersion
        {
            get
            {
                if (0 == majorVersion)
                {
                    majorVersion = Convert.ToInt32(FullVersion.Split('.').First());
                }

                return majorVersion;
            }
        }

        /// <summary>
        /// Gets error code of last navigate
        /// </summary>
        public static int LastNavigateErrorCode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets error url of last nagivate
        /// </summary>
        public static string LastNavigateErrorURL
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets error frame of last navigate
        /// </summary>
        public static string LastNavigateErrorFrame
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets timeout seconds
        /// </summary>
        public static int TimeoutSeconds
        {
            get
            {
                return timeoutSeconds;
            }

            set
            {
                timeoutSeconds = value;
            }
        }

        /// <summary>
        /// Gets or sets active document
        /// </summary>
        public static IHTMLDocument2 ActiveDocument
        {
            get
            {
                return GetActiveDocument(GetActiveBrowserIfThrow().Document as IHTMLDocument2);
            }

            set
            {
                SetActiveDocument(value);
            }
        }

        /// <summary>
        /// Gets or sets active window
        /// </summary>
        public static InternetExplorer ActiveBrowser
        {
            get
            {
                return GetActiveBrowser();
            }

            set
            {
                SetActiveBrowser(value);
            }
        }

        public static void SendKeys(string keys)
        {
            if (string.IsNullOrWhiteSpace(keys))
            {
                return;
            }

            Activate();
            System.Windows.Forms.SendKeys.SendWait(keys);
        }

        /// <summary>
        /// bring to front
        /// </summary>
        public static void Activate()
        {
            SetActiveBrowser(GetActiveBrowserIfThrow());
        }

        /// <summary>
        /// get active document
        /// </summary>
        /// <param name="doc">target html document</param>
        /// <returns>html document</returns>
        public static IHTMLDocument2 GetActiveDocument(IHTMLDocument2 doc)
        {
            if (null == doc)
            {
                return null;
            }

            IHTMLFrameBase2 frame = doc.activeElement as IHTMLFrameBase2;

            if (null == frame)
            {
                return doc;
            }

            return GetActiveDocument(frame.contentWindow.document);
        }

        /// <summary>
        /// Set active document
        /// </summary>
        /// <param name="doc">html document</param>
        public static void SetActiveDocument(IHTMLDocument2 doc)
        {
            if (null == doc)
            {
                throw new ArgumentNullException("IHTMLDocument2");
            }

            doc.parentWindow.focus();
        }

        /// <summary>
        /// Set window size
        /// </summary>
        /// <param name="width">window outer width</param>
        /// <param name="height">window outer height</param>
        public static void SetWindowSize(int width, int height)
        {
            SetWindowSize(GetActiveBrowserIfThrow(), width, height);
        }

        /// <summary>
        /// Set window size
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        /// <param name="width">window outer width</param>
        /// <param name="height">window outer height</param>
        public static void SetWindowSize(InternetExplorer ie, int width, int height)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            if (width < 1)
            {
                throw new ArgumentOutOfRangeException("width");
            }

            if (height < 1)
            {
                throw new ArgumentOutOfRangeException("height");
            }

            AutomationElement ae = AutomationElement.FromHandle((IntPtr)ie.HWND);
            AE.Resize(ae, width, height);
        }

        public static void WindowMaximize(InternetExplorer ie)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("ie");
            }

            WIN32API.ShowWindowAsync((IntPtr)ie.HWND, WIN32API.SW_SHOWMAXIMIZED);
        }

        public static void Close()
        {
            int countBeforeClose = Count;

            if (0 == countBeforeClose)
            {
                return;
            }

            InternetExplorer ie = IE.ActiveBrowser;

            if (null != ie)
            {
                ie.Quit();
            }

            Wait(delegate()
            {
                return Count <= countBeforeClose;
            });
        }

        /// <summary>
        /// Close All Internet Explorer
        /// </summary>
        public static void CloseAll()
        {
            foreach (AutomationElement ieFrameAutomation in GetIEFrameAutomationAll())
            {
                AE.Close(ieFrameAutomation);
            }

            // wait for all closed.
            Wait(delegate()
            {
                return 0 == GetIEFrameAutomationAll().Count;
            });
        }

        /// <summary>
        /// open new window
        /// </summary>
        /// <param name="url">URL to navigate</param>
        /// <param name="commandLineParameter">command line parameter</param>
        /// <returns>InternetExplorer object</returns>
        public static InternetExplorer NewBrowser(string url, string commandLineParameter = "")
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }

            int countBeforeNew = GetIEFrameAutomationAll().Count;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = InternetExplorerExeFile;
                process.StartInfo.Arguments = string.Format("{0} {1}", AboutBlankSchema, commandLineParameter);
                process.Start();
                process.WaitForInputIdle(TimeoutSeconds * 1000);
            }

            // wait for new instance created.
            Wait(delegate()
            {
                return countBeforeNew < GetIEFrameAutomationAll().Count;
            });

            InternetExplorer ie = GetActiveBrowserIfThrow();
            Navigate(ie, url);

            return ie;
        }

        /// <summary>
        /// open new Tab on active Internet Explorer. if no such Internet Explorer then create new Internet Explorer instance.
        /// </summary>
        /// <param name="url">URL to navigate</param>
        /// <returns>InternetExplorer object</returns>
        public static InternetExplorer NewTab(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }

            InternetExplorer ie = GetActiveBrowser();

            if (null == ie)
            {
                return NewBrowser(url);
            }

            return NewTab(ie, url);
        }

        /// <summary>
        /// open new Tab
        /// </summary>
        /// <param name="ie">target InternetExplorer object</param>
        /// <param name="url">URL to navigate</param>
        /// <returns>InternetExplorer object</returns>
        public static InternetExplorer NewTab(InternetExplorer ie, string url)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }

            int countBeforeNew = IE.Count;

            // navOpenInNewTab
            // don't work "navOpenNewForegroundTab"
            object flags = 0x0800;
            ie.Navigate2(AboutBlankSchema, ref flags);

            // wait for new instance created.
            Wait(delegate()
            {
                return countBeforeNew < IE.Count;
            });

            // activate IE
            InternetExplorer tab = GetActiveBrowser();
            SetActiveBrowser(tab);
            Navigate(tab, url);

            return tab;
        }

        /// <summary>
        /// navigate to URL with active Internet Explorer
        /// </summary>
        /// <param name="url">URL to navigate</param>
        public static void Navigate(string url)
        {
            if (string.IsNullOrWhiteSpace("url"))
            {
                throw new ArgumentNullException("url");
            }

            InternetExplorer ie = GetActiveBrowser();

            if (null == ie)
            {
                ie = NewBrowser(url);
            }
            else
            {
                Navigate(ie, url);
            }
        }

        /// <summary>
        /// go to url
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        /// <param name="url">url to navigate</param>
        public static void Navigate(InternetExplorer ie, string url)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }

            LastNavigateErrorCode = NavigateOk;
            LastNavigateErrorURL = string.Empty;
            LastNavigateErrorFrame = string.Empty;

            try
            {
                ie.NavigateError += new DWebBrowserEvents2_NavigateErrorEventHandler(NavigateErrorHandler);
                ie.Navigate2(url);

                Wait(delegate()
                {
                    if (NavigateOk != LastNavigateErrorCode)
                    {
                        return true;
                    }

                    return IsReadyStateComplete(ie);
                });
            }
            catch (Exception e)
            {
                Debug.Print(e.ToString());
                throw;
            }
            finally
            {
                ie.NavigateError -= new DWebBrowserEvents2_NavigateErrorEventHandler(NavigateErrorHandler);
            }

            if (NavigateOk != LastNavigateErrorCode)
            {
                throw new InvalidOperationException("NavigateError");
            }
        }

        /// <summary>
        /// taks screenshot on active Internet Explorer
        /// </summary>
        /// <returns>bitmap image of screenshot</returns>
        public static Bitmap GetScreenshot()
        {
            return GetScreenshot(GetActiveBrowser());
        }

        /// <summary>
        /// take screenshot
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        /// <returns>bitmap image of screenshot</returns>
        public static Bitmap GetScreenshot(InternetExplorer ie)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            IntPtr hwnd = GetIEServerFromIEFrame((IntPtr)ie.HWND);
            IHTMLDocument3 doc3 = ie.Document as IHTMLDocument3;
            IHTMLElement html = doc3.documentElement;

            Point storeScrollPoint = new Point(
                html.getAttribute(ScrollTopPropertyName),
                html.getAttribute(ScrollLeftPropertyName));

            Size contentSize = new Size(
                html.getAttribute(ScrollWidthPropertyName),
                html.getAttribute(ScrollHeightPropertyName));

            Size clientSize = new Size(
                    html.getAttribute(ClientWidthPropertyName),
                    html.getAttribute(ClientHeightPropertyName));

            Point offset = new Point(0, 0);

            switch (MajorVersion)
            {
                case 7:
                    offset.Offset(2, 2);
                    clientSize.Width -= 4;
                    clientSize.Height -= 4;
                    contentSize.Width -= 4;
                    contentSize.Height -= 4;
                    break;

                case 8:
                case 9:
                    IHTMLDocument6 doc6 = ie.Document as IHTMLDocument6;
                    float documentMode = doc6.documentMode;

                    if (documentMode < 9)
                    {
                        offset.Offset(2, 2);
                        clientSize.Width -= 4;
                        clientSize.Height -= 4;
                        contentSize.Width -= 4;
                        contentSize.Height -= 4;
                    }

                    break;
            }

            int countY = contentSize.Height / clientSize.Height;
            int countX = contentSize.Width / clientSize.Width;

            Bitmap contentBitmap = new Bitmap(contentSize.Width, contentSize.Height);

            IntPtr winDC = WIN32API.GetWindowDC(hwnd);

            try
            {
                using (Graphics contentGraphics = Graphics.FromImage(contentBitmap))
                {
                    using (Bitmap clientBitmap = new Bitmap(clientSize.Width, clientSize.Height))
                    {
                        using (Graphics clientGraphics = Graphics.FromImage(clientBitmap))
                        {
                            for (int y = 0; y <= countY; y++)
                            {
                                int scrollTop = y * clientSize.Height;
                                html.setAttribute(ScrollTopPropertyName, scrollTop);
                                int by = html.getAttribute(ScrollTopPropertyName);

                                for (int x = 0; x <= countX; x++)
                                {
                                    int scrollLeft = x * clientSize.Width;
                                    html.setAttribute(ScrollLeftPropertyName, scrollLeft);
                                    int bx = html.getAttribute(ScrollLeftPropertyName);

                                    IntPtr hdc = clientGraphics.GetHdc();

                                    WIN32API.BitBlt(
                                        hdc,
                                        0,
                                        0,
                                        clientBitmap.Width,
                                        clientBitmap.Height,
                                        winDC,
                                        offset.X,
                                        offset.Y,
                                        WIN32API.SRCCOPY);

                                    clientGraphics.ReleaseHdc(hdc);
                                    clientGraphics.Flush();

                                    using (Image img = Image.FromHbitmap(clientBitmap.GetHbitmap()))
                                    {
                                        contentGraphics.DrawImage(img, bx, by);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                WIN32API.ReleaseDC(hwnd, winDC);
            }

            html.setAttribute(ScrollLeftPropertyName, storeScrollPoint.X);
            html.setAttribute(ScrollTopPropertyName, storeScrollPoint.Y);

            return contentBitmap;
        }

        /// <summary>
        /// Active Internet Explorer task screenshot copy to Clipboard
        /// </summary>
        public static void CopyScreenshot()
        {
            CopyScreenshot(GetActiveBrowserIfThrow());
        }

        /// <summary>
        /// screenshot copy to Clipboard
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        public static void CopyScreenshot(InternetExplorer ie)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            using (Bitmap bitmap = GetScreenshot(ie))
            {
                Clipboard.Clear();
                Clipboard.SetImage(bitmap);
            }
        }


        /// <summary>
        /// find window by name
        /// </summary>
        /// <param name="name">window name</param>
        /// <returns>InternetExplorer object or NULL</returns>
        public static InternetExplorer FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            return (from InternetExplorer ie in FindAll()
                    where ((IHTMLDocument2)ie.Document).parentWindow.name == name
                    select ie).FirstOrDefault();
        }

        /// <summary>
        /// find window by document title
        /// </summary>
        /// <param name="title">document title</param>
        /// <returns>InternetExplorer object</returns>
        public static InternetExplorer FindByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("title");
            }

            return (from InternetExplorer ie in FindAll()
                    where ((IHTMLDocument2)ie.Document).title == title
                    select ie).FirstOrDefault();
        }

        public static IEnumerable<InternetExplorer> FindAll()
        {
            IEnumerable<IntPtr> ieServerList = GetIEServerAll();

            // enum Internet Explorer instances
            List<InternetExplorer> ieList = new List<InternetExplorer>();

            foreach (IntPtr ieServer in ieServerList)
            {
                IHTMLDocument2 doc = GetHTMLDocumentFromIEServer(ieServer);
                InternetExplorer ie = GetInternetExplorerFromHTMLWindow(doc.parentWindow);

                ieList.Add(ie);
            }

            return ieList;
        }

        /// <summary>
        /// find window by url
        /// </summary>
        /// <param name="url">target url</param>
        /// <returns>InternetExplorer object</returns>
        public static InternetExplorer FindByUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("url");
            }

            return (from InternetExplorer ie in FindAll()
                    where ie.LocationURL == url
                    select ie).FirstOrDefault();
        }

        /// <summary>
        /// Waiting for a condition
        /// </summary>
        /// <param name="condition">condition delegate</param>
        public static void Wait(WaitCondition condition)
        {
            if (null == condition)
            {
                throw new ArgumentNullException("WaitCondition");
            }

            Task task = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(SleepTime / 10);

                while (false == condition())
                {
                    System.Threading.Thread.Sleep(SleepTime);
                }
            });

            if (!task.Wait(TimeoutSeconds * 1000))
            {
                throw new TimeoutException();
            }
        }

        /// <summary>
        /// wait for read complete the active Internet Explorer
        /// </summary>
        public static void WaitForReadyStateComplete()
        {
            InternetExplorer ie = GetActiveBrowser();

            if (null == ie)
            {
                return;
            }

            WaitForReadyStateComplete(ie);
        }

        /// <summary>
        /// Wait for ready complete
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        public static void WaitForReadyStateComplete(InternetExplorer ie)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            Wait(delegate()
            {
                return IsReadyStateComplete(ie);
            });

            IE.AE.WaitForInputIdle(AutomationElement.FromHandle((IntPtr)ie.HWND));
        }

        public static void WaitForReadyStateInteractiveOrComplete()
        {
            InternetExplorer ie = GetActiveBrowser();

            if (null == ie)
            {
                return;
            }

            WaitForReadyStateInteractiveOrComplete(ie);
        }

        public static void WaitForReadyStateInteractiveOrComplete(InternetExplorer ie)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            Wait(delegate()
            {
                return IsReadyStateInteractiveOrComplete(ie);
            });

            IE.AE.WaitForInputIdle(AutomationElement.FromHandle((IntPtr)ie.HWND));
        }

        /// <summary>
        /// check page loading state
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        /// <returns>true = completed, false = not completed</returns>
        public static bool IsReadyStateComplete(InternetExplorer ie)
        {
            // Debug.Print("IsReadyComplete = {0} {1} {2}", ie.Busy, ie.ReadyState, ie.LocationURL);
            return (false == ie.Busy) && (tagREADYSTATE.READYSTATE_COMPLETE == ie.ReadyState);
        }

        public static bool IsReadyStateInteractiveOrComplete(InternetExplorer ie)
        {
            // Debug.Print("IsReadyInteractiveOrComplete = {0} {1} {2}", ie.Busy, ie.ReadyState, ie.LocationURL);
            return (false == ie.Busy) && (tagREADYSTATE.READYSTATE_COMPLETE == ie.ReadyState || tagREADYSTATE.READYSTATE_INTERACTIVE == ie.ReadyState);
        }

        private static AutomationElementCollection GetIEFrameAutomationAll()
        {
            return AE.FindAllByClassName(AutomationElement.RootElement, IEFrameWindowClassName);
        }

        private static void NavigateErrorHandler(object disp, ref object url, ref object frame, ref object statusCode, ref bool cancel)
        {
            LastNavigateErrorCode = (int)statusCode;
            LastNavigateErrorURL = url as string;
            LastNavigateErrorFrame = frame as string;
        }

        /// <summary>
        /// Get children of accessible object
        /// </summary>
        /// <param name="acc">accessible object</param>
        /// <returns>children of accessible object</returns>
        private static IEnumerable<IAccessible> GetAccessibleChildren(IAccessible acc)
        {
            Debug.Assert(null != acc, "IAccessible is null");

            List<IAccessible> list = new List<IAccessible>();

            int count = acc.accChildCount;

            if (0 == count)
            {
                return list.ToArray();
            }

            int childs = 0;
            object[] children = new object[count];
            WIN32API.AccessibleChildren(acc, 0, count, children, out childs);

            foreach (object child in children)
            {
                IAccessible ac = child as IAccessible;

                if (null == ac)
                {
                    continue;
                }

                list.Add(ac);
            }

            return list;
        }

        /// <summary>
        /// Get description of accessible object
        /// </summary>
        /// <param name="acc">accessible object</param>
        /// <returns>description string</returns>
        private static string GetAccessibleDescription(IAccessible acc)
        {
            Debug.Assert(null != acc, "IAccessible is null");

            string description = acc.get_accDescription(WIN32API.CHILD_ID_SELF);

            if (string.IsNullOrEmpty(description))
            {
                return string.Empty;
            }

            if (!description.Contains(Environment.NewLine))
            {
                return string.Empty;
            }

            return description.Substring(description.IndexOf(Environment.NewLine)).Trim();
        }

        /// <summary>
        /// activate Internet Explorer
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        private static void SetActiveBrowser(InternetExplorer ie)
        {
            if (null == ie)
            {
                throw new ArgumentNullException("InternetExplorer");
            }

            IntPtr hwnd = (IntPtr)ie.HWND;

            // ウィンドウが最小化されていたら通常に戻す
            if (WIN32API.IsIconic(hwnd))
            {
                WIN32API.ShowWindowAsync(hwnd, WIN32API.SW_RESTORE);
            }

            // 最前面に表示する
            WIN32API.SetForegroundWindow(hwnd);

            // プロセスにアタッチする
            uint processId = 0;
            uint threadId = WIN32API.GetWindowThreadProcessId(hwnd, out processId);
            uint currentActiveThreadId = WIN32API.GetWindowThreadProcessId(WIN32API.GetForegroundWindow(), out processId);

            if (threadId == currentActiveThreadId)
            {
                WIN32API.BringWindowToTop(hwnd);
            }
            else
            {
                WIN32API.AttachThreadInput(threadId, currentActiveThreadId, true);

                try
                {
                    WIN32API.BringWindowToTop(hwnd);
                }
                finally
                {
                    WIN32API.AttachThreadInput(threadId, currentActiveThreadId, false);
                }
            }

            // IE6 ならリターン
            if (6 == MajorVersion)
            {
                return;
            }

            // IE7以上ならタブをアクティブにする
            ActivateTab(ie);
        }

        /// <summary>
        /// Activate the tab of the same URL as the URL of the active Internet Explorer
        /// </summary>
        /// <param name="ie">InternetExplorer object</param>
        private static void ActivateTab(InternetExplorer ie)
        {
            Debug.Assert(null != ie, "IE is null");

            IntPtr hwnd = IntPtr.Zero;

            switch (IE.MajorVersion)
            {
                case 7:
                case 8:
                    hwnd = WIN32API.FindWindowEx((IntPtr)ie.HWND, IntPtr.Zero, "CommandBarClass", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "ReBarWindow32", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "TabBandClass", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "DirectUIHWND", null);
                    break;

                default:
                    hwnd = WIN32API.FindWindowEx((IntPtr)ie.HWND, IntPtr.Zero, "WorkerW", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "ReBarWindow32", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "TabBandClass", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "DirectUIHWND", null);
                    break;
            }

            IntPtr directUI = hwnd;
            Debug.Assert(IntPtr.Zero != directUI, "directUI is null");

            IAccessible directUIAcc = null;
            WIN32API.AccessibleObjectFromWindow(directUI, WIN32API.OBJID.OBJID_WINDOW, ref directUIAcc);

            string url = ie.LocationURL;

            foreach (IAccessible accessor in GetAccessibleChildren(directUIAcc))
            {
                foreach (IAccessible tabs in GetAccessibleChildren(accessor))
                {
                    foreach (IAccessible tab in GetAccessibleChildren(tabs))
                    {
                        string description = GetAccessibleDescription(tab);

                        if (description == url)
                        {
                            tab.accDoDefaultAction(WIN32API.CHILD_ID_SELF);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// get active window. if not found then throw exception
        /// </summary>
        /// <returns>InternetExplorer object</returns>
        private static InternetExplorer GetActiveBrowserIfThrow()
        {
            InternetExplorer ie = GetActiveBrowser();

            if (null == ie)
            {
                throw new InvalidOperationException("No Such InternetExplorer");
            }

            return ie;
        }

        /// <summary>
        /// get active window
        /// </summary>
        /// <returns>InternetExplorer object</returns>
        private static InternetExplorer GetActiveBrowser()
        {
            AutomationElement ieFrameAutomation = AE.FindByClassName(AutomationElement.RootElement, IEFrameWindowClassName);

            if (null == ieFrameAutomation)
            {
                return null;
            }

            AE.WaitForInputIdle(ieFrameAutomation);

            for (int retry = 0; retry < GetActiveWindowRetryLimit; retry++)
            {
                IntPtr ieServer = GetIEServerFromIEFrame((IntPtr)ieFrameAutomation.Current.NativeWindowHandle);

                if (IntPtr.Zero != ieServer)
                {
                    IHTMLDocument2 doc = GetHTMLDocumentFromIEServer(ieServer);

                    if (null != doc)
                    {
                        InternetExplorer ie = GetInternetExplorerFromHTMLWindow(doc.parentWindow);

                        if (null != ie)
                        {
                            return ie;
                        }
                    }
                }

                Debug.Print("IE.GetActiveWindow: Retry = {0}", retry);
                Thread.Sleep(SleepTime);
            }

            return null;
        }

        private static InternetExplorer GetInternetExplorerFromHTMLWindow(IHTMLWindow2 win)
        {
            if (null == win)
            {
                return null;
            }

            Guid serviceProviderGuid = typeof(IServiceProvider).GUID;
            IServiceProvider serviceProvider = win as IServiceProvider;

            if (null == serviceProvider)
            {
                return null;
            }

            object serviceProviderObj;
            serviceProvider.QueryService(ref guidTopLevelBrowser, ref serviceProviderGuid, out serviceProviderObj);
            serviceProvider = serviceProviderObj as IServiceProvider;

            if (null == serviceProvider)
            {
                return null;
            }

            object webBrowserObj;
            Guid webBrowserGuid = typeof(IWebBrowser2).GUID;

            serviceProvider.QueryService(ref guidWebBrowserApp, ref webBrowserGuid, out webBrowserObj);

            return webBrowserObj as InternetExplorer;
        }

        /// <summary>
        ///  Get IHTMLDocument2 from window handle of "Internet Explorer_Server"
        /// </summary>
        /// <param name="ieServer">Window handle of "Internet Explorer_Server"</param>
        /// <returns>IHTMLDocument2 or null</returns>
        private static IHTMLDocument2 GetHTMLDocumentFromIEServer(IntPtr ieServer)
        {
            Debug.Assert(IntPtr.Zero != ieServer, "ieServer is null");

            IHTMLDocument2 doc = null;

            int msg = WIN32API.RegisterWindowMessage("WM_HTML_GETOBJECT");
            int result;

            if (0 == msg)
            {
                return null;
            }

            WIN32API.SendMessageTimeout(ieServer, msg, 0, 0, WIN32API.SMTO_ABORTIFHUNG, 1000, out result);

            if (0 == result)
            {
                return null;
            }

            int hr = WIN32API.ObjectFromLresult(result, ref guidIHTMLDocument, 0, ref doc);

            if ((bool)(doc == null))
            {
                return null;
            }

            return doc;
        }

        /// <summary>
        /// get window handler of "Internet Explorer_Server" from "IEFrame"
        /// </summary>
        /// <param name="ieFrame">window handle of "IEFrame" window</param>
        /// <returns>window handle of "Internet Explorer_Server" window</returns>
        private static IntPtr GetIEServerFromIEFrame(IntPtr ieFrame)
        {
            IntPtr hwnd = IntPtr.Zero;

            switch (MajorVersion)
            {
                case 6:
                    hwnd = WIN32API.FindWindowEx(ieFrame, IntPtr.Zero, "Shell DocObject View", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "Internet Explorer_Server", null);
                    break;

                case 7:
                    hwnd = WIN32API.FindWindowEx(ieFrame, IntPtr.Zero, "TabWindowClass", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "Shell DocObject View", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "Internet Explorer_Server", null);
                    break;

                case 8:
                case 9:
                    hwnd = WIN32API.FindWindowEx(ieFrame, IntPtr.Zero, "Frame Tab", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "TabWindowClass", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "Shell DocObject View", null);
                    hwnd = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "Internet Explorer_Server", null);
                    break;

                default:
                    throw new InvalidOperationException(string.Format("GetIEServerFromIEFrame: Unknown IE Vesion = {0}", MajorVersion));
            }

            return hwnd;
        }

        private static IEnumerable<IntPtr> GetIEServerAll()
        {
            // enum "IEFrame" window handles
            List<IntPtr> ieFrameList = new List<IntPtr>();

            foreach (AutomationElement ieFrameAutomation in GetIEFrameAutomationAll())
            {
                ieFrameList.Add((IntPtr)ieFrameAutomation.Current.NativeWindowHandle);
            }

            // enum "Internet Explorer_Server" window handles from "IEFrame"
            List<IntPtr> ieServerList = new List<IntPtr>();

            foreach (IntPtr ieFrame in ieFrameList)
            {
                WIN32API.EnumChildWindows(
                  ieFrame,
                  new WIN32API.EnumWindowsDelegate(delegate(IntPtr hwnd, int lparam)
                  {
                      StringBuilder sb = new StringBuilder(1024);
                      WIN32API.GetClassName(hwnd, sb, sb.Capacity);
                      IntPtr target = IntPtr.Zero;
                      string name = sb.ToString();

                      switch (MajorVersion)
                      {
                          case 7:
                              if ("TabWindowClass" == name)
                              {
                                  target = hwnd;
                              }

                              break;

                          case 8:
                          case 9:
                              if ("Frame Tab" == name)
                              {
                                  target = WIN32API.FindWindowEx(hwnd, IntPtr.Zero, "TabWindowClass", null);
                              }

                              break;
                      }

                      if (IntPtr.Zero != target)
                      {
                          target = WIN32API.FindWindowEx(target, IntPtr.Zero, "Shell DocObject View", null);
                          target = WIN32API.FindWindowEx(target, IntPtr.Zero, "Internet Explorer_Server", null);

                          if (IntPtr.Zero != target)
                          {
                              ieServerList.Add(target);
                          }
                      }

                      return 1;
                  }),
              0);
            }

            return ieServerList;
        }

        /// <summary>
        /// Element Class
        /// </summary>
        public static class Element
        {
            public delegate void ElementEventHandler(object sender, IHTMLEventObj evt);

            public static List<string> GetClassList(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                List<string> list = new List<string>();

                if (!string.IsNullOrWhiteSpace(element.className))
                {
                    list.AddRange(element.className.Split(' '));
                }

                return list;
            }

            public static void AddClass(IHTMLElement element, string className)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (string.IsNullOrWhiteSpace(className))
                {
                    throw new ArgumentNullException("className");
                }

                if (HasClass(element, className))
                {
                    return;
                }

                List<string> list = GetClassList(element);
                list.Add(className);
                element.className = string.Join(" ", list);
            }

            public static void RemoveClass(IHTMLElement element, string className)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (string.IsNullOrWhiteSpace(className))
                {
                    throw new ArgumentNullException("className");
                }

                List<string> list = GetClassList(element);
                list.Remove(className);
                element.className = string.Join(" ", list);
            }

            public static bool HasClass(IHTMLElement element, string className)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (string.IsNullOrWhiteSpace(className))
                {
                    throw new ArgumentNullException("className");
                }

                string s = element.className;

                if (string.IsNullOrWhiteSpace(s))
                {
                    return false;
                }

                return null != (from c in GetClassList(element)
                                where 0 == string.Compare(s, className.Trim(), true)
                                select c).FirstOrDefault();
            }

            public static string GetText(IHTMLElement element)
            {
                return element.innerText;
            }

            public static void SetText(IHTMLElement element, string text)
            {
                element.innerText = text;
            }

            public static Rectangle GetGlobalRect(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                IHTMLDocument2 doc = element.document;
                IHTMLWindow2 win = doc.parentWindow;

                InternetExplorer ie = GetInternetExplorerFromHTMLWindow(win);
                IntPtr ieFrame = (IntPtr)ie.HWND;
                IntPtr ieServer = GetIEServerFromIEFrame(ieFrame);

                WIN32API.RECT ieServerRect = new WIN32API.RECT();
                WIN32API.GetWindowRect(ieServer, ref ieServerRect);

                Debug.Print(
                    "({0},{1})-({2},{3})",
                    ieServerRect.left,
                    ieServerRect.top,
                    ieServerRect.right,
                    ieServerRect.bottom);

                IHTMLElement2 scroll = Element.GetScrollTarget(doc) as IHTMLElement2;
                Rectangle elementRect = Element.GetDisplayRect(element);
                elementRect.Offset(-scroll.scrollLeft, -scroll.scrollTop);
                elementRect.Offset(ieServerRect.left, ieServerRect.top);

                return elementRect;
            }

            public static void ClearHighlight()
            {
                InternetExplorer ie = IE.GetActiveBrowser();

                if (null == ie)
                {
                    return;
                }

                IHTMLDocument2 doc = ie.Document;

                if (null == doc)
                {
                    return;
                }

                IHTMLElement body = doc.body;

                if (null == doc)
                {
                    return;
                }

                string id = GetAttribute(body, "guid");

                if (string.IsNullOrWhiteSpace(id))
                {
                    return;
                }

                IHTMLElement target = ((IHTMLDocument3)doc).getElementById(id);

                if (null == target)
                {
                    return;
                }

                ((IHTMLDOMNode)target).removeNode(true);
            }

            /// <summary>
            /// highlight element
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>element display rectangle</returns>
            public static Rectangle Highlight(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (!IsVisible(element))
                {
                    return Rectangle.Empty;
                }

                SetFocus(element);

                IHTMLDocument2 doc = element.document;
                IHTMLElement body = doc.body;

                string guid = Element.GetAttribute(body, "guid");

                if (!string.IsNullOrWhiteSpace(guid))
                {
                    IHTMLElement target = ((IHTMLDocument3)doc).getElementById(guid);
                    ((IHTMLDOMNode)target).removeNode(true);
                }

                guid = Guid.NewGuid().ToString();
                SetAttribute(body, "guid", guid);

                Rectangle rect = GetDisplayRect(element);

                IHTMLElement div1 = doc.createElement("div");

                div1.id = guid;
                div1.style.cssText = string.Format(
                    "position:absolute; z-index:9999; border:5px solid red; left:{0}px; top:{1}px; width:{2}px; height:{3}px;",
                    rect.X - 5,
                    rect.Y - 5,
                    rect.Width,
                    rect.Height);

                IHTMLElement div2 = doc.createElement("div");

                div2.style.cssText = string.Format(
                    "left:0px; top:0px; width:{0}px; height:{1}px; background-color:red; filter:alpha(opacity=20);",
                    rect.Width,
                    rect.Height);

                ((IHTMLDOMNode)div1).appendChild((IHTMLDOMNode)div2);
                ((IHTMLDOMNode)doc.body).insertBefore((IHTMLDOMNode)div1);

                for (int i = 0; i < 1; i++)
                {
                    Thread.Sleep(200);
                    div1.style.display = "none";

                    Thread.Sleep(200);
                    div1.style.display = "block";
                }

                return rect;
            }

            /// <summary>
            /// set focus for element with scroll into view
            /// </summary>
            /// <param name="element">target element</param>
            public static void SetFocus(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (IsDisabled(element))
                {
                    return;
                }

                if (!IsVisible(element))
                {
                    return;
                }

                try
                {
                    IHTMLElement2 target = GetScrollTarget(element.document);
                    Rectangle rect = GetDisplayRect(element);
                    int h = target.clientHeight;
                    int y = rect.Top + (rect.Height / 2) - (h / 2);
                    target.scrollTop = y;

                    IHTMLDocument2 doc = element.document;
                    ((IHTMLElement2)doc.body).focus();
                    ((IHTMLElement2)element).focus();
                }
                catch (Exception e)
                {
                    Debug.Print(e.ToString());
                }
            }

            /// <summary>
            /// click element
            /// </summary>
            /// <param name="element">target element</param>
            public static void Click(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                element.click();
            }

            /// <summary>
            /// Fires a specified event on the object.
            /// </summary>
            /// <param name="element">target element</param>
            /// <param name="eventType">event type</param>
            /// <param name="evt">event object</param>
            /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
            public static bool FireEvent(IHTMLElement element, string eventType, IHTMLEventObj evt)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (string.IsNullOrWhiteSpace(eventType))
                {
                    throw new ArgumentNullException("eventType");
                }

                if (null == evt)
                {
                    throw new ArgumentNullException("EventObj");
                }

                return ((IHTMLElement3)element).FireEvent(eventType, evt);
            }

            /// <summary>
            /// set attribute value
            /// </summary>
            /// <param name="element">target element</param>
            /// <param name="name">attribute name</param>
            /// <param name="value">attribute value</param>
            public static void SetAttribute(IHTMLElement element, string name, string value)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("name");
                }

                element.setAttribute(name, value);
            }

            /// <summary>
            /// get attribute value
            /// </summary>
            /// <param name="element">target element</param>
            /// <param name="name">attribute name</param>
            /// <returns>attribute value</returns>
            public static string GetAttribute(IHTMLElement element, string name)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("name");
                }

                IHTMLDOMAttribute attr = ((IHTMLElement4)element).getAttributeNode(name);

                if (null == attr)
                {
                    return string.Empty;
                }

                return attr.nodeValue;
            }

            /// <summary>
            /// check attribute exists
            /// </summary>
            /// <param name="element">target element</param>
            /// <param name="name">attribute name</param>
            /// <returns>exists = true, not exists = false</returns>
            public static bool HasAttribute(IHTMLElement element, string name)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("name");
                }

                IHTMLDOMAttribute attr = ((IHTMLElement4)element).getAttributeNode(name);

                return null != attr;
            }

            /// <summary>
            /// set value for input element
            /// </summary>
            /// <param name="element">target element</param>
            /// <param name="value">input value</param>
            public static void SetValue(IHTMLElement element, string value)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                SetFocus(element);

                if (string.IsNullOrWhiteSpace(value))
                {
                    value = string.Empty;
                }

                if (element is IHTMLTextAreaElement)
                {
                    ((IHTMLTextAreaElement)element).value = value;
                }
                else
                {
                    SetAttribute(element, "value", value);
                }
            }

            /// <summary>
            /// get value of input element
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>input value</returns>
            public static string GetValue(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (element is IHTMLTextAreaElement)
                {
                    return ((IHTMLTextAreaElement)element).value;
                }
                else
                {
                    return GetAttribute(element, "value");
                }
            }

            /// <summary>
            /// get element visible state
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>visible state. show = true, hidden = false</returns>
            public static bool IsVisible(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                for (; null != element; element = element.parentElement)
                {
                    IHTMLElement2 element2 = (IHTMLElement2)element;
                    string display = element2.currentStyle.display;

                    if (0 == string.Compare(display, "none", true))
                    {
                        return false;
                    }

                    string visibility = element2.currentStyle.visibility;

                    if (0 == string.Compare(visibility, "hidden", true))
                    {
                        return false;
                    }
                }

                return true;
            }

            public static bool IsDisabled(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                return ((IHTMLElement3)element).isDisabled;
            }

            public static IHTMLElement GetLabelFor(IHTMLLabelElement label)
            {
                if (!string.IsNullOrWhiteSpace(label.htmlFor))
                {
                    IHTMLDocument3 doc = ((IHTMLElement)label).document;
                    return doc.getElementById(label.htmlFor);
                }

                IHTMLElementCollection elements = ((IHTMLElement2)label).getElementsByTagName("input");

                for (int i = 0; i < elements.length; i++)
                {
                    IHTMLElement element = elements.item(i);

                    if (IE.Element.IsRadioOrCheckboxElement(element))
                    {
                        return element;
                    }
                }

                return null;
            }

            /// <summary>
            /// set check state for checkbox or radio button
            /// </summary>
            /// <param name="element">target element</param>
            /// <param name="isChecked">check state</param>
            public static void SetChecked(IHTMLElement element, bool isChecked)
            {
                if (IsRadioOrCheckboxElement(element))
                {
                    ((IHTMLInputElement)element).@checked = isChecked;
                }
                else if (element is IHTMLLabelElement)
                {
                    IHTMLElement target = GetLabelFor((IHTMLLabelElement)element);

                    Wait(delegate()
                    {
                        if (isChecked == IE.Element.IsChekced(target))
                        {
                            return true;
                        }

                        IE.Element.Click(element);

                        return false;
                    });
                }
                else
                {
                    throw new InvalidOperationException(element.tagName);
                }
            }

            /// <summary>
            /// get check state of checkbox or radio button
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>check state</returns>
            public static bool IsChekced(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                if (element is IHTMLLabelElement)
                {
                    element = IE.Element.GetLabelFor((IHTMLLabelElement)element);
                }

                if (!IsRadioOrCheckboxElement(element))
                {
                    throw new InvalidOperationException(element.tagName);
                }

                return ((IHTMLInputElement)element).@checked;
            }

            /// <summary>
            /// check element is checkbox or radio button
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>true = element is checkbox or radio button. false = otherwise</returns>
            public static bool IsRadioOrCheckboxElement(IHTMLElement element)
            {
                return IsRadioButtonElement(element) || IsCheckboxElement(element);
            }

            /// <summary>
            /// check element is radio button
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>true = element is radio button, false = otherwise</returns>
            public static bool IsRadioButtonElement(IHTMLElement element)
            {
                IHTMLInputElement input = element as IHTMLInputElement;

                if (null == input)
                {
                    return false;
                }

                return input.type.Equals("radio", StringComparison.CurrentCultureIgnoreCase);
            }

            /// <summary>
            /// check element in checkbox
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>true = checkbox, false = otherwise</returns>
            public static bool IsCheckboxElement(IHTMLElement element)
            {
                IHTMLInputElement input = element as IHTMLInputElement;

                if (null == input)
                {
                    return false;
                }

                return input.type.Equals("checkbox", StringComparison.CurrentCultureIgnoreCase);
            }

            /// <summary>
            /// find option element
            /// </summary>
            /// <param name="select">target select element</param>
            /// <param name="locator">option locator</param>
            /// <returns>option element</returns>
            public static IHTMLOptionElement GetOption(IHTMLSelectElement select, string locator)
            {
                List<IHTMLOptionElement> list = GetOptionList(select);

                string[] ss = locator.Split('=');
                string s1 = ss.ElementAtOrDefault(0);
                string s2 = ss.ElementAtOrDefault(1);

                if (string.IsNullOrWhiteSpace(s1))
                {
                    s1 = string.Empty;
                }

                if (string.IsNullOrWhiteSpace(s2))
                {
                    s2 = s1;
                }

                switch (s1.ToLower())
                {
                    case "label":
                        return (from o in list
                                where o.text == s2
                                select o).FirstOrDefault();

                    case "value":
                        return (from o in list
                                where o.value == s2
                                select o).FirstOrDefault();

                    case "id":
                        return (from o in list
                                where ((IHTMLElement)o).id == s2
                                select o).FirstOrDefault();

                    case "index":
                        int index = int.Parse(s2);
                        return list.ElementAtOrDefault(index);

                    default:
                        return (from o in list
                                where o.text == s2 || o.value == s2
                                select o).FirstOrDefault();
                }
            }

            /// <summary>
            /// Get Element Display Rectangle
            /// </summary>
            /// <param name="element">target element</param>
            /// <returns>display rectangle</returns>
            public static Rectangle GetDisplayRect(IHTMLElement element)
            {
                if (null == element)
                {
                    throw new ArgumentNullException("element");
                }

                IHTMLRect rect = ((IHTMLElement2)element).getBoundingClientRect();
                IHTMLDocument2 doc2 = (IHTMLDocument2)element.document;
                IHTMLDocument3 doc3 = (IHTMLDocument3)element.document;
                IHTMLDocument5 doc5 = (IHTMLDocument5)element.document;
                IHTMLElement2 scroll = GetScrollTarget(doc2);

                int sx = scroll.scrollLeft;
                int sy = scroll.scrollTop;

                int x = rect.left + sx - scroll.clientLeft;
                int y = rect.top + sy - scroll.clientTop;
                int w = element.offsetWidth;
                int h = element.offsetHeight;

                return new Rectangle(x, y, w, h);
            }

            /// <summary>
            /// Element Locator convert to CSS Selector
            /// </summary>
            /// <param name="locator">element locator</param>
            /// <returns>CSS Selector</returns>
            private static string ParseLocator(string locator)
            {
                if (string.IsNullOrWhiteSpace(locator))
                {
                    throw new ArgumentNullException("locator");
                }

                return TryConvertLocator(locator, "css", "{0}")
                    ?? TryConvertLocator(locator, "id", "#{0}")
                    ?? TryConvertLocator(locator, "name", "input[name=\"{0}\"], textarea[name=\"{0}\"], select[name=\"{0}\"]")
                    ?? TryConvertLocator(locator, "link", "a:contains(\"{0}\"), a[title=\"{0}\"], a[href=\"{0}\"]")
                    ?? TryConvertLocator(locator, "button", "input[type=button][value=\"{0}\"], input[type=submit][value=\"{0}\"], input[type=reset][\"value={0}\"], button:contains(\"{0}\")")
                    ?? TryConvertLocator(locator, "label", "label:contains(\"{0}\")")
                    ?? locator;
            }

            /// <summary>
            /// 指定された LocationType に合致する場合に CSS Selector を返す。合致しない場合は null を返す
            /// </summary>
            /// <param name="locator">element locator</param>
            /// <param name="locationType">location type</param>
            /// <param name="format">format string</param>
            /// <returns>CSS Selector</returns>
            private static string TryConvertLocator(string locator, string locationType, string format)
            {
                Debug.Assert(!string.IsNullOrWhiteSpace(locator), "locator is null");
                Debug.Assert(!string.IsNullOrWhiteSpace(locationType), "locationType is null");
                Debug.Assert(!string.IsNullOrWhiteSpace(format), "format is null");

                string prefix = locationType + "=";

                if (locator.StartsWith(prefix))
                {
                    return string.Format(format, locator.Substring(prefix.Length));
                }
                else
                {
                    return null;
                }
            }

            private static IHTMLElement2 GetScrollTarget(IHTMLDocument2 doc)
            {
                IHTMLDocument3 doc3 = doc as IHTMLDocument3;
                IHTMLDocument5 doc5 = doc as IHTMLDocument5;
                IHTMLElement target = doc.body;

                if (null == target || "CSS1Compat".Equals(doc5.compatMode))
                {
                    target = doc3.documentElement;
                }

                return target as IHTMLElement2;
            }

            private static List<IHTMLOptionElement> GetOptionList(IHTMLSelectElement select)
            {
                List<IHTMLOptionElement> list = new List<IHTMLOptionElement>();

                for (int i = 0; i < select.options.length; i++)
                {
                    list.Add(select.options.item(i) as IHTMLOptionElement);
                }

                return list;
            }

            public static class Event
            {
                private static SynchronizedCollection<EventProxy> proxyList = new SynchronizedCollection<EventProxy>();

                /// <summary>
                /// Attach Event
                /// </summary>
                /// <param name="element">target element</param>
                /// <param name="eventType">event type</param>
                /// <param name="handler">event handler</param>
                public static void Attach(IHTMLElement element, string eventType, ElementEventHandler handler)
                {
                    if (null == element)
                    {
                        throw new ArgumentNullException("element");
                    }

                    if (string.IsNullOrWhiteSpace(eventType))
                    {
                        throw new ArgumentNullException("eventType");
                    }

                    if (null == handler)
                    {
                        throw new ArgumentNullException("handler");
                    }

                    EventProxy proxy = new EventProxy(element, eventType, handler);
                    proxyList.Add(proxy);
                }

                public static void DetachAll()
                {
                    lock (proxyList)
                    {
                        foreach (EventProxy proxy in proxyList)
                        {
                            proxy.Detach();
                        }

                        proxyList.Clear();
                    }
                }

                /// <summary>
                /// Element Event Proxy Class
                /// </summary>
                private class EventProxy : IDisposable, IReflect
                {
                    private string eventType;
                    private ElementEventHandler handler;
                    private bool isAttached;
                    private IReflect typeIReflectImplementation;

                    /// <summary>
                    /// Initializes a new instance of the EventProxy class.
                    /// </summary>
                    /// <param name="element">HTML Element</param>
                    /// <param name="eventType">HTML Event Name</param>
                    /// <param name="handler">Callback Handler</param>
                    public EventProxy(IHTMLElement element, string eventType, ElementEventHandler handler)
                    {
                        this.NativeElement = element;
                        this.eventType = eventType;
                        this.handler = handler;
                        Type type = typeof(EventProxy);
                        this.typeIReflectImplementation = type;

                        this.Attach();
                    }

                    Type IReflect.UnderlyingSystemType
                    {
                        get
                        {
                            return this.typeIReflectImplementation.UnderlyingSystemType;
                        }
                    }

                    public IHTMLElement NativeElement
                    {
                        get;
                        private set;
                    }

                    private string EventTypeString
                    {
                        get
                        {
                            return "on" + this.eventType.ToString().ToLower();
                        }
                    }

                    /// <summary>
                    /// Attach Events
                    /// </summary>
                    public void Attach()
                    {
                        if (true == this.isAttached)
                        {
                            return;
                        }

                        this.isAttached = true;

                        ((IHTMLElement2)this.NativeElement).attachEvent(this.EventTypeString, this);
                    }

                    /// <summary>
                    /// Detach Events
                    /// </summary>
                    public void Detach()
                    {
                        if (false == this.isAttached)
                        {
                            return;
                        }

                        this.isAttached = false;

                        lock (this)
                        {
                            ((IHTMLElement2)this.NativeElement).detachEvent(this.EventTypeString, this);
                        }
                    }

                    public void Dispose()
                    {
                        this.Detach();
                    }

                    FieldInfo IReflect.GetField(string name, BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetField(name, bindingAttr);
                    }

                    FieldInfo[] IReflect.GetFields(BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetFields(bindingAttr);
                    }

                    MemberInfo[] IReflect.GetMember(string name, BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetMember(name, bindingAttr);
                    }

                    MemberInfo[] IReflect.GetMembers(BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetMembers(bindingAttr);
                    }

                    MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetMethod(name, bindingAttr);
                    }

                    MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
                    {
                        return this.typeIReflectImplementation.GetMethod(name, bindingAttr, binder, types, modifiers);
                    }

                    MethodInfo[] IReflect.GetMethods(BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetMethods(bindingAttr);
                    }

                    PropertyInfo[] IReflect.GetProperties(BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetProperties(bindingAttr);
                    }

                    PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr)
                    {
                        return this.typeIReflectImplementation.GetProperty(name, bindingAttr);
                    }

                    PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
                    {
                        return this.typeIReflectImplementation.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
                    }

                    object IReflect.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
                    {
                        if ("[DISPID=0]" != name)
                        {
                            return null;
                        }

                        if (null == this.handler)
                        {
                            return null;
                        }

                        IHTMLEventObj eventObj = (IHTMLEventObj)args[0];
                        eventObj.cancelBubble = true;

                        this.handler(this, eventObj);

                        return null;
                    }
                }
            }
        }
        private static class AE
        {
            #region Public Methods

            public static AutomationElement FindByAccessKey(AutomationElement parent, ControlType controlType, string accessKey)
            {
                AutomationElementCollection elements = FindAllByControlType(parent, controlType);

                foreach (AutomationElement element in elements)
                {
                    if (accessKey == element.Current.AccessKey)
                    {
                        return element;
                    }
                }

                return null;
            }

            public static AutomationElement FindById(AutomationElement parent, string id)
            {
                if (null == parent)
                {
                    return null;
                }

                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentNullException("id");
                }

                return parent.FindFirst(
                        TreeScope.Children,
                        new PropertyCondition(AutomationElement.AutomationIdProperty, id));
            }

            public static AutomationElement FindByControlType(AutomationElement parent, ControlType controlType)
            {
                if (null == parent)
                {
                    return null;
                }

                return parent.FindFirst(
                        TreeScope.Children,
                        new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));
            }

            public static AutomationElementCollection FindAllByControlType(AutomationElement parent, ControlType controlType)
            {
                if (null == parent)
                {
                    return null;
                }

                return parent.FindAll(
                        TreeScope.Children,
                        new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));
            }

            public static AutomationElement FindByClassName(AutomationElement parent, string className)
            {
                if (null == parent)
                {
                    return null;
                }

                if (string.IsNullOrWhiteSpace(className))
                {
                    throw new ArgumentNullException("className");
                }

                return parent.FindFirst(
                        TreeScope.Children,
                        new PropertyCondition(AutomationElement.ClassNameProperty, className));
            }

            public static AutomationElementCollection FindAllByClassName(AutomationElement parent, string className)
            {
                if (null == parent)
                {
                    return null;
                }

                if (string.IsNullOrWhiteSpace(className))
                {
                    throw new ArgumentNullException("className");
                }

                return parent.FindAll(
                        TreeScope.Children,
                        new PropertyCondition(AutomationElement.ClassNameProperty, className));
            }

            public static ValuePattern GetValuePattern(AutomationElement element)
            {
                return element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            }

            public static void SetValue(AutomationElement element, string value)
            {
                ValuePattern pattern = GetValuePattern(element);
                pattern.SetValue(value);
            }

            public static string GetValue(AutomationElement element)
            {
                ValuePattern pattern = GetValuePattern(element);

                return pattern.Current.Value;
            }

            public static InvokePattern GetInvokePattern(AutomationElement element)
            {
                return element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }

            public static void Invoke(AutomationElement element)
            {
                InvokePattern pattern = GetInvokePattern(element);
                pattern.Invoke();
            }

            public static WindowPattern GetWindowPattern(AutomationElement element)
            {
                return element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
            }

            public static void Close(AutomationElement element)
            {
                if (null == element)
                {
                    return;
                }

                WindowPattern pattern = GetWindowPattern(element);
                pattern.Close();
            }

            public static void WaitForInputIdle(AutomationElement element)
            {
                if (null == element)
                {
                    return;
                }

                WindowPattern pattern = GetWindowPattern(element);
                pattern.WaitForInputIdle(IE.TimeoutSeconds * 1000);
            }

            public static void Resize(AutomationElement element, int width, int height)
            {
                TransformPattern pattern = element.GetCurrentPattern(TransformPattern.Pattern) as TransformPattern;
                pattern.Resize(width, height);
            }

            #endregion
        }
    }
}
