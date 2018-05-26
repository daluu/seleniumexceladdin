// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public class WorkbookContextSettings
    {
        private const string NAMESPACE = "http://selenium-excel-addin.jpn.org";

        public WorkbookContextSettings()
        {
            this.UncheckedTestCase = new List<string>();
            this.BaseUrl = string.Empty;
        }

        public string BaseUrl;

        public List<string> UncheckedTestCase
        {
            get;
            private set;
        }

        public static WorkbookContextSettings Load(Excel.Workbook workbook)
        {
            return ExcelBookCustomXmlAcessor.GetCustomXmlByNamespace<WorkbookContextSettings>(workbook, NAMESPACE);
        }

        public static void Save(Excel.Workbook workbook, WorkbookContextSettings settings)
        {
            ExcelBookCustomXmlAcessor.SetCustomXml<WorkbookContextSettings>(workbook, NAMESPACE, settings);
        }
    }
}
