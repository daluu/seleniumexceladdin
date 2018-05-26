// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("5863DC42-B3CF-4BBF-B151-A96A3AF78351")]
    public class TestCase : ObservableObject, ITestCase
    {
        private static readonly string SettingPropertyName = "TestCaseSettings";

        private string name = string.Empty;
        private string displayName = string.Empty;
        private string dataName = string.Empty;
        private string dataDisplayName = string.Empty;
        private string resultLabel = string.Empty;
        private Image icon;
        private Image statucIcon;
        private TestCaseSettings settings = new TestCaseSettings();

        public TestCase(Excel.Workbook workbook, Excel.Worksheet worksheet, Excel.ListObject listObject)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            this.Workbook = workbook;
            this.Worksheet = worksheet;
            this.ListObject = listObject;
            this.DataName = listObject.Comment;
            this.Result = TestResult.None;
            this.Load();
            this.Update();
        }

        [JsonIgnore]
        public Excel.Workbook Workbook
        {
            get;
            private set;
        }

        [JsonIgnore]
        public Excel.Worksheet Worksheet
        {
            get;
            private set;
        }

        [JsonIgnore]
        public Excel.ListObject ListObject
        {
            get;
            private set;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.UpdateProperty<string>(ref this.name, value, "Name");
            }
        }

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }

            private set
            {
                this.UpdateProperty<string>(ref this.displayName, value, "DisplayName");
            }
        }

        public TestResult Result
        {
            get
            {
                return this.settings.Result;
            }

            set
            {
                if (this.UpdateProperty<TestResult>(ref this.settings.Result, value, "Result"))
                {
                    this.Save();
                }

                this.UpdateStatus();
            }
        }

        [JsonIgnore]
        public Image Icon
        {
            get
            {
                return this.icon;
            }

            private set
            {
                this.UpdateProperty<Image>(ref this.icon, value, "Icon");
            }
        }

        [JsonIgnore]
        public Image StatusIcon
        {
            get
            {
                return this.statucIcon;
            }

            private set
            {
                this.UpdateProperty<Image>(ref this.statucIcon, value, "StatusIcon");
            }
        }

        public string DataName
        {
            get
            {
                return this.dataName;
            }

            set
            {
                if (this.UpdateProperty<string>(ref this.dataName, value, "DataName"))
                {
                    this.ListObject.Comment = value;
                    this.Update();
                }
            }
        }

        public string DataDisplayName
        {
            get
            {
                return this.dataDisplayName;
            }

            private set
            {
                this.UpdateProperty<string>(ref this.dataDisplayName, value, "DataDisplayName");
            }
        }

        public bool IsChecked
        {
            get
            {
                return this.settings.IsChecked;
            }

            set
            {
                if (this.UpdateProperty<bool>(ref this.settings.IsChecked, value, "IsChecked"))
                {
                    this.Save();
                }
            }
        }

        public string ResultLabel
        {
            get
            {
                return this.resultLabel;
            }

            private set
            {
                this.UpdateProperty<string>(ref this.resultLabel, value, "ResultLabel");
            }
        }

        public void Load()
        {
            try
            {
                string json = ExcelWorksheetCustomPropertyAccessor.Get(this.Worksheet, SettingPropertyName);

                if (string.IsNullOrWhiteSpace(json))
                {
                    this.settings = new TestCaseSettings();
                    return;
                }

                this.settings = JsonConvert.DeserializeObject<TestCaseSettings>(json);
                this.UpdateStatus();
            }
            catch (Exception ex)
            {
                Log.Logger.Warn(ex);
                this.settings = new TestCaseSettings();
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this.settings);
            ExcelWorksheetCustomPropertyAccessor.Set(this.Worksheet, SettingPropertyName, json);
        }

        public void Update()
        {
            this.Name = this.ListObject.Name;
            this.DisplayName = this.Worksheet.Name;

            if (string.IsNullOrWhiteSpace(this.DataName))
            {
                this.Icon = Properties.Resources.table;
                this.DataDisplayName = string.Empty;
                this.ListObject.Comment = string.Empty;
            }
            else
            {
                this.Icon = Properties.Resources.table_link;
                Excel.ListObject dataListObject = ListObjectHelper.GetByName(this.Workbook, this.DataName);

                if (null != dataListObject)
                {
                    this.DataDisplayName = ListObjectHelper.GetWorksheetName(dataListObject);
                }
                else
                {
                    this.DataDisplayName = string.Empty;
                }
            }
        }

        private void UpdateStatus()
        {
            this.ResultLabel = TestResultLabel.GetText(this.Result);

            switch (this.Result)
            {
                case TestResult.None:
                    this.StatusIcon = Properties.Resources.blank16;
                    break;

                case TestResult.Passed:
                    this.StatusIcon = Properties.Resources.tick;
                    break;

                case TestResult.Failed:
                    this.StatusIcon = Properties.Resources.cross;
                    break;

                case TestResult.Skipped:
                    this.StatusIcon = Properties.Resources.bullet_yellow;
                    break;
            }
        }
    }
}
