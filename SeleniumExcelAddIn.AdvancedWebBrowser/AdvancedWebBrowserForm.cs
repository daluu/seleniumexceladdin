using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	public partial class AdvancedWebBrowserForm: Form
	{
		public AdvancedWebBrowserForm()
		{
			InitializeComponent();
		}

        private void AppChildForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.advancedWebBrowser1.ScriptErrorsSuppressed = true;
            this.advancedWebBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.advancedWebBrowser1.Navigate("about:blank");
            this.advancedWebBrowser1.DocumentTitleChanged += new EventHandler(advancedWebBrowser1_DocumentTitleChanged);
            this.advancedWebBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(advancedWebBrowser1_DocumentCompleted);
        }

        void advancedWebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        void advancedWebBrowser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            this.Text = this.advancedWebBrowser1.DocumentTitle;
        }
	}
}
