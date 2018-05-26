// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn.ActionValidators
{
    internal class NoneActionValidator : IActionValidator
    {
        public string Validate()
        {
            return string.Empty;
        }
    }
}
