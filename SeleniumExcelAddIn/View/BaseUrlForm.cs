using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeleniumExcelAddIn.View
{
    public partial class BaseUrlForm : Form
    {
        public BaseUrlForm()
        {
            this.InitializeComponent();
        }

        private void BaseUrlForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = this.textBox1;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            string value = this.textBox1.Text;

            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            Uri url;

            if (!Uri.TryCreate(value, UriKind.Absolute, out url))
            {
                this.errorProvider1.SetError(this.textBox1, Properties.Resources.BaseUrlInvalid);
                e.Cancel = true;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
        }

        public string BaseUrl
        {
            get
            {
                return this.textBox1.Text;
            }

            set
            {
                this.textBox1.Text = value;
            }
        }

        private void BaseUrlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (!this.ValidateChildren())
                {
                    e.Cancel = true;
                }
            }
            else
            {
                this.AutoValidate = AutoValidate.Disable;
            }
        }

        private void BaseUrlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
