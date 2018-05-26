namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
	partial class AdvancedWebBrowserForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.advancedWebBrowserAddressBar1 = new SeleniumExcelAddIn.AdvancedWebBrowser.AdvancedWebBrowserAddressBar();
            this.advancedWebBrowser1 = new SeleniumExcelAddIn.AdvancedWebBrowser.AdvancedWebBrowser();
            this.advancedWebBrowserStatusBar1 = new SeleniumExcelAddIn.AdvancedWebBrowser.AdvancedWebBrowserStatusBar();
            this.SuspendLayout();
            // 
            // advancedWebBrowserAddressBar1
            // 
            this.advancedWebBrowserAddressBar1.AdvancedWebBrowser = this.advancedWebBrowser1;
            this.advancedWebBrowserAddressBar1.AutoSize = true;
            this.advancedWebBrowserAddressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.advancedWebBrowserAddressBar1.Location = new System.Drawing.Point(0, 0);
            this.advancedWebBrowserAddressBar1.MinimumSize = new System.Drawing.Size(100, 0);
            this.advancedWebBrowserAddressBar1.Name = "advancedWebBrowserAddressBar1";
            this.advancedWebBrowserAddressBar1.Size = new System.Drawing.Size(644, 26);
            this.advancedWebBrowserAddressBar1.TabIndex = 1;
            // 
            // advancedWebBrowser1
            // 
            this.advancedWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedWebBrowser1.Location = new System.Drawing.Point(0, 26);
            this.advancedWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.advancedWebBrowser1.Name = "advancedWebBrowser1";
            this.advancedWebBrowser1.Size = new System.Drawing.Size(644, 204);
            this.advancedWebBrowser1.TabIndex = 2;
            this.advancedWebBrowser1.TextSize = 2;
            // 
            // advancedWebBrowserStatusBar1
            // 
            this.advancedWebBrowserStatusBar1.AdvancedWebBrowser = this.advancedWebBrowser1;
            this.advancedWebBrowserStatusBar1.AutoSize = true;
            this.advancedWebBrowserStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.advancedWebBrowserStatusBar1.Location = new System.Drawing.Point(0, 230);
            this.advancedWebBrowserStatusBar1.MinimumSize = new System.Drawing.Size(100, 0);
            this.advancedWebBrowserStatusBar1.Name = "advancedWebBrowserStatusBar1";
            this.advancedWebBrowserStatusBar1.Size = new System.Drawing.Size(644, 23);
            this.advancedWebBrowserStatusBar1.TabIndex = 0;
            // 
            // AppChildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 253);
            this.Controls.Add(this.advancedWebBrowser1);
            this.Controls.Add(this.advancedWebBrowserAddressBar1);
            this.Controls.Add(this.advancedWebBrowserStatusBar1);
            this.Name = "AppChildForm";
            this.Text = "AppChildForm";
            this.Load += new System.EventHandler(this.AppChildForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private AdvancedWebBrowserStatusBar advancedWebBrowserStatusBar1;
        private AdvancedWebBrowserAddressBar advancedWebBrowserAddressBar1;
        private AdvancedWebBrowser advancedWebBrowser1;
	}
}