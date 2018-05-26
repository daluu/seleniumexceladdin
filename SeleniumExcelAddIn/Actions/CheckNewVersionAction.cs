// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Net;

namespace SeleniumExcelAddIn.Actions
{
    internal class CheckNewVersionAction : IAction
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
            CheckForNewVersion.Check();
        }
    }
}
