// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Sgml;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class ImportTestcaseAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.WorkbookEditable;
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
            IEnumerable<string> filenames = this.GetFileNames();

            if (0 == filenames.Count())
            {
                return;
            }

            DisableScreenUpdating.Invoke(() =>
            {
                foreach (var filename in filenames)
                {
                    this.Import(filename);
                }
            });
        }

        private void Import(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            using (var reader = new StreamReader(path, Encoding.UTF8))
            {
                using (var sgmlReader = new SgmlReader()
                {
                    DocType = "HTML",
                    CaseFolding = CaseFolding.ToLower,
                    IgnoreDtd = true,
                    InputStream = reader
                })
                {
                    XDocument xml = XDocument.Load(sgmlReader);
                    XNamespace ns = "http://www.w3.org/1999/xhtml";

                    var profile = xml.Descendants(ns + "head").Attributes("profile").First().Value;

                    if (profile != "http://selenium-ide.openqa.org/profiles/test-case")
                    {
                        throw new InvalidOperationException(Properties.Resources.ImportTestcaseNoSuchProfile);
                    }

                    string testcaseName = xml.Descendants(ns + "thead").Descendants(ns + "td").First().Value;
                    string baseUrl = this.GetBaseUrl(ns, xml);

                    var trs = xml.Descendants(ns + "tbody").Descendants(ns + "tr");

                    var workbookContext = App.Context.GetActiveWorkbookContext();
                    workbookContext.BaseUrl = baseUrl;

                    Excel.Workbook workbook = workbookContext.Workbook;
                    Excel.Worksheet worksheet = ExcelHelper.WorksheetAdd(workbook);
                    ExcelHelper.WorksheetActivate(worksheet);

                    string newName = ListObjectHelper.NewTestCaseName(workbook) + "_" + testcaseName;
                    worksheet.Name = newName;

                    Excel.ListObject listObject = ListObjectHelper.AddListObject(worksheet);
                    listObject.Name = newName;

                    listObject.ListColumns[1].Name = Properties.Resources.ListColumnName_Command;
                    listObject.ListColumns[1].Range.EntireColumn.AutoFit();

                    ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Target);
                    ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Value);
                    ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Result);
                    ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_ErrorMessage);
                    ListObjectHelper.AddColumn(listObject, Properties.Resources.ListColumnName_Evidence);

                    foreach (var tr in trs)
                    {
                        var td = tr.Elements(ns + "td");
                        var command = td.ElementAt(0).Value;
                        var target = td.ElementAt(1).Value;
                        var value = td.ElementAt(2).Value;

                        Excel.ListRow listRow = ListObjectHelper.AddRow(listObject);
                        ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Command, command);
                        ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Target, target);
                        ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Value, value);
                    }

                    ListObjectHelper.SelectCell(listObject, 2, 1);
                    App.Context.Update();
                    ExcelHelper.WorksheetActivate(worksheet);
                }
            }
        }

        private IEnumerable<string> GetFileNames()
        {
            using (var dialog = new OpenFileDialog()
            {
                DefaultExt = "html",
                Multiselect = true,
                Filter = "*.html|*.html|*.*|*.*",
                InitialDirectory = App.Context.Settings.ImportTestcaseInitialDirector,
                Title = Properties.Resources.ImportTestcaseDialogTitle,
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileNames;
                }
            }

            return new List<string>();
        }

        private string GetBaseUrl(XNamespace ns, XDocument xml)
        {
            var link = xml.Descendants(ns + "link").Where(i => i.Attribute("rel").Value == "selenium.base").FirstOrDefault();

            if (null == link)
            {
                return string.Empty;
            }

            return link.Attribute("href").Value;
        }
    }
}
