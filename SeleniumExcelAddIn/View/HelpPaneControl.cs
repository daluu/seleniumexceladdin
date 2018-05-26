// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Linq;
using System.Windows.Forms;

namespace SeleniumExcelAddIn.View
{
    public partial class HelpPaneControl : UserControl
    {
        public HelpPaneControl()
        {
            InitializeComponent();
        }

        private void DocPaneControl_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.AddRange(TestCommandFactory.GetCommandNames().ToArray());

            this.webBrowser1.Navigate("about:blank");
            this.webBrowser1.Navigate(Properties.Resources.HelpUrl);
#if DEBUG
            this.webBrowser1.IsWebBrowserContextMenuEnabled = true;
#endif
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CommandName = this.comboBox1.Text;
        }

        public string CommandName
        {
            get
            {
                return this.comboBox1.Text;
            }

            set
            {
                this.comboBox1.Text = value;
                var urlString = Properties.Resources.HelpUrl + "#" + value;
                this.webBrowser1.Navigate(urlString);
            }
        }
    }
}
