// Copyright (c) 2014 Takashi Yoshizawa

using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public interface ITestCommand
    {
        TestCommandSyntax Syntax
        {
            get;
        }

        bool IsScreenCapture
        {
            get;
        }

        string Description
        {
            get;
        }

        string TargetDescription
        {
            get;
        }

        string ValueDescription
        {
            get;
        }

        void Execute(ITestContext context);
    }
}
