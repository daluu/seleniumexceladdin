// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace SeleniumExcelAddIn.View
{
    public partial class TestRunForm : Form
    {
        private TestRunner runner = new TestRunner();

        public TestRunForm()
        {
            InitializeComponent();
        }

        public TestContextImpl TestContext
        {
            get;
            set;
        }

        private void TestRunForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.progressBar1.DataBindings.Add("Value", this.runner.Progress, "Percentage");
            this.label2.DataBindings.Add("Text", this.runner.Progress, "RemainingTimeString");
            this.label1.DataBindings.Add("Text", this.runner.Progress, "Data");
        }

        private void TestRunForm_Shown(object sender, EventArgs e)
        {
            this.runner.Run(this.TestContext).ContinueWith((b) =>
            {
                this.Close();
            }, SynchronizationDispatcher.TaskScheduler);
        }

        private void TestRunForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (this.runner.Status)
            {
                case TaskStatus.Running:
                case TaskStatus.WaitingForActivation:
                case TaskStatus.WaitingForChildrenToComplete:
                case TaskStatus.WaitingToRun:
                    this.runner.Pause();
                    e.Cancel = !MessageDialog.Confirm(Properties.Resources.CancelTestRun);
                    this.runner.Resume();
                    break;
            }
        }

        private void TestRunForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.runner.Cancel();
        }
    }
}
