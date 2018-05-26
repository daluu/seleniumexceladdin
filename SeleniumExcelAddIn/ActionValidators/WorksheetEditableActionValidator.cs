// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.ActionValidators
{
    internal class WorksheetEditableActionValidator : IActionValidator
    {
        public string Validate()
        {
            if (0 == App.Excel.Workbooks.Count)
            {
                return Properties.Resources.ActionValidator_WorkbookNotPresent;
            }

            Excel.Worksheet excelSheet = App.Excel.ActiveSheet;

            if (excelSheet.ProtectContents)
            {
                return Properties.Resources.ActionValidator_WorkbookReadonly;
            }

            return string.Empty;
        }
    }
}
