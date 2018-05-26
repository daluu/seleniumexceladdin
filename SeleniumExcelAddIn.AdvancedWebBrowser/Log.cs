// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.IO;
using log4net;
using log4net.Config;

namespace SeleniumExcelAddIn.AdvancedWebBrowser
{
    public static class Log
    {
        static Log()
        {
            string baseDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "SeleniumExcelAddIn",
                "AdvancedWebBrowser");

#if DEBUG
            string config = Properties.Resources.log4net_debug;
#else
            string config = Properties.Resources.log4net_release;
#endif
            string dir = Path.Combine(baseDir, "Logs");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string path = Path.Combine(baseDir, "log4net.config");

            if (!File.Exists(path))
            {
                File.WriteAllText(path, config);
            }
#if DEBUG
            File.WriteAllText(path, config);
#endif
            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
            Logger = LogManager.GetLogger("Log");
        }

        public static ILog Logger
        {
            get;
            private set;
        }
    }
}
