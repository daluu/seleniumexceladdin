// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public static class ListObjectHelper
    {
        private const int DEFAULT_COLUMN_WIDTH = 30;

        public static Excel.ListRow GetEmptyRow(Excel.ListObject listObject)
        {
            Excel.ListRow theListRow = null;

            ForEach(listObject, (listRow) =>
            {
                var s = ListRowHelper.Get(listRow, ListRowHelper.ColumnIndex.Command);
                if (string.IsNullOrWhiteSpace(s))
                {
                    theListRow = listRow;
                    return false;
                }

                return true;
            });

            if (null != theListRow)
            {
                return theListRow;
            }

            return ListObjectHelper.AddRow(listObject, true);
        }

        public static Excel.Range SelectCell(Excel.ListObject listObject, int rowIndex, int columnIndex)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            if (columnIndex < 1)
            {
                throw new ArgumentOutOfRangeException(columnIndex.ToString());
            }

            if (rowIndex < 2)
            {
                throw new ArgumentOutOfRangeException(rowIndex.ToString());
            }

            Excel.Range range = listObject.Range[rowIndex, columnIndex];
            range.Select();

            return range;
        }

        public static Excel.ListObject SelectRow(Excel.ListObject listObject, int rowIndex)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            if (rowIndex < 2)
            {
                throw new ArgumentOutOfRangeException(rowIndex.ToString());
            }

            listObject.ListRows[rowIndex].Range.Select();

            return listObject;
        }

        public static Excel.ListObject AddListObject(Excel.Worksheet worksheet)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            Excel.ListObject listObject = worksheet.ListObjects.AddEx(
                Excel.XlListObjectSourceType.xlSrcRange,
                Type.Missing,
                Type.Missing,
                Excel.XlYesNoGuess.xlYes,
                Type.Missing,
                Type.Missing);

            listObject.ShowAutoFilter = false;

            return listObject;
        }

        public static Excel.ListColumn AddColumn(Excel.ListObject listObject, string columnName)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentNullException("columnName");
            }

            Excel.ListColumn listColumn = listObject.ListColumns.Add();
            listColumn.Name = columnName;
            listColumn.Range.EntireColumn.AutoFit();

            return listColumn;
        }

        public static Excel.ListObject AddRows(Excel.ListObject listObject, int count, bool isTextFormat = true)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            for (int i = 0; i < count; i++)
            {
                AddRow(listObject, isTextFormat);
            }

            return listObject;
        }

        public static Excel.ListRow AddRow(Excel.ListObject listObject, bool isTextFormat = true)
        {
            Excel.ListRow listRow = listObject.ListRows.AddEx();

            if (isTextFormat)
            {
                listRow.Range.NumberFormatLocal = "@";
            }

            listRow.Range.ColumnWidth = DEFAULT_COLUMN_WIDTH;
            listRow.Range.WrapText = true;

            return listRow;
        }

        public static string NewTestCaseName(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            var scenarioList = GetTestCases(workbook);
            int number = scenarioList.Count();

            while (true)
            {
                number++;

                string name = string.Format(
                    CultureInfo.CurrentCulture,
                    "{0}{1}",
                    Properties.Resources.Prefix_Scenario,
                    number);
#if DEBUG
                Log.Logger.DebugFormat("{0}", name);
#endif

                if (scenarioList.Where(i => i.Name == name).Count() == 0)
                {
                    if (null == ExcelHelper.GetName(workbook, name))
                    {
                        return name;
                    }
                }
            }
        }

        public static string NewTestDataName(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            var dataList = GetDataList(workbook);
            int number = dataList.Count();

            while (true)
            {
                number++;

                string name = string.Format(
                    CultureInfo.CurrentCulture,
                    "{0}{1}",
                    Properties.Resources.Prefix_Data,
                    number);

                if (dataList.Where(i => i.Name == name).Count() == 0)
                {
                    if (null == ExcelHelper.GetName(workbook, name))
                    {
                        return name;
                    }
                }
            }
        }

        public static Excel.Worksheet GetWorksheet(Excel.ListObject listObject)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            return (Excel.Worksheet)listObject.Parent;
        }

        public static string GetWorksheetName(Excel.ListObject listObject)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            return GetWorksheet(listObject).Name;
        }

        public static string GetTestDataRef(Excel.ListObject listObject)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            return listObject.Comment;
        }

        public static IEnumerable<Excel.ListObject> GetTestCases(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            List<Excel.ListObject> list = new List<Excel.ListObject>();

            foreach (Excel.Worksheet worksheet in workbook.Worksheets)
            {
                list.AddRange(GetTestCases(worksheet));
            }

            return list;
        }

        public static IEnumerable<Excel.ListObject> GetTestCases(Excel.Worksheet worksheet)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            List<Excel.ListObject> list = new List<Excel.ListObject>();

            foreach (Excel.ListObject listObject in worksheet.ListObjects)
            {
                //#if DEBUG
                //                Log.Logger.DebugFormat("listObject.Name = {0}, {1}", listObject.Name, listObject.DisplayName);
                //#endif
                if (listObject.Name.StartsWith(Properties.Resources.Prefix_Scenario, StringComparison.Ordinal))
                {
                    list.Add(listObject);
                }
            }

            return list;
        }

        public static Excel.ListObject GetByName(Excel.Workbook workbook, string listObjectName)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(listObjectName))
            {
                throw new ArgumentNullException("listObjectName");
            }

            foreach (Excel.Worksheet worksheet in workbook.Worksheets)
            {
                foreach (Excel.ListObject listObject in worksheet.ListObjects)
                {
                    if (listObject.Name == listObjectName)
                    {
                        return listObject;
                    }
                }
            }

            return null;
        }

        public static IEnumerable<Excel.ListObject> GetDataList(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            List<Excel.ListObject> list = new List<Excel.ListObject>();

            foreach (Excel.Worksheet worksheet in workbook.Worksheets)
            {
                list.AddRange(GetDataList(worksheet));
            }

            return list;
        }

        public static IEnumerable<Excel.ListObject> GetDataList(Excel.Worksheet worksheet)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            List<Excel.ListObject> list = new List<Excel.ListObject>();

            foreach (Excel.ListObject listObject in worksheet.ListObjects)
            {
                if (listObject.Name.StartsWith(Properties.Resources.Prefix_Data, StringComparison.Ordinal))
                {
                    list.Add(listObject);
                }
            }

            return list;
        }

        public static void ForEach(Excel.ListObject listObject, Func<Excel.ListRow, bool> action)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            int count = listObject.ListRows.Count;

            for (int i = 1; i <= count; i++)
            {
                Excel.ListRow listRow = listObject.ListRows[i];

                if(!action(listRow))
                {
                    break;
                };
            }
        }
    }
}
