// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;

namespace SeleniumExcelAddIn
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("F2B19BEC-9C36-4058-90EE-05E4925A10B7")]
    public class WorkbookContext : ObservableObject, IWorkbookContext
    {
        private const string EVIDENCE_PROPERTY = "TestEvidence";
        private WorkbookContextSettings settings;

        public WorkbookContext(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            this.Workbook = workbook;
            this.Id = GetContextId(workbook);

            if (string.IsNullOrWhiteSpace(this.Id))
            {
                this.Id = Guid.NewGuid().ToString();
                ExcelWorkbookCustomPropertyAccessor.Set(workbook, ID_PROPERTY, this.Id);
            }

            this.TestCases = new TestCaseCollection();
            this.settings = WorkbookContextSettings.Load(this.Workbook);
            this.Update();
        }

        public string Id
        {
            get;
            private set;
        }

        private const string ID_PROPERTY = "WorkbookContextId";

        public Excel.Workbook Workbook
        {
            get;
            private set;
        }

        internal static string GetContextId(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            return ExcelWorkbookCustomPropertyAccessor.Get(workbook, ID_PROPERTY) ?? string.Empty;
        }

        private Dictionary<string, TestCase> oldest = new Dictionary<string, TestCase>();

        public TestCaseCollection TestCases
        {
            get;
            private set;
        }

        public void Update()
        {
#if DEBUG
            Log.Logger.DebugFormat("WorkbookContext.Update");
#endif
            var newest = new Dictionary<string, TestCase>();

            foreach (Excel.Worksheet worksheet in this.Workbook.Worksheets)
            {
                Excel.ListObject listObject = ListObjectHelper.GetTestCases(worksheet).FirstOrDefault();

                if (null == listObject)
                {
                    continue;
                }

                TestCase testCase;
                string key = listObject.Name;

                if (this.oldest.ContainsKey(key))
                {
                    testCase = this.oldest[key];
                    testCase.Update();
                }
                else
                {
                    testCase = new TestCase(this.Workbook, worksheet, listObject);
                }

                newest.Add(key, testCase);
            }

            var s1 = string.Join(",", this.oldest.Keys);
            var s2 = string.Join(",", newest.Keys);

            this.oldest = newest;

            if (s1 == s2)
            {
                return;
            }

            try
            {
                this.TestCases.RaiseListChangedEvents = false;
                this.TestCases.Clear();

                foreach (var testCase in newest.Values)
                {
                    this.TestCases.Add(testCase);
                }
            }
            finally
            {
                this.TestCases.RaiseListChangedEvents = true;
                this.TestCases.ResetBindings();
            }
        }

        public string BaseUrl
        {
            get
            {
                return this.settings.BaseUrl;
            }

            set
            {
                if (this.UpdateProperty<string>(ref this.settings.BaseUrl, value, "BaseUrl"))
                {
                    this.SaveSettings();
                }
            }
        }

        public void DeleteEvidenceAll()
        {
            DisableScreenUpdating.Invoke(() =>
            {
                foreach (var testCase in this.TestCases)
                {
                    testCase.Result = TestResult.None;
                }

                List<Excel.Worksheet> deleteTargetWorksheets = new List<Excel.Worksheet>();

                foreach (Excel.Worksheet worksheet in this.Workbook.Worksheets)
                {
                    if (null != ExcelWorksheetCustomPropertyAccessor.Get(worksheet, EVIDENCE_PROPERTY))
                    {
                        deleteTargetWorksheets.Add(worksheet);
                    }
                    else
                    {
                        Excel.ListObject listObject = ListObjectHelper.GetTestCases(worksheet).FirstOrDefault();

                        if (null != listObject)
                        {
                            listObject.DataBodyRange.Columns[ListRowHelper.ColumnIndex.Result].Clear();
                            listObject.DataBodyRange.Columns[ListRowHelper.ColumnIndex.Error].Clear();
                            listObject.DataBodyRange.Columns[ListRowHelper.ColumnIndex.Evidence].Clear();
                        }
                    }
                }

                DisableDisplayAlert.Invoke(() =>
                {
                    foreach (Excel.Worksheet worksheet in deleteTargetWorksheets)
                    {
                        worksheet.Delete();
                    }
                });
            });
        }

        public string NewEvidenceName()
        {
            int number = 0;

            while (true)
            {
                number++;

                string newName = string.Format(
                    CultureInfo.CurrentCulture,
                    "{0}{1}",
                    Properties.Resources.Prefix_Evidence,
                    number);

                bool exists = false;

                foreach (Excel.Worksheet worksheet in this.Workbook.Worksheets)
                {
                    if (worksheet.Name == newName)
                    {
                        exists = true;
                        break;
                    }
                }

                foreach (Excel.Name name in this.Workbook.Names)
                {
                    if (name.Name == newName)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    return newName;
                }
            }
        }

        public Excel.Worksheet AddEvidence()
        {
            var tmp = App.Excel.ScreenUpdating;
            App.Excel.ScreenUpdating = false;

            try
            {
                Excel.Worksheet worksheet = ExcelHelper.WorksheetAdd(this.Workbook);
                string newName = this.NewEvidenceName();
                worksheet.Name = newName;

                ExcelWorksheetCustomPropertyAccessor.Set(worksheet, EVIDENCE_PROPERTY, true.ToString());

                //string address = "=" + newName + "!A1";
                //Log.Logger.DebugFormat("address = {0}", address);

                //Excel.Name newName = this.Workbook.Names.Add(
                //    newName,
                //    address);

                return worksheet;
            }
            finally
            {
                App.Excel.ScreenUpdating = tmp;
            }
        }

        public TestCase GetActiveTestCase()
        {
            Excel.Worksheet worksheet = this.Workbook.ActiveSheet;
            string targetName = worksheet.Name;

            return this.TestCases.Where(i => i.Worksheet.Name == targetName).FirstOrDefault();
        }

        public void SaveSettings()
        {
            WorkbookContextSettings.Save(this.Workbook, this.settings);
        }
    }
}
