// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn
{
    internal static class DisableDisplayAlert
    {
        public static void Invoke(Action action)
        {
            var tmp = App.Excel.DisplayAlerts;

            try
            {
                App.Excel.DisplayAlerts = false;
                action();
            }
            finally
            {
                App.Excel.DisplayAlerts = tmp;
            }
        }
    }
}
