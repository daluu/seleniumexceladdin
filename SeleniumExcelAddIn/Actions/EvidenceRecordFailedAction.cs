// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class EvidenceRecordFailedAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.WorkbookPresent | ActionFlags.WorkbookEditable;
            }
        }

        public bool IsChecked
        {
            get
            {
                return App.Context.Settings.FailedEvidenceRecord;
            }
        }

        public void Execute()
        {
            App.Context.Settings.FailedEvidenceRecord = !App.Context.Settings.FailedEvidenceRecord;
            ActionManager.Update();
        }
    }
}
