// Copyright (c) 2014 Takashi Yoshizawa

using System.Diagnostics;

namespace SeleniumExcelAddIn.Actions
{
    internal class RecordingAction : IAction
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
                return App.Context.IsRecording;
            }
        }

        public void Execute()
        {
            var workbookContext = App.Context.GetActiveWorkbookContext();
            var activeTestCase = workbookContext.GetActiveTestCase();

            if (null == activeTestCase)
            {
                new TestCaseAddAction().Execute();
            }

            App.Context.IsRecording = !App.Context.IsRecording;
        }
    }
}
