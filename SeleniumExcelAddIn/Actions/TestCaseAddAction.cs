// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class TestCaseAddAction : IAction
    {
        private const int DefaultRowCount = 20;
        private const string SeleniumCommandWorksheetName = "SeleniumCommands";
        private const string SeleniumCommandVersion = "CommandVersion";

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
            DisableScreenUpdating.Invoke(() =>
            {
                var workbookContext = App.Context.GetActiveWorkbookContext();
                Excel.Worksheet before = workbookContext.Workbook.ActiveSheet;
                Excel.Worksheet worksheet = this.ExecuteInternal(workbookContext.Workbook);
                App.Context.Update();
                ExcelHelper.WorksheetActivate(before);
                ExcelHelper.WorksheetActivate(worksheet);
           });
        }

        internal Excel.Worksheet ExecuteInternal(Excel.Workbook workbook)
        {
            this.AddCommandWorkbookIfNotExists(workbook);

            Excel.Worksheet worksheet = ExcelHelper.WorksheetAdd(workbook);
            string name = ListObjectHelper.NewTestCaseName(workbook);
            worksheet.Name = name;

            Excel.ListObject listObject = ListObjectHelper.AddListObject(worksheet);
            listObject.Name = name;
            listObject.ListColumns[1].Name = Properties.Resources.ListColumnName_Command;
            listObject.ListColumns[1].Range.EntireColumn.AutoFit();

            ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Target);
            ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Value);
            ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Result);
            ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_ErrorMessage);
            ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Evidence);

            ListObjectHelper.AddRows(listObject, DefaultRowCount);

            #region

            Excel.Range range = listObject.ListColumns[1].Range;

            range.Validation.Add(
                Excel.XlDVType.xlValidateList,
                Excel.XlDVAlertStyle.xlValidAlertWarning,
                Excel.XlFormatConditionOperator.xlBetween,
                "=" + SeleniumCommandWorksheetName + "!$A:$A");

            range.Validation.IgnoreBlank = true;
            range.Validation.InCellDropdown = true;

            #endregion

            ListObjectHelper.SelectCell(listObject, 2, 1);

            return worksheet;
        }

        private void AddCommandWorkbookIfNotExists(Excel.Workbook workbook)
        {
            Excel.Worksheet worksheet = this.GetCommandWorksheet(workbook);

            if (null == worksheet)
            {
                worksheet = ExcelHelper.WorksheetAdd(workbook);
                worksheet.Name = SeleniumCommandWorksheetName;
            }

            var versionString = ExcelWorksheetCustomPropertyAccessor.Get(worksheet, SeleniumCommandVersion);
            var commandUpdating = true;

            if (!string.IsNullOrWhiteSpace(versionString))
            {
                var version = new Version(versionString);

                if (App.Context.Version <= version)
                {
                    commandUpdating = false;
                }
            }

#if DEBUG
            commandUpdating = true;
#endif

            if (!commandUpdating)
            {
                return;
            }

            ExcelWorksheetCustomPropertyAccessor.Set(worksheet, SeleniumCommandVersion, App.Context.Version.ToString());
            var commands = TestCommandFactory.GetCommandNames();

            for (int i = 0; i < commands.Count(); i++)
            {
                string command = commands.ElementAt(i).Trim();
                worksheet.Cells[i + 1, 1] = command.Trim();
            }

            worksheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;
        }

        private Excel.Worksheet GetCommandWorksheet(Excel.Workbook workbook)
        {
            foreach (Excel.Worksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == SeleniumCommandWorksheetName)
                {
                    return worksheet;
                }
            }

            return null;
        }
    }
}
