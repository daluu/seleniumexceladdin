// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.IO;
using log4net;
using log4net.Config;

namespace SeleniumExcelAddIn
{
    public static class Log
    {
        static Log()
        {
#if DEBUG
            string config = Properties.Resources.log4net_debug;
#else
            string config = Properties.Resources.log4net_release;
#endif
            string dir = Path.Combine(App.DataDir, "Logs");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string path = Path.Combine(App.DataDir, "log4net.config");

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
