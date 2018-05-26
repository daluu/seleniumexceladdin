// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public static class ExcelHelper
    {
        public static Excel.Worksheet WorksheetAdd(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            Excel.Worksheet target = workbook.Worksheets[workbook.Worksheets.Count];

            Excel.Worksheet worksheet = workbook.Worksheets.Add(
                Type.Missing,
                target);

            return worksheet;
        }

        public static Excel.Worksheet WorksheetActivate(Excel.Worksheet worksheet)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            ((Excel._Worksheet)worksheet).Activate();

            return worksheet;
        }

        public static Excel.Name GetName(Excel.Workbook workbook, string targetName)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }
            
            if (string.IsNullOrWhiteSpace(targetName))
            {
                throw new ArgumentNullException("targetName");
            }

            foreach (Excel.Name name in workbook.Names)
            {
                if (name.Name == targetName)
                {
                    return name;
                }
            }

            return null;
        }

        public static Excel.Hyperlink AddHyperLink(
            Excel.Worksheet srcWorksheet,
            Excel.Range srcRange,
            Excel.Worksheet dstWorksheet,
            Excel.Range dstRange)
        {
            if (null == srcWorksheet)
            {
                throw new ArgumentNullException("srcWorksheet");
            }

            if (null == srcRange)
            {
                throw new ArgumentNullException("srcRange");
            }
            
            if (null == dstWorksheet)
            {
                throw new ArgumentNullException("dstWorksheet");
            }

            if (null == dstRange)
            {
                throw new ArgumentNullException("dstRange");
            }

            string name = dstWorksheet.Name.Replace("'", "''");

            if (0 <= name.IndexOf(" "))
            {
                name = "'" + name + "'";
            }

            string address = string.Format(
                "#{0}!{1}",
                name,
                dstRange.Address);

            return srcWorksheet.Hyperlinks.Add(
                srcRange,
                address,
                Type.Missing,
                Type.Missing,
                dstWorksheet.Name);
        }

        public static Excel.Range SetText(Excel.Worksheet worksheet, int rowIndex, int columnIndex, string value)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            Excel.Range range = worksheet.Cells[rowIndex, columnIndex];
            range.NumberFormatLocal = "@";
            range.Value = value;

            return range;
        }

        public static Excel.Range SetText(Excel.Worksheet worksheet, int rowIndex, int columnIndex, string value, bool wrapText)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            Excel.Range range = worksheet.Cells[rowIndex, columnIndex];
            range.NumberFormatLocal = "@";
            range.WrapText = wrapText;
            range.Value = value;

            return range;
        }

        public static Excel.Range SetColor(Excel.Range range, int color)
        {
            if (null == range)
            {
                throw new ArgumentNullException("range");
            }

            if (color == Constants.ColorNone)
            {
                range.Interior.Pattern = Excel.XlPattern.xlPatternNone;
            }
            else
            {
                range.Interior.Pattern = Excel.XlPattern.xlPatternSolid;
                range.Interior.Color = color;
            }

            return range;
        }

        public static Excel.Comment AddComment(Excel.Range range, string message)
        {
            if (null != range.Comment)
            {
                range.Comment.Delete();
            }

            return range.AddComment("SeleniumExcelAddIn:\n" + message);
        }
    }
}
