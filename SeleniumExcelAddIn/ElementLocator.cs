// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumExcelAddIn
{
    public static class ElementLocator
    {
        private static readonly DispatchDictionary<By> dic = new DispatchDictionary<By>(ByCss)
        {
            { 
                "id=",
                ById 
            },
            { 
                "identifier=",
                ById
            },
            {
                "name=",
                ByName
            },
            {
                "xpath=",
                ByXPath
            },
            {
                "//",
                ByXPath2
            },
            {
                "link=",
                ByLinkText
            },
            {
                "css=",
                ByCss 
            },
        };

        public static By Parse(string locator)
        {
            if (string.IsNullOrWhiteSpace(locator))
            {
                throw new ArgumentNullException("locator");
            }

            return dic.Dispatch(locator);
        }

        private static By ById(string value)
        {
            return By.Id(value);
        }

        private static By ByName(string value)
        {
            return By.Name(value);
        }

        private static By ByXPath(string value)
        {
            return By.XPath(value);
        }

        private static By ByXPath2(string value)
        {
            return By.XPath("//" + value);
        }

        private static By ByLinkText(string value)
        {
            return By.LinkText(value);
        }

        private static By ByCss(string value)
        {
            return By.CssSelector(value);
        }
    }
}
