// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Linq;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertAttributeCommand : ITestCommand
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
                return false;
            }
        }

        
        public string Description
        {
            get
            {
                return TestCommandResource.AssertAttribute;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertAttribute_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertAttribute_Value;
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

            var attributeLocator = AttributeLocator.Parse(context.Target);
            var element = context.FindElement(attributeLocator.ElementLocator);

            var expected = context.Value;
            var actual = element.GetAttribute(attributeLocator.AttributeName);

            TestCommandHelper.AssertAreEqual(expected, actual);
        }
    }
}
