// Copyright (c) 2014 Takashi Yoshizawa

using System;

namespace SeleniumExcelAddIn
{
    [Flags]
    public enum TestCommandSyntax
    {
        None = 0,
        Target = 1 << 1,
        Value = 1 << 2,
        Both = Target | Value,
    }
}
