// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public class TestCommandCompiler
    {
        public TestSequence Compile(IEnumerable<TestCase> testCases)
        {
            if (null == testCases)
            {
                throw new ArgumentNullException("testCases");
            }
#if DEBUG
            Stopwatch sw = new Stopwatch();
            sw.Start();
#endif
            var testSequence = new TestSequence();
            int index = 0;

            foreach (var testCase in testCases.Where(i => i.IsChecked))
            {
                Excel.ListObject listObject = testCase.ListObject;
                var dataSequence = this.GetTestDataSequence(testCase);

                foreach (var data in dataSequence)
                {
                    var steps = new TestStepCollection(testCase);
                    testSequence.Enqueue(steps);

                    ListObjectHelper.ForEach(
                        listObject,
                        (listRow) =>
                        {
                            try
                            {
                                var step = this.CompileFromListRow(
                                    testCase.Workbook,
                                    testCase.Worksheet,
                                    listObject,
                                    listRow,
                                    data);

                                if (null != step)
                                {
                                    step.TestCase = testCase;
                                    step.Index = index++;
                                    steps.Enqueue(step);
                                }
                            }
                            catch (Exception ex)
                            {
                                Log.Logger.Warn(ex);
                                testSequence.CompileErrorCount++;
                                testCase.Result = TestResult.Failed;
                            }

                            return true;
                        });
                }
            }

#if DEBUG
            sw.Stop();
            Log.Logger.Debug(testSequence.ToString());
            Log.Logger.DebugFormat("Elapsed = {0}", sw.Elapsed);
#endif

            return testSequence;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="worksheet"></param>
        /// <param name="listObject"></param>
        /// <param name="listRow"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public TestStep CompileFromListRow(
            Excel.Workbook workbook,
            Excel.Worksheet worksheet,
            Excel.ListObject listObject,
            Excel.ListRow listRow,
            Dictionary<string, string> data)
        {
            if (null == listObject)
            {
                throw new ArgumentNullException("listObject");
            }

            if (null == listRow)
            {
                throw new ArgumentNullException("listRow");
            }

            ExcelHelper.SetColor(listRow.Range, Constants.ColorNone);
            ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Error, string.Empty);

            string name = ListRowHelper.Get(listRow, ListRowHelper.ColumnIndex.Command);

            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            try
            {
                var command = TestCommandFactory.CreateCommand(name);
                var target = this.GetValue(data, ListRowHelper.Get(listRow, ListRowHelper.ColumnIndex.Target));
                var value = this.GetValue(data, ListRowHelper.Get(listRow, ListRowHelper.ColumnIndex.Value));

                this.SyntaxCheck(command, target, value);

                var step = new TestStep(
                    workbook,
                    worksheet,
                    listRow,
                    command,
                    target,
                    value);

                return step;
            }
            catch (Exception ex)
            {
                Log.Logger.Warn(ex);
                ExcelHelper.SetColor(listRow.Range, Constants.ColorPink);
                Excel.Range range = ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Error, ex.Message);
                //ExcelHelper.AddComment(range, ex.Message);
                throw;
            }
        }

        private TestDataSequence GetTestDataSequence(ITestCase testCase)
        {
            var dataSequence = new TestDataSequence();

            if (string.IsNullOrWhiteSpace(testCase.DataName))
            {
                var dummyData = new TestData();
                dataSequence.Enqueue(dummyData);
                return dataSequence;
            }

            Excel.ListObject listObject = ListObjectHelper.GetByName(testCase.Workbook, testCase.DataName);

            if (null == listObject)
            {
                throw new InvalidOperationException("listObject is null.");
            }

            ListObjectHelper.ForEach(
                listObject,
                (listRow) =>
                {
                    var data = new TestData();

                    foreach (Excel.ListColumn listColumn in listObject.ListColumns)
                    {
                        var value = ListRowHelper.Get(listRow, listColumn.Index);
                        data.Add(listColumn.Name, value);
                    }

                    dataSequence.Enqueue(data);
                    return true;
                });

            return dataSequence;
        }

        private Regex r = new Regex(@"\$\{(.*?)\}", RegexOptions.Compiled);

        private string GetValue(Dictionary<string, string> dataRow, string value)
        {
            var ms = this.r.Matches(value);

            if (0 == ms.Count)
            {
                return value;
            }

            for (int i = 0; i < ms.Count; i++)
            {
                var m = ms[i];
                var g = m.Groups[1];
                var name = g.Value;
                string caputre = m.Captures[0].Value;

                if (dataRow.ContainsKey(name))
                {
                    value = value.Replace(caputre, dataRow[name]);
                }
            }

            return value;
        }

        private void SyntaxCheck(ITestCommand command, string target, string value)
        {
            if (null == command)
            {
                throw new ArgumentNullException("command");
            }

            if (command.Syntax.HasFlag(TestCommandSyntax.Target))
            {
                if (string.IsNullOrWhiteSpace(target))
                {
                    throw new InvalidOperationException(Properties.Resources.TestCommand_Validate_RequireTarget);
                }
            }

            if (command.Syntax.HasFlag(TestCommandSyntax.Value))
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException(Properties.Resources.TestCommand_Validate_RequireValue);
                }
            }
        }
    }
}
