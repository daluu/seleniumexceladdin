// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.Actions
{
    internal class RunAction : IAction
    {
        public ActionFlags Flags
        {
            get
            {
                return ActionFlags.WorkbookPresent | ActionFlags.WorkbookEditable;
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
            testContext.Compile(workbookContext.TestCases);

            if (0 < testContext.TestSequence.CompileErrorCount)
            {
                throw new InvalidOperationException(Properties.Resources.CompilerError);
            }

            if (0 == testContext.TestSequence.CountTotal())
            {
                throw new InvalidOperationException(Properties.Resources.TestIsEmpty);
            }

            App.Context.GetActiveWindowContext().HelpPaneVisible = false;
            workbookContext.DeleteEvidenceAll();

            using (var form = new View.TestRunForm())
            {
                form.TestContext = testContext;
                form.ShowDialog();
            }
        }
    }
}
