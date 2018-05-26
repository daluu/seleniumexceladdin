// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class EvidenceNextAction : IAction
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
            Excel.Workbook workbook = App.Excel.ActiveWorkbook;
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            for (int i = worksheet.Index + 1; i <= workbook.Worksheets.Count; i++)
            {
                worksheet = workbook.Worksheets[i];
                if (worksheet.Name.StartsWith(Properties.Resources.Prefix_Evidence, StringComparison.Ordinal))
                {
                    ExcelHelper.WorksheetActivate(worksheet);
                    return;
                }
            }

            for (int i = 1; i <= workbook.Worksheets.Count; i++)
            {
                worksheet = workbook.Worksheets[i];
                if (worksheet.Name.StartsWith(Properties.Resources.Prefix_Evidence, StringComparison.Ordinal))
                {
                    ExcelHelper.WorksheetActivate(worksheet);
                    return;
                }
            }
        }
    }
}
