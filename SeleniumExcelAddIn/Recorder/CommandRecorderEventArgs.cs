// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.Recorder
{
    public class CommandRecorderEventArgs : EventArgs
    {
        public CommandRecorderEventArgs(string command, string target, string value)
        {
            this.Command = command;
            this.Target = target;
            this.Value = value;
        }

        public string Command
        {
            get;
            private set;
        }

        public string Target
        {
            get;
            private set;
        }

        public string Value
        {
            get;
            private set;
        }
    }
}
