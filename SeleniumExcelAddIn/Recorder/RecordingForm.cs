using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;

namespace SeleniumExcelAddIn.Recorder
{
    public partial class RecordingForm : Form
    {
        public RecordingForm()
        {
            InitializeComponent();
        }

        public CommandRecorder Recorder
        {
            get;
            set;
        }

        private void RecordingForm_Load(object sender, EventArgs e)
        {
            var ie = IE.ActiveBrowser;
            this.Left = ie.Left + (ie.Width / 2) - (this.Width / 2);
            this.Top = Math.Max(1, ie.Top + 1);
            this.Height = 25;
        }

        private void startButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private string SelectedText
        {
            get
            {
                var doc = IE.ActiveDocument;

                if (doc.selection.type == "Text")
                {
                    dynamic range = doc.selection.createRange();
                    var text = range.text;

                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        return text;
                    }
                }

                return null;
            }
        }

        private void assertTextPresentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Recorder.OnCommandRecording("assertTextPresent", this.SelectedText);
        }

        private void toolStripDropDownButton1_DropDownOpening(object sender, EventArgs e)
        {
            var isSelectedText = !string.IsNullOrWhiteSpace(this.SelectedText);

            this.assertTextToolStripMenuItem.Enabled = isSelectedText;
            this.assertNotTextToolStripMenuItem.Enabled = isSelectedText;
            this.assertTextPresentToolStripMenuItem.Enabled = isSelectedText;
            this.assertTextNotPresentToolStripMenuItem.Enabled = isSelectedText;
        }

        private void assertTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = IE.ActiveDocument;
            this.Recorder.OnCommandRecording("assertTitle", doc.title);
        }

        private void assertNotTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = IE.ActiveDocument;
            this.Recorder.OnCommandRecording("assertNotTitle", doc.title);
        }

        private void assertLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = IE.ActiveDocument;
            this.Recorder.OnCommandRecording("assertLocation", doc.url);
        }

        private void assertNotLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = IE.ActiveDocument;
            this.Recorder.OnCommandRecording("assertNotLocation", doc.url);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doc = IE.ActiveDocument;
            this.Recorder.OnCommandRecording("open", doc.url);
        }
    }
}
