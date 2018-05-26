// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn
{
    internal interface IWindowContextManager
    {
        IWindowContext ActiveWindowContext
        {
            get;
        }
    }
}
