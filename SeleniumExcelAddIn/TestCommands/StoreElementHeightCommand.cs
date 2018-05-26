// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Globalization;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreElementHeightCommand : ITestCommand
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
                return TestCommandResource.StoreElementHeight;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreElementHeight_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreElementHeight_Value;
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

            string name = context.Value;
            string value = AssertElementHeightCommand.GetActual(context).ToString(CultureInfo.InvariantCulture); 

            context.Set(name, value);
        }
    }
}
