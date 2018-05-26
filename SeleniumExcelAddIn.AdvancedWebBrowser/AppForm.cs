using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stratman.Windows.Forms.TitleBarTabs;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    public partial class AppForm : TitleBarTabs
    {
        public AppForm()
        {
            InitializeComponent();
            AeroPeekEnabled = false;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new AppChildForm()
                {
                    Text = "New Tab"
                }
            };
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
        }
    }
}
