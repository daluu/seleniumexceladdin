// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public static class ListRowHelper
    {
        public enum ColumnIndex : int
        {
            None = 0,
            Command = 1,
            Target = 2,
            Value = 3,
            Result = 4,
            Error = 5,
            Evidence = 6
        }

        public static string Get(Excel.ListRow listRow, int columnIndex)
        {
            if (null == listRow)
            {
                throw new ArgumentNullException("listRow");
            }

            Excel.Range range = listRow.Range[1, columnIndex];
            string text = range.Text;

            return text.Trim();
        }

        public static string Get(Excel.ListRow listRow, ColumnIndex columnIndex)
        {
            if (null == listRow)
            {
                throw new ArgumentNullException("listRow");
            }

            Excel.Range range = listRow.Range[1, columnIndex];
            string text = range.Text;

            return text.Trim();
        }

        public static Excel.Range Set(Excel.ListRow listRow, ColumnIndex columnIndex, string value)
        {
            if (null == listRow)
            {
                throw new ArgumentNullException("listRow");
            }

            Excel.Range range = listRow.Range[1, columnIndex];

            if (string.IsNullOrWhiteSpace(value))
            {
                range.Clear();
                range.Formula = string.Empty;
            }
            else
            {
                range.NumberFormatLocal = "@";
                range.Value = value;
                range.WrapText = true;
            }

            return range;
        }
    }
}
