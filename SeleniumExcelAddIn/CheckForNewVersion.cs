// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Windows.Forms;

namespace SeleniumExcelAddIn
{
    internal static class CheckForNewVersion
    {
#if DEBUG
        private const int CheckDays = 1;
        private const string VersionCheckUrl = "http://selenium-excel-addin.jpn.org/version-debug.txt";
#else
        private const int CheckDays = 10;
        private const string VersionCheckUrl = "http://selenium-excel-addin.jpn.org/version.txt";
#endif

        private static NotifyIcon notifyIcon = new NotifyIcon()
        {
            Icon = Properties.Resources.app_icon,
            Text = Properties.Resources.AppTitle,
        };

        public static void Dispose()
        {
            notifyIcon.Dispose();
        }

        public static void Check()
        {
            if ((DateTime.Now - App.Context.Settings.LastestUpdateNotify).Days <= CheckDays)
            {
                return;
            }

            try
            {
                WebClient wc = new WebClient();
                wc.DownloadStringCompleted += wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(VersionCheckUrl));
            }
            catch (Exception ex)
            {
                Log.Logger.Warn(ex);
            }
        }

        private static void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                Log.Logger.DebugFormat("Check for New Version = {0}", e.Result);

                SynchronizationDispatcher.Invoke(() =>
                {
                    CheckInternal(e.Result);
                });
            }
            catch (Exception ex)
            {
                Log.Logger.Warn(ex);
            }

        }

        private static void CheckInternal(string latestVersionString)
        {
            App.Context.Settings.LastestUpdateNotify = DateTime.Now;
            Version latestVersion;

            if (!Version.TryParse(latestVersionString, out latestVersion))
            {
                return;
            }

            if (latestVersion <= App.Context.Version)
            {
                return;
            }

            var msg = string.Format(
                CultureInfo.CurrentCulture,
                Properties.Resources.CheckNewVersion1,
                latestVersion);

            notifyIcon.Visible = true;
            notifyIcon.Click += notifyIcon_Click;
            notifyIcon.BalloonTipClicked += icon_BalloonTipClicked;
            notifyIcon.ShowBalloonTip(
                1000 * 60,
                Properties.Resources.AppTitle,
                msg,
                ToolTipIcon.Info);
        }

        static void notifyIcon_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.Homepage);
        }

        private static void icon_BalloonTipClicked(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.Homepage);
        }
    }
}
