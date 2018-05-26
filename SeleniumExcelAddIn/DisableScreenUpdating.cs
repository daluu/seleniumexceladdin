// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn
{
    internal static class DisableScreenUpdating
    {
        public static void Invoke(Action action)
        {
            var tmp = App.Excel.ScreenUpdating;

            try
            {
                App.Excel.ScreenUpdating = false;
                action();
            }
            finally
            {
                App.Excel.ScreenUpdating = tmp;
            }
        }
    }
}
