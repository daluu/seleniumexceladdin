// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class EvidenceRecordPassedAction : IAction
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
                return App.Context.Settings.PassedEvidenceRecord;
            }
        }

        public void Execute()
        {
            App.Context.Settings.PassedEvidenceRecord = !App.Context.Settings.PassedEvidenceRecord;
            ActionManager.Update();
        }
    }
}
