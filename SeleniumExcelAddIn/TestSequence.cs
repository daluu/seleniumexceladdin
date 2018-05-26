// Copyright (c) 2014 Takashi Yoshizawa

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumExcelAddIn
{
    public class TestSequence : Queue<TestStepCollection>
    {
        public int CompileErrorCount
        {
            get;
            set;
        }

        public int CountTotal()
        {
            return this.Aggregate(0, (i, s) => i + s.Count());
        }

        public int FailedCount()
        {
            return this.Aggregate(0, (i, s) => i + s.Where(j => j.Result == TestResult.Failed).Count());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var seq in this)
            {
                sb.AppendLine(seq.ToString());
            }

            return sb.ToString();
        }
    }
}
