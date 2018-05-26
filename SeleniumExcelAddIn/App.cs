// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public static class App
    {
        static App()
        {
            DataDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Properties.Resources.AppDir);

            if (!Directory.Exists(DataDir))
            {
                Directory.CreateDirectory(DataDir);
            }

            TempDir = Path.Combine(
                DataDir,
                "Temp");

            if (!Directory.Exists(TempDir))
            {
                Directory.CreateDirectory(TempDir);
            }

            Context = new AppContext();

            MessageDialog.Title = Properties.Resources.AppTitle;
        }

        public static IntPtr MainWindowHandle
        {
            get
            {
                return (IntPtr)Excel.Hwnd;
            }
        }

        public static AppContext Context
        {
            get;
            private set;
        }

        private static Excel.Application excelApp;

        public static Excel.Application Excel
        {
            get
            {
                return excelApp;
            }

            set
            {
                excelApp = value;

                Version version = new Version(excelApp.Version);

                switch (version.Major)
                {
                    case 14:
                        OfficeVersion = SeleniumExcelAddIn.OfficeVersion.v2010;
                        break;

                    case 15:
                        OfficeVersion = SeleniumExcelAddIn.OfficeVersion.v2013;
                        break;

                    default:
                        OfficeVersion = SeleniumExcelAddIn.OfficeVersion.Unknown;
                        break;
                }
            }
        }

        public static OfficeVersion OfficeVersion
        {
            get;
            private set;
        }

        public static Microsoft.Office.Tools.CustomTaskPaneCollection TaskPanes
        {
            get;
            set;
        }

        public static string DataDir
        {
            get;
            private set;
        }

        public static string TempDir
        {
            get;
            private set;
        }
    }
}
