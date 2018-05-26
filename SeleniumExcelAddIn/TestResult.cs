// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SeleniumExcelAddIn
{
    public enum TestResult : int
    {
        None = 0,
        Passed = 1,
        Failed = 2,
        Skipped = 3,
    }
}
