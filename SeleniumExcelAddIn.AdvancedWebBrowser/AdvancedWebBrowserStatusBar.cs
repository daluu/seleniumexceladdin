using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    public partial class AdvancedWebBrowserStatusBar : UserControl
    {
        public AdvancedWebBrowserStatusBar()
        {
            InitializeComponent();
        }

        private void AdvancedWebBrowserStatusBar_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.toolStripProgressBar1.Visible = false;
        }

        private AdvancedWebBrowser wb;

        public AdvancedWebBrowser AdvancedWebBrowser
        {
            get
            {
                return this.wb;
            }

            set
            {
                this.RemoveEventListners();
                this.wb = value;
                this.AddEventListners();
            }
        }

        private void AddEventListners()
        {
            if (null == this.wb)
            {
                return;
            }

            this.ieVersionLabel.Text = "IE:" + this.AdvancedWebBrowser.Version.ToString(1);
            this.wb.StatusTextChanged += new EventHandler(wb_StatusTextChanged);
            this.wb.ProgressChanged +=new WebBrowserProgressChangedEventHandler(wb_ProgressChanged);
            this.wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.documentModeLabel.Text = "DocumentMode:" + this.wb.DocumentMode.ToString();
        }

        private void RemoveEventListners()
        {
            if (null == this.wb)
            {
                return;
            }

            this.wb.StatusTextChanged -= new EventHandler(wb_StatusTextChanged);
            this.wb.ProgressChanged += new WebBrowserProgressChangedEventHandler(wb_ProgressChanged);
        }

        void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress < 0 || e.MaximumProgress <= e.CurrentProgress)
            {
                this.toolStripProgressBar1.Visible = false;
            }
            else
            {
                this.toolStripProgressBar1.Visible = true;
                this.toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
                this.toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
            }
        }

        void wb_StatusTextChanged(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = this.AdvancedWebBrowser.StatusText;
        }
    }
}
