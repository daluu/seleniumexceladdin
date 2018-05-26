// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertElementPositionTopCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.Both;
            }
        }

        public bool IsScreenCapture
        {
            get
            {
                return true;
            }
        }

        
        public string Description
        {
            get
            {
                return TestCommandResource.AssertElementPositionTop;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertElementPositionTop_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertElementPositionTop_Value;
            }
        }

        public void Execute(ITestContext context)

        {
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }

            ExecuteInternal(context);
        }

        public static void ExecuteInternal(ITestContext context)
        {
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }

            var expected = Convert.ToInt16(context.Value);
            var actual = GetActual(context);

            TestCommandHelper.AssertAreEqual(expected, actual);
        }

        public static int GetActual(ITestContext context)
        {
            var element = context.FindElement(context.Target);
            var actual = element.Location.Y;

            return actual;
        }
    }
}
