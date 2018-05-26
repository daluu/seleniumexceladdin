using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Stratman.Windows.Forms.TitleBarTabs;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AppForm());

            Log.Logger.Debug("STATR");
            ToolStripManager.Renderer = new CustomToolStripRenderer(SystemColors.Control);

            AppForm appForm = new AppForm();

            appForm.Tabs.Add(
                new TitleBarTab(appForm)
                {
                    Content = new AppChildForm()
                    {
                        Text = "New Tab"
                    }
                });

            appForm.SelectedTabIndex = 0;

            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(appForm);

            Application.Run(applicationContext); 
 //           var app = new App();
 //           app.Run(args);
        }
    }
}
