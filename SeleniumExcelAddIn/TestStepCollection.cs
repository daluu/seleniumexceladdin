// Copyright (c) 2014 Takashi Yoshizawa

using System.Collections.Generic;
using System.Text;

namespace SeleniumExcelAddIn
{
    public class TestStepCollection : Queue<TestStep>
    {
        public TestStepCollection(TestCase testCase)
        {
            this.TestCase = testCase;
        }

        public TestCase TestCase
        {
            get;
            private set;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var step in this)
            {
                sb.AppendLine(step.ToString());
            }

            return sb.ToString();
        }
    }
}
