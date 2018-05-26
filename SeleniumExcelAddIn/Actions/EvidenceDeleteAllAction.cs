// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class EvidenceDeleteAllAction : IAction
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
                return false;
            }
        }

        public void Execute()
        {
            if (!MessageDialog.Confirm(Properties.Resources.Action_DeleteEvidenceAll_Confirm))
            {
                return;
            }

            App.Context.GetActiveWorkbookContext().DeleteEvidenceAll();
        }
    }
}
