// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public class TestStep : ObservableObject
    {
        public TestStep(
            Excel.Workbook workbook,
            Excel.Worksheet worksheet,
            Excel.ListRow listRow,
            ITestCommand command,
            string target,
            string value)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            if (null == listRow)
            {
                throw new ArgumentNullException("listRow");
            }

            if (null == command)
            {
                throw new ArgumentNullException("command");
            }

            this.Workbook = workbook;
            this.Worksheet = worksheet;
            this.ListRow = listRow;
            this.Command = command;
            this.Target = target;
            this.Value = value;
        }

        private TestResult result;
        private string evidence;

        public ITestCommand Command
        {
            get;
            private set;
        }

        public string Target
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        [JsonIgnore]
        public TestCase TestCase
        {
            get;
            set;
        }

        public TestData TestData
        {
            get;
            set;
        }

        public TestResult Result
        {
            get
            {
                return this.result;
            }

            set
            {
                if (this.UpdateProperty<TestResult>(ref this.result, value, "Result"))
                {
                    Excel.Range range = ListRowHelper.Set(this.ListRow, ListRowHelper.ColumnIndex.Result, TestResultLabel.GetText(this.result));

                    switch (value)
                    {
                        case TestResult.None:
                            ExcelHelper.SetColor(range, Constants.ColorNone);
                            break;

                        case TestResult.Passed:
                            ExcelHelper.SetColor(range, Constants.ColorGreen);
                            break;

                        case TestResult.Failed:
                            ExcelHelper.SetColor(range, Constants.ColorPink);
                            break;

                        case TestResult.Skipped:
                            ExcelHelper.SetColor(range, Constants.ColorYellow);
                            break;
                    }
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                return ListRowHelper.Get(this.ListRow, ListRowHelper.ColumnIndex.Error);
            }

            set
            {
                Excel.Range range = ListRowHelper.Set(this.ListRow, ListRowHelper.ColumnIndex.Error, value);
            }
        }

        public string Evidence
        {
            get
            {
                return this.evidence;
            }

            set
            {
                if (this.UpdateProperty<string>(ref this.evidence, value, "Evidence"))
                {
                    Excel.Range range = ListRowHelper.Set(this.ListRow, ListRowHelper.ColumnIndex.Evidence, value);

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        range.Clear();
                        range.ClearHyperlinks();
                    }
                    else
                    {
                        range.Hyperlinks.Add(
                            range,
                            value + "!A1",
                            Type.Missing,
                            Type.Missing,
                            Type.Missing);
                    }
                }
            }
        }

        [JsonIgnore]
        public Excel.Workbook Workbook
        {
            get;
            set;
        }

        [JsonIgnore]
        public Excel.Worksheet Worksheet
        {
            get;
            set;
        }

        [JsonIgnore]
        public Excel.ListRow ListRow
        {
            get;
            set;
        }

        public int Index
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0}, {1}, {2}",
                this.Command.GetType().Name.Replace("Command", string.Empty),
                this.Target,
                this.Value);
        }
    }
}
