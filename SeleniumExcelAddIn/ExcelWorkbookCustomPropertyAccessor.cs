// Copyright (c) 2014 Takashi Yoshizawa

using System;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace SeleniumExcelAddIn
{
    public static class ExcelWorkbookCustomPropertyAccessor
    {
        private static Office.DocumentProperty GetProperty(Excel.Workbook workbook, string propertyName)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Office.DocumentProperties properties = workbook.CustomDocumentProperties;

            foreach (Office.DocumentProperty property in properties)
            {
                if (property.Name == propertyName)
                {
                    return property;
                }
            }

            return null;
        }

        private static Office.DocumentProperty Add(Excel.Workbook workbook, string propertyName, Office.MsoDocProperties propertyType, object value)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Office.DocumentProperties properties = workbook.CustomDocumentProperties;
            Office.DocumentProperty property = properties.Add(propertyName, false, propertyType, value);

            return property;
        }

        public static string Get(Excel.Workbook workbook, string propertyName)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Office.DocumentProperty property = GetProperty(workbook, propertyName);

            if (null == property)
            {
                return null;
            }

            return property.Value;
        }

        public static void Set(Excel.Workbook workbook, string propertyName, string value)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Office.DocumentProperty property = GetProperty(workbook, propertyName);

            if (null == property)
            {
                property = Add(workbook, propertyName, Office.MsoDocProperties.msoPropertyTypeString, value);
            }

            property.Value = value;
        }

        public static void Delete(Excel.Workbook workbook, string propertyName)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Office.DocumentProperty property = GetProperty(workbook, propertyName);

            if (null == property)
            {
                return;
            }

            property.Delete();
        }
    }
}
