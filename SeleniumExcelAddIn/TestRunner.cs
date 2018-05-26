// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Taskbar;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public class TestRunner
    {
        private volatile bool isPaused = false;
        private object syncObj = new object();
        private Task task = new Task(() => { });
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public TestRunner()
        {
            this.Progress = new ProgressCalc();
        }

        public TaskStatus Status
        {
            get
            {
                return this.task.Status;
            }
        }

        public ProgressCalc Progress
        {
            get;
            private set;
        }

        public void Cancel()
        {
            this.cancelTokenSource.Cancel();

            try
            {
                this.task.Wait();
            }
            catch (AggregateException ex)
            {
                Log.Logger.Warn(ex);
            }
        }

        public void Pause()
        {
            if (this.isPaused)
            {
                return;
            }

            Monitor.Enter(this.syncObj);
            this.isPaused = true;
        }

        public void Resume()
        {
            if (!this.isPaused)
            {
                return;
            }

            Monitor.Exit(this.syncObj);
            this.isPaused = false;
        }

        public Task Run(TestContextImpl context)
        {
            if (null == context)
            {
                throw new ArgumentNullException("context");
            }

            switch (this.task.Status)
            {
                case TaskStatus.Running:
                case TaskStatus.WaitingToRun:
                case TaskStatus.WaitingForActivation:
                case TaskStatus.WaitingForChildrenToComplete:
                    throw new InvalidOperationException(Properties.Resources.TestRunner_AlreadyRunning);
            }

            int count = context.TestSequence.CountTotal();

            if (0 == count)
            {
                this.task = Task.Factory.StartNew(() =>
                {
                });

                return this.task;
            }

            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            this.cancelTokenSource = new CancellationTokenSource();
            this.Progress.Start();

            this.task = Task.Factory.StartNew(() =>
            {
                try
                {
                    this.RunInternal(context);
                }
                finally
                {
                    TaskbarManager.Instance.SetProgressValue(0, 0);
                }
            }, this.cancelTokenSource.Token);

            this.task.ContinueWith((a) =>
            {
                try
                {
                    a.Wait();
                }
                catch (AggregateException ex)
                {
                    Log.Logger.Warn(ex);
                }
            }, this.cancelTokenSource.Token, TaskContinuationOptions.None, SynchronizationDispatcher.TaskScheduler);

            return this.task;
        }

        private void UpdateProgress(TestContextImpl context, TestStep step, int stepCount)
        {
            var msg = string.Format(
                CultureInfo.CurrentCulture,
                Properties.Resources.Progress_Info,
                step.Index + 1,
                stepCount,
                context.TestSequence.FailedCount()) + Environment.NewLine + step.ToString();

            this.Progress.Update(step.Index, stepCount, msg);
            TaskbarManager.Instance.SetProgressValue(this.Progress.Percentage, 100);
        }

        private void SetTestStepResult(TestStep step, TestResult result)
        {
            if (string.IsNullOrWhiteSpace(step.ErrorMessage))
            {
                step.Result = result;
            }
        }

        private void SetTestCaseResult(TestCase testCase, TestResult result)
        {
            if (testCase.Result != TestResult.Failed)
            {
                testCase.Result = result;
            }
        }

        private void RunInternal(TestContextImpl context)
        {
            int stepCount = context.TestSequence.CountTotal();

            using (IWebDriver driver = WebDriverFactory.CreateWebDriver(App.Context.Settings.WebDriverType))
            {
                context.Driver = driver;

                foreach (TestStepCollection sequence in context.TestSequence)
                {
                    bool hasError = false;
                    bool hasVerifyFailed = false;

                    foreach (TestStep step in sequence)
                    {
                        lock (this.syncObj)
                        {
                            this.cancelTokenSource.Token.ThrowIfCancellationRequested();
                            this.UpdateProgress(context, step, stepCount);

                            if (hasError)
                            {
                                this.SetTestStepResult(step, TestResult.Skipped);
                                continue;
                            }

                            bool evidence = false;

                            try
                            {
                                ExcelHelper.WorksheetActivate(step.Worksheet);
                                step.ListRow.Range.Select();
                                context.ExecuteStep(step);
                                this.SetTestStepResult(step, TestResult.Passed);
                                evidence = App.Context.Settings.PassedEvidenceRecord && step.Command.IsScreenCapture;
                            }
                            catch (TestVerifyFailedException ex)
                            {
                                hasVerifyFailed = true;
                                Log.Logger.Warn(Properties.Resources.VerifyFailed, ex);
                                step.Result = TestResult.Failed;
                                step.ErrorMessage = ex.Message;
                                evidence |= App.Context.Settings.FailedEvidenceRecord;
                            }
                            catch (TestAssertFailedException ex)
                            {
                                Log.Logger.Warn(Properties.Resources.AssertError, ex);
                                step.Result = TestResult.Failed;
                                step.ErrorMessage = ex.Message;
                                evidence |= App.Context.Settings.FailedEvidenceRecord;
                                hasError = true;
                            }
                            catch (Exception ex)
                            {
                                Log.Logger.Error(ex);
                                step.Result = TestResult.Failed;
                                step.ErrorMessage = ex.Message;
                                evidence |= App.Context.Settings.FailedEvidenceRecord;
                                hasError = true;
                            }

                            if (evidence)
                            {
                                this.CreateEvidence(context, step);
                            }
                        }
                    }

                    this.SetTestCaseResult(sequence.TestCase, (hasError || hasVerifyFailed) ? TestResult.Failed : TestResult.Passed);
                }
            }

            this.Progress.Update(stepCount, stepCount, string.Empty);
        }

        private void CreateEvidence(TestContextImpl context, TestStep step)
        {
            ITakesScreenshot takesScreenshot = context.Driver as ITakesScreenshot;

            if (null == takesScreenshot)
            {
                return;
            }

            bool isAlertPresent = false;

            try
            {
                IAlert alert = context.Driver.SwitchTo().Alert();
                isAlertPresent = true;
            }
            catch (OpenQA.Selenium.NoAlertPresentException)
            {
                isAlertPresent = false;
            }

            if (isAlertPresent)
            {
                return;
            }

            Excel.Workbook workbook = context.WorkbookContext.Workbook;
            Excel.Worksheet evidenceWorksheet = context.WorkbookContext.AddEvidence();
            Excel.Range range = ListRowHelper.Set(step.ListRow, ListRowHelper.ColumnIndex.Evidence, evidenceWorksheet.Name);

            ExcelHelper.SetText(evidenceWorksheet, 1, 1, Properties.Resources.Evidence_Scenario, false).ColumnWidth = 20;

            ExcelHelper.AddHyperLink(
                step.Worksheet,
                range,
                evidenceWorksheet,
                evidenceWorksheet.Cells[1, 1]);

            ExcelHelper.AddHyperLink(
                evidenceWorksheet,
                evidenceWorksheet.Cells[1, 2],
                step.Worksheet,
                range);

            ExcelHelper.SetText(evidenceWorksheet, 2, 1, Properties.Resources.Evidence_Command, false);
            ExcelHelper.SetText(evidenceWorksheet, 2, 2, step.ToString(), false);

            ExcelHelper.SetText(evidenceWorksheet, 3, 1, Properties.Resources.Evidence_ErrorMessage, false);
            ExcelHelper.SetText(evidenceWorksheet, 3, 2, step.ErrorMessage, false);

            ExcelHelper.SetText(evidenceWorksheet, 4, 1, Properties.Resources.Evidence_Browser, false);
            ExcelHelper.SetText(evidenceWorksheet, 4, 2, App.Context.Settings.WebDriverType.ToString(), false);

            ExcelHelper.SetText(evidenceWorksheet, 5, 1, Properties.Resources.Evidence_Title, false);
            ExcelHelper.SetText(evidenceWorksheet, 5, 2, context.Driver.Title, false);

            ExcelHelper.SetText(evidenceWorksheet, 6, 1, Properties.Resources.Evidence_Url, false);
            ExcelHelper.SetText(evidenceWorksheet, 6, 2, context.Driver.Url, false);

            ExcelHelper.SetText(evidenceWorksheet, 7, 1, Properties.Resources.Evidence_Time, false);
            ExcelHelper.SetText(evidenceWorksheet, 7, 2, DateTime.Now.ToString(), false);

            string path = Path.Combine(App.TempDir, Guid.NewGuid().ToString()) + ".jpg";

            try
            {
                Screenshot screenshot = takesScreenshot.GetScreenshot();
                screenshot.SaveAsFile(path, ImageFormat.Jpeg);

                Excel.Shape shape = evidenceWorksheet.Shapes.AddPicture(
                    path,
                    Microsoft.Office.Core.MsoTriState.msoFalse,
                    Microsoft.Office.Core.MsoTriState.msoTrue,
                    0,
                    150,
                    0,
                    0);

                shape.ScaleWidth(1, Microsoft.Office.Core.MsoTriState.msoTrue);
                shape.ScaleHeight(1, Microsoft.Office.Core.MsoTriState.msoTrue);
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
