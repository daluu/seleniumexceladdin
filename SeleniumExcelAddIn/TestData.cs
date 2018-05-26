using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn
{
    public class TestData : Dictionary<string, string>
    {
        public TestData() :
            base(StringComparer.OrdinalIgnoreCase)
        {
        }
    }
}
