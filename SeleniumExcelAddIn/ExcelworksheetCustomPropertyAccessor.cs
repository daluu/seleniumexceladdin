// Copyright (c) 2014 Takashi Yoshizawa

using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public static class ExcelWorksheetCustomPropertyAccessor
    {
        public static string Get(Excel.Worksheet worksheet, string propertyName)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Excel.CustomProperty property = GetProperty(worksheet, propertyName);

            if (null == property)
            {
                return null;
            }

            return property.Value;
        }

        public static void Set(Excel.Worksheet worksheet, string propertyName, string value)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Excel.CustomProperty property = GetProperty(worksheet, propertyName);

            if (null == property)
            {
                property = AddProperty(worksheet, propertyName, value);
            }

            property.Value = value;
        }

        public static void Delete(Excel.Worksheet worksheet, string propertyName)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Excel.CustomProperty property = GetProperty(worksheet, propertyName);

            if (null == property)
            {
                return;
            }

            property.Delete();
        }

        private static Excel.CustomProperty GetProperty(Excel.Worksheet worksheet, string propertyName)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Excel.CustomProperties properties = worksheet.CustomProperties;

            foreach (Excel.CustomProperty property in properties)
            {
                if (property.Name == propertyName)
                {
                    return property;
                }
            }

            return null;
        }

        private static Excel.CustomProperty AddProperty(Excel.Worksheet worksheet, string propertyName, string value)
        {
            if (null == worksheet)
            {
                throw new ArgumentNullException("worksheet");
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            Excel.CustomProperties properties = worksheet.CustomProperties;
            Excel.CustomProperty property = properties.Add(propertyName, value);

            return property;
        }
    }
}
