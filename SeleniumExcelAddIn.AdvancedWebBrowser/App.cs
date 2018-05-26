using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Threading;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    internal class App : WindowsFormsApplicationBase
    {
        private static string dataDir;

        public static string DataDir
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref dataDir, () =>
                {
                    var dir = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                        "SeleniumExcelAddIn",
                        "AdvancedWebBrowser");

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                    return dir;
                });
            }
        }

        public App()
            : base()
        {
            this.EnableVisualStyles = true;
            this.IsSingleInstance = true;
            this.MainForm = new AppForm();
            this.StartupNextInstance += new StartupNextInstanceEventHandler(this.App_StartupNextInstance);
        }

        private void App_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            e.BringToForeground = true;
        }
    }
}
