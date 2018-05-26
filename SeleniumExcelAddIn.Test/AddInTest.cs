// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace SeleniumExcelAddIn.Test
{

    [TestClass]
    public class AddInTest
    {
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContextInstance;

        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private Excel.Application excel;
        private IAppContext app;

        [TestInitialize]
        public void MyTestInitialize()
        {
            this.excel = new Excel.Application();

            //var dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Microsoft Office", "Office14");
            //var path = System.IO.Path.Combine(dir, "EXCEL.EXE");
            //var process = System.Diagnostics.Process.Start(path);

            //for (int i = 0; i < 10; i++)
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    this.excel = Marshal.GetActiveObject("Excel.Application") as Excel.Application;

            //    if (null != this.excel)
            //    {
            //        break;
            //    }
            //}

            Assert.IsNotNull(this.excel);

            this.excel.Visible = true;

            try
            {
                Office.COMAddIn addin = excel.COMAddIns.Item("SeleniumExcelAddIn");
                this.app = (IAppContext)addin.Object;
                Assert.IsNotNull(this.app);
            }
            catch
            {
                this.excel.Quit();
                throw;
            }

            excel.Workbooks.Add();
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            while (0 < this.excel.Workbooks.Count)
            {
                this.excel.Workbooks[1].Close(false);
            }

            this.excel.Quit();
        }

        [TestMethod]
        public void VersionTest()
        {
            Assert.AreEqual(1, this.app.Version.Major);
        }

        [TestMethod]
        public void ActiveWorkbookContext()
        {
            var book = this.app.ActiveWorkbookContext;
            Assert.IsNull(book);

            this.excel.Workbooks.Add();

            book = this.app.ActiveWorkbookContext;
            Assert.IsNotNull(book);
        }

        [TestMethod]
        public void ActionTest()
        {
            this.app.Execute(ActionId.ToggleListPaneVisible.ToString());
        }
    }
}
