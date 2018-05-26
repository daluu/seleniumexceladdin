// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class RunCurrentAction : IAction
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
            WorkbookContext workbookContext = App.Context.GetActiveWorkbookContext();
            var testContext = new TestContextImpl(workbookContext);
            var testCase = workbookContext.GetActiveTestCase();

            if (null == testCase)
            {
                throw new InvalidOperationException(Properties.Resources.ScenarioIsNotSelected);
            }

            Excel.ListObject listObject = ListObjectHelper.GetTestCases(testCase.Worksheet).FirstOrDefault();

            if (null != listObject)
            {
                listObject.DataBodyRange.Columns[ListRowHelper.ColumnIndex.Result].Clear();
                listObject.DataBodyRange.Columns[ListRowHelper.ColumnIndex.Error].Clear();
                listObject.DataBodyRange.Columns[ListRowHelper.ColumnIndex.Evidence].Clear();
            }

            if (null == testCase)
            {
                throw new InvalidOperationException(Properties.Resources.ScenarioIsNotSelected);
            }

            App.Context.GetActiveWindowContext().HelpPaneVisible = false;
            testContext.Compile(testCase);

            if (0 < testContext.TestSequence.CompileErrorCount)
            {
                throw new InvalidOperationException(Properties.Resources.CompilerError);
            }

            if (0 == testContext.TestSequence.CountTotal())
            {
                throw new InvalidOperationException(Properties.Resources.TestIsEmpty);
            }

            //workbookContext.DeleteEvidenceAll();

            testCase.Result = TestResult.None;

            using (var form = new View.TestRunForm())
            {
                form.TestContext = testContext;
                form.ShowDialog();
            }
        }
    }
}
