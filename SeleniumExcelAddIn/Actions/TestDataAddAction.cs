// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class TestDataAddAction : IAction
    {
        private static readonly int DEFAULT_ROW_COUNT = 20;

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
            DisableScreenUpdating.Invoke(this.ExecuteInternal);
            App.Context.Update();
        }

        private void ExecuteInternal()
        {
            var workbookContext = App.Context.GetActiveWorkbookContext();

            Excel.Workbook workbook = workbookContext.Workbook;
            Excel.Worksheet worksheet = ExcelHelper.WorksheetAdd(workbook);
            ExcelHelper.WorksheetActivate(worksheet);

            string name = ListObjectHelper.NewTestDataName(workbook);
            worksheet.Name = name;

            Excel.ListObject listObject = ListObjectHelper.AddListObject(worksheet);
            listObject.Name = name;

            listObject.ListColumns[1].Name = "Column1";
            listObject.ListColumns[1].Range.EntireColumn.AutoFit();

            for (int i = 2; i < 10; i++)
            {
                Excel.ListColumn listColumn = listObject.ListColumns.Add();

                listColumn.Name = string.Format(
                    CultureInfo.CurrentCulture,
                    "Column{0}",
                    i);

                listColumn.Range.EntireColumn.AutoFit();
            }

            ListObjectHelper.AddRows(listObject, DEFAULT_ROW_COUNT, false);
            ListObjectHelper.SelectCell(listObject, 2, 1);
        }
    }
}
