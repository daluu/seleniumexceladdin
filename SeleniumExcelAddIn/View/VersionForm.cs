// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;

namespace SeleniumExcelAddIn.View
{
    public partial class VersionForm : Form
    {
        public VersionForm()
        {
            this.InitializeComponent();
        }

        private void VersionForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.label1.Text += App.Context.Version.Major + "." + App.Context.Version.Minor;
            this.label2.Text += Constants.WebDriverVersion;
            this.linkLabel1.Text = Properties.Resources.Homepage;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Properties.Resources.Homepage);
        }
    }
}
