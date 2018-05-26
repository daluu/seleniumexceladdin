// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn
{
    internal class WindowContextManager
    {
        public static IWindowContextManager Create(OfficeVersion officeVersion)
        {
            switch (officeVersion)
            {
                case OfficeVersion.v2010:
                    return new WindowContextManager2010();

                case OfficeVersion.v2013:
                    return new WindowContextManager2013();

                default:
                    throw new InvalidOperationException("Not Supported Office Version");
            }
        }
    }
}
