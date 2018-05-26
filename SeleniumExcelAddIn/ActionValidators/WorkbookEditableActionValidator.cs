// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn.ActionValidators
{
    internal class WorkbookEditableActionValidator : IActionValidator
    {
        public string Validate()
        {
            if (0 == App.Excel.Workbooks.Count)
            {
                return Properties.Resources.ActionValidator_WorkbookNotPresent;
            }

            var workbook = App.Excel.ActiveWorkbook;

            if (workbook.ReadOnly)
            {
                return Properties.Resources.ActionValidator_WorkbookReadonly;
            }

            if (workbook.ProtectStructure)
            {
                return Properties.Resources.ActionValidator_WorkbookEditable;
            }

            return string.Empty;
        }
    }
}
