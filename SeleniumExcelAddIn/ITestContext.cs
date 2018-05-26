// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExcelAddIn
{
    public interface ITestContext
    {
        IWebDriver Driver
        {
            get;
        }

        string Target
        {
            get;
        }

        string Value
        {
            get;
        }

        WebDriverWait Wait
        {
            get;
        }

        OpenQA.Selenium.Interactions.Actions Action
        {
            get;
        }

        TimeSpan Timeout
        {
            get;
            set;
        }

        string Get(string name);
        void Set(string name, string value);
        void Clear();
        string GetAbsoluteUrl(string value);
        IWebElement FindElement(string locator);
        IEnumerable<IWebElement> FindElements(string locator);
        Tuple<int, int> ParseCoordString(string value);
        void HighlightElement(IWebElement element);
    }
}
