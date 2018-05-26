// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertAlertCommand : ITestCommand
    {
        public TestCommandSyntax Syntax
        {
            get
            {
                return TestCommandSyntax.Target;
            }
        }

        public bool IsScreenCapture
        {
            get
            {
                return false;
            }
        }

        
        public string Description
        {
            get
            {
                return TestCommandResource.AssertAlert;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertAlert_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertAlert_Value;
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

            var alert = context.Driver.SwitchTo().Alert();

            try
            {
                var expected = context.Target;
                var actual = alert.Text;
                TestCommandHelper.AssertAreEqual(expected, actual);
            }
            finally
            {
                alert.Accept();
            }
        }
    }
}
