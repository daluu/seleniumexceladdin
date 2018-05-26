// Copyright (c) 2014 Takashi Yoshizawa

using System.Diagnostics;

namespace SeleniumExcelAddIn.Actions
{
    internal class HelpAction : IAction
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
                return false;
            }
        }

        public void Execute()
        {
            Process.Start(Properties.Resources.Homepage);
        }
    }
}
