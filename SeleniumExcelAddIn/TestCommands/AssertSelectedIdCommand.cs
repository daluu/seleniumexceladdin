// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn.TestCommands
{
    public class AssertSelectedIdCommand : ITestCommand
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
                return TestCommandResource.AssertSelectedId;
            }
        }

        public string TargetDescription
        {
            get
            {
                return TestCommandResource.AssertSelectedId_Target;
            }
        }

        public string ValueDescription
        {
            get
            {
                return TestCommandResource.AssertSelectedId_Value;
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

            List<string> expectedList = new List<string>()
            {
                context.Value
            };

            var actualList = GetActual(context);

            if (0 != expectedList.Except(actualList).Count())
            {
                TestCommandHelper.AssertFail(string.Format(
                    CultureInfo.CurrentCulture,
                    Properties.Resources.AssertExpectedAndActual,
                    string.Join(",", expectedList),
                    string.Join(",", actualList)));
            }
        }

        public static IEnumerable<string> GetActual(ITestContext context)
        {
            var element = context.FindElement(context.Target);
            var selectElement = new SelectElement(element);

            List<string> actualList = new List<string>();

            for (int i = 0; i < selectElement.Options.Count; i++)
            {
                var optionElement = selectElement.Options[i];
                var selected = optionElement.GetAttribute("selected");

                if (Convert.ToBoolean(selected))
                {
                    actualList.Add(optionElement.GetAttribute("id"));
                }
            }

            return actualList;
        }
    }
}
