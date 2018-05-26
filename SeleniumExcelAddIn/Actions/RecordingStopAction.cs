// Copyright (c) 2014 Takashi Yoshizawa

using System.Diagnostics;

namespace SeleniumExcelAddIn.Actions
{
    internal class RecordingStopAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.WorkbookEditable;
            }
        }

        public bool IsChecked
        {
            get
            {
                return false == App.Context.IsRecording;
            }
        }

        public void Execute()
        {
            App.Context.IsRecording = false;
        }
    }
}
