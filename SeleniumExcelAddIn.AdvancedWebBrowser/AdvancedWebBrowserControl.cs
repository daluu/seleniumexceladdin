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
    public partial class AdvancedWebBrowserControl : UserControl
    {
        private WebBrowserEx wb;

        public AdvancedWebBrowserControl()
        {
            InitializeComponent();
        }

        private void AdvancedWebBrowserControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.wb = new WebBrowserEx();
            this.panel1.Controls.Add(this.wb);
            this.wb.Dock = DockStyle.Fill;

            this.wb.StatusTextChanged += new EventHandler(wb_StatusTextChanged);
            this.wb.CanGoBackChanged += new EventHandler(wb_CanGoBackChanged);
            this.wb.CanGoForwardChanged += new EventHandler(wb_CanGoForwardChanged);
            this.wb.DocumentTitleChanged += new EventHandler(wb_DocumentTitleChanged);
            this.wb.Navigating += new WebBrowserNavigatingEventHandler(wb_Navigating);
            this.wb.NavigateError += new WebBrowserExNavigateErrorEventHandler(wb_NavigateError);
            this.wb.Navigated += new WebBrowserNavigatedEventHandler(wb_Navigated);
            this.wb.NewWindow += new CancelEventHandler(wb_NewWindow);
            this.wb.NewWindow3 += new WebBrowserExNavigatingEventHandler(wb_NewWindow3);
            this.wb.NavigateComplete2 += new WebBrowserNavigatedEventHandler(wb_NavigateComplete2);
            this.wb.DocumentCompleted += wb_DocumentCompleted;
            this.wb.ProgressChanged += wb_ProgressChanged;

            this.wb.Navigate("http://selenium-excel-addin.jpn.org");
            this.toolStripProgressBar1.Visible = false;
        }

        void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress < 0)
            {
                this.toolStripProgressBar1.Visible = false;
            }
            else
            {
                this.toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
                this.toolStripProgressBar1.Value = Convert.ToInt32(Math.Min(e.MaximumProgress, e.CurrentProgress));
                this.toolStripProgressBar1.Visible = true;
            }
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.toolStripProgressBar1.Visible = false;
        }

        void wb_NavigateComplete2(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        void wb_NewWindow3(object sender, WebBrowserExNavigatingEventArgs e)
        {
        }

        void wb_NewWindow(object sender, CancelEventArgs e)
        {
        }

        void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
        }

        void wb_NavigateError(object sender, WebBrowserExNavigateErrorEventArgs e)
        {
        }

        void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
        }

        void wb_DocumentTitleChanged(object sender, EventArgs e)
        {
        }

        void wb_CanGoForwardChanged(object sender, EventArgs e)
        {
            this.backButton.Enabled = this.wb.CanGoBack;
        }

        void wb_CanGoBackChanged(object sender, EventArgs e)
        {
            this.forwardButton.Enabled = this.wb.CanGoForward;
        }

        void wb_StatusTextChanged(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = this.wb.StatusText;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.wb.Navigate(this.comboBox1.Text);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.wb.Refresh(WebBrowserRefreshOption.Completely);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.wb.GoBack();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            this.wb.GoForward();
        }
    }
}
