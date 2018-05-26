// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.ActionValidators
{
    internal class ListRowActionValidator : IActionValidator
    {
        public string Validate()
        {
            if (0 == App.Excel.Worksheets.Count)
            {
                return Properties.Resources.ActionValidator_WorksheetNotPresent;
            }

            var sheet = App.Excel.ActiveSheet;

            if (null == sheet)
            {
                return Properties.Resources.ActionValidator_WorksheetNotPresent;
            }

            var listObject = sheet.GetListObject();

            if (null == listObject)
            {
                return Properties.Resources.ActionValidator_NoSuchListObject;
            }

            var cell = App.Excel.ActiveCell;
            int row = cell.Row;
            int start = listObject.DataBodyRange.Row;
            int end = start + listObject.ListRows.Count;
            int index = row - start + 1;

            if (row < start || end < row)
            {
                return Properties.Resources.ActionValidator_NotListObjectDataBody;
            }

            return string.Empty;
        }
    }
}
