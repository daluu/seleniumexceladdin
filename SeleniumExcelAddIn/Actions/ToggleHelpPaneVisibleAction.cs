// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn.Actions
{
    internal class ToggleHelpPaneVisibleAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.WorkbookPresent;
            }
        }

        public bool IsChecked
        {
            get
            {
                var activeWindowContext = App.Context.GetActiveWindowContext();

                if (null == activeWindowContext)
                {
                    Log.Logger.Warn("activeWindowContext is null.");
                    return false;
                }

                return activeWindowContext.HelpPaneVisible;
            }
        }

        public void Execute()
        {
            var activeWindowContext = App.Context.GetActiveWindowContext();

            if (null == activeWindowContext)
            {
                Log.Logger.Warn("activeWindowContext is null.");
                return;
            }

            activeWindowContext.HelpPaneVisible = !activeWindowContext.HelpPaneVisible;
        }
    }
}
