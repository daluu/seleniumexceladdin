// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium.Support.UI;


namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertSelectedValueCommand : ITestCommand
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
                return TestCommandResource.AssertSelectedValue;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertSelectedValue_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertSelectedValue_Value;
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

            var expected = new List<string>()
            {
                context.Value
            };

            var actual = GetActual(context);

            if (0 != expected.Except(actual).Count())
            {
                TestCommandHelper.AssertFail(string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.AssertExpectedAndActual,
                    expected,
                    actual));
            }
        }

        public static IEnumerable<string> GetActual(ITestContext context)
        {
            var element = context.FindElement(context.Target);
            var selectElement = new SelectElement(element);

            List<string> actual = new List<string>();

            for (int i = 0; i < selectElement.Options.Count; i++)
            {
                var optionElement = selectElement.Options[i];

                if ("true" == optionElement.GetAttribute("selected"))
                {
                    actual.Add(optionElement.GetAttribute("value"));
                }
            }

            return actual;
        }
    }
}
