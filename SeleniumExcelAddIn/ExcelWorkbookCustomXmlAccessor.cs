// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Office = Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public static class ExcelBookCustomXmlAcessor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
        public static T GetCustomXmlByTagName<T>(Excel.Workbook workbook, string tagName) where T : class
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentNullException("tagName");
            }

            foreach (Office.CustomXMLPart part in workbook.CustomXMLParts)
            {
                if (part.DocumentElement.BaseName == tagName)
                {
                    Office.CustomXMLNode node = part.DocumentElement.FirstChild;
                    string json = node.NodeValue.Trim();

                    return JsonConvert.DeserializeObject<T>(json);
                }
            }

            return default(T);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
        public static T GetCustomXmlByNamespace<T>(Excel.Workbook workbook, string namespaceStr) where T : class, new()
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(namespaceStr))
            {
                throw new ArgumentNullException("namespaceStr");
            }

            Office.CustomXMLParts parts = workbook.CustomXMLParts.SelectByNamespace(namespaceStr);

            if (0 == parts.Count)
            {
                return new T();
            }

            Office.CustomXMLNode node = parts[1].DocumentElement.FirstChild;
            string json = node.NodeValue.Trim();

            return JsonConvert.DeserializeObject<T>(json);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
        public static void SetCustomXml<T>(Excel.Workbook workbook, string namespaceStr, T obj)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(namespaceStr))
            {
                throw new ArgumentNullException("namespaceStr");
            }

            if (null == obj)
            {
                throw new ArgumentNullException("obj");
            }

            DeleteCustomXml(workbook, namespaceStr);
            string json = JsonConvert.SerializeObject(obj);

            XNamespace ns = namespaceStr;
            XDocument xml = new XDocument(
                new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement(ns + "Root",
                    new XCData(json)));

            workbook.CustomXMLParts.Add(xml.ToString());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
        public static void DeleteCustomXml(Excel.Workbook workbook, string namespaceStr)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            if (string.IsNullOrWhiteSpace(namespaceStr))
            {
                throw new ArgumentNullException("namespaceStr");
            }

            Microsoft.Office.Core.CustomXMLParts parts = workbook.CustomXMLParts.SelectByNamespace(namespaceStr);

            foreach (Microsoft.Office.Core.CustomXMLPart part in parts)
            {
                part.Delete();
            }
        }
    }
}
