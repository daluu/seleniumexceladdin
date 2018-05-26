// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn.Actions
{
    internal class WebDriverInternetExplorerAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.None;
            }
        }

        public bool IsChecked
        {
            get
            {
                return string.Equals(App.Context.Settings.WebDriverType, Constants.InternetExplorer, StringComparison.OrdinalIgnoreCase);
            }
        }

        public void Execute()
        {
            App.Context.Settings.WebDriverType = Constants.InternetExplorer;
            ActionManager.Update(true);
        }
    }
}
