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
    public partial class AdvancedWebBrowserAddressBar : UserControl
    {
        public AdvancedWebBrowserAddressBar()
        {
            InitializeComponent();
        }

        private void AdvancedWebBrowserAddressBar_Load(object sender, EventArgs e)
        {
            ToolStripManager.Renderer = new CustomToolStripRenderer(SystemColors.Control);

            if (this.DesignMode)
            {
                return;
            }

            this.backButton.Enabled = false;
            this.forwardButton.Enabled = false;
            Context.RecordingChanged += new EventHandler(Context_RecordingChanged);
        }

        void Context_RecordingChanged(object sender, EventArgs e)
        {
            this.recButton.Checked = Context.IsRecoding;
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

        private void RemoveEventListners()
        {
            if (null == this.wb)
            {
                return;
            }
        }

        private void AddEventListners()
        {
            if (null == this.wb)
            {
                return;
            }

            this.wb.CanGoBackChanged += new EventHandler(wb_CanGoBackChanged);
            this.wb.CanGoForwardChanged += new EventHandler(wb_CanGoForwardChanged);
            this.wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
        }

        void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.comboBox1.Text = this.AdvancedWebBrowser.Url.ToString();
        }

        void wb_CanGoForwardChanged(object sender, EventArgs e)
        {
            this.forwardButton.Enabled = this.AdvancedWebBrowser.CanGoForward;
        }

        void wb_CanGoBackChanged(object sender, EventArgs e)
        {
            this.backButton.Enabled = this.AdvancedWebBrowser.CanGoBack;
        }

        private void Go()
        {
            this.wb.Navigate(this.comboBox1.Text);
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    this.Go();
                    break;
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            this.Go();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.wb.Refresh();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.wb.GoBack();
        }

        private void fowardButton_Click(object sender, EventArgs e)
        {
            this.wb.GoForward();
        }

        private void recButton_Click(object sender, EventArgs e)
        {
            Context.IsRecoding = !Context.IsRecoding;
        }
    }
}
