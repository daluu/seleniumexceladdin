// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.TestCommands
{
    public class StoreAttributeCommand : ITestCommand
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
                return TestCommandResource.StoreAttribute;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.StoreAttribute_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.StoreAttribute_Value;
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
            var attributeValue = element.GetAttribute(attributeLocator.AttributeName);

            context.Set(context.Value, attributeValue);
        }
    }
}
