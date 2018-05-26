using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Stratman.Windows.Forms.TitleBarTabs;

namespace SeleniumExcelAddIn.AdvancedWebBrowserApp
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new AppForm());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppForm appForm = new AppForm();

            appForm.Tabs.Add(
                new TitleBarTab(appForm)
                {
                    Content = new SeleniumExcelAddIn.AdvancedWebBrowser.AdvancedWebBrowserForm()
                    {
                        Text = "New Tab"
                    }
                });

            appForm.SelectedTabIndex = 0;

            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(appForm);

            Application.Run(applicationContext);

        }
    }
}
