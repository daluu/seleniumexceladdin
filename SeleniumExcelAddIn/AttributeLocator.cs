// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Linq;

namespace SeleniumExcelAddIn
{
    public class AttributeLocator
    {
        public static AttributeLocator Parse(string value)
        {
            string[] s = value.Split('@');

            if (2 != s.Count())
            {
                throw new InvalidOperationException(Properties.Resources.InvaildAttributeLocator);
            }

            if (string.IsNullOrWhiteSpace(s[0]) || string.IsNullOrWhiteSpace(s[1]))
            {
                throw new InvalidOperationException(Properties.Resources.InvaildAttributeLocator);
            }

            return new AttributeLocator()
            {
                ElementLocator = s[0],
                AttributeName = s[1]
            };
        }

        public string ElementLocator
        {
            get;
            private set;
        }

        public string AttributeName
        {
            get;
            private set;
        }
    }
}
