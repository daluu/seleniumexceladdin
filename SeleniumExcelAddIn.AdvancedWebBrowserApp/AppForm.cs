using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stratman.Windows.Forms.TitleBarTabs;

namespace SeleniumExcelAddIn.AdvancedWebBrowserApp
{
    public partial class AppForm : TitleBarTabs
    {
        public AppForm()
        {
            InitializeComponent();

            if (this.DesignMode)
            {
                return;
            }

            this.AeroPeekEnabled = false;
            this.TabRenderer = new ChromeTabRenderer(this);
            //Icon = Resources.DefaultIcon;
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new SeleniumExcelAddIn.AdvancedWebBrowser.AdvancedWebBrowserForm
                {
                    Text = "New Tab"
                },
                Caption = "FooVar",
            };
        }
    }
}
