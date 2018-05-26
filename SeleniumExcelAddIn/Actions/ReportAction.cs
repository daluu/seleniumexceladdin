// Copyright (c) 2014 Takashi Yoshizawa

using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class ReportAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.None;
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
                this.ExecuteInternal();
            });
        }

        private void ExecuteInternal()
        {
            var workbookContext = App.Context.GetActiveWorkbookContext();
            Excel.Worksheet worksheet = this.GetReportSheet(workbookContext.Workbook);

            Excel.ListObject listObject = ListObjectHelper.AddListObject(worksheet);
            listObject.Name = "TestList";
            listObject.ListColumns[1].Name = Properties.Resources.ListColumnName_Command;
            listObject.ListColumns[1].Range.EntireColumn.AutoFit();

            ListObjectHelper.AddColumn(listObject, Properties.Resources.ReportColumnTestCase);
            ListObjectHelper.AddColumn(listObject, Properties.Resources.ReportColumnTestData);
            ListObjectHelper.AddColumn(listObject, Properties.Resources.ReportColumnResult);

            foreach (var testCase in App.Context.GetActiveWorkbookContext().TestCases)
            {
                Excel.ListRow row = ListObjectHelper.AddRow(listObject, true);
                ExcelHelper.SetText(worksheet, row.Range[1, 1], 1, testCase.DisplayName);
            }
        }

        private Excel.Worksheet GetReportSheet(Excel.Workbook workbook)
        {
            foreach (Excel.Worksheet worksheet in workbook.Worksheets)
            {
                if (worksheet.Name == Properties.Resources.Prefix_Result)
                {
                    return worksheet;
                }
            }

            Excel.Worksheet before = workbook.Worksheets[1];
            Excel.Worksheet newSheet = workbook.Worksheets.Add(before);
            newSheet.Name = Properties.Resources.Prefix_Result;
            return newSheet;
        }
    }
}
