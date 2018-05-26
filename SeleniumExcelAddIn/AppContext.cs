// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("A1863F98-16BB-466E-9966-37290F9C8270")]
    public class AppContext : StandardOleMarshalObject, IAppContext, INotifyPropertyChanged
    {
        private WorkbookContext currentWorkbookContext;
        private IWindowContextManager windowContextManager;
        private Recorder.CommandRecorder recorder;

        public AppContext()
        {
            this.Version = this.GetType().Assembly.GetName().Version;
            Log.Logger.InfoFormat("App.Context.Version = {0}", this.Version);
        }

        public bool IsRecording
        {
            get
            {
                return this.recorder.IsRecording;
            }

            set
            {
                if (value)
                {
                    this.recorder.Start();
                }
                else
                {
                    this.recorder.Stop();
                }
            }
        }

        public void Startup()
        {
            Log.Logger.InfoFormat("CommandLine = {0}", Environment.CommandLine);
            Log.Logger.InfoFormat("Excel Version = {0}", App.Excel.Version);
            Log.Logger.InfoFormat("OperatingSystem Version = {0}", Environment.OSVersion);
            Log.Logger.InfoFormat("Is64BitProcess = {0}", Environment.Is64BitProcess);
            Log.Logger.InfoFormat("Is64BitOperatingSystem = {0}", Environment.Is64BitOperatingSystem);
            Log.Logger.InfoFormat("CurrentCulture = {0}", CultureInfo.CurrentCulture);

            if (this.IsEmedding)
            {
                return;
            }

            ToolStripManager.Renderer = new CustomToolStripRenderer(App.OfficeVersion == OfficeVersion.v2010 ? SystemColors.Control : SystemColors.Window);
            this.Settings = AppSettings.Load();
            this.AddEventListner();
            this.windowContextManager = WindowContextManager.Create(App.OfficeVersion);
            ActionManager.Enabled = true;
            this.Update();
            this.recorder = new Recorder.CommandRecorder();
            this.recorder.Started += new EventHandler(recorder_Started);
            this.recorder.Stopped += new EventHandler(recorder_Stopped);
            this.recorder.CommandRecording += new EventHandler<Recorder.CommandRecorderEventArgs>(recorder_CommandRecording);
            CheckForNewVersion.Check();
        }

        public bool IsEmedding
        {
            get
            {
                var cl = Environment.CommandLine;
                var result = false;

                if (!cl.Contains("/Automation"))
                {
                    if (cl.Contains("/Embedding") || cl.Contains("-Embedding"))
                    {
                        result = true;
                    }
                }

                Log.Logger.DebugFormat("IsEmedding = {0}", result);
                
                return result;
            }
        }

        private void recorder_CommandRecording(object sender, Recorder.CommandRecorderEventArgs e)
        {
            var testCase = this.GetActiveWorkbookContext().GetActiveTestCase();
            Excel.ListObject listObject = testCase.ListObject;
            Excel.ListRow listRow = ListObjectHelper.GetEmptyRow(listObject);
            ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Command, e.Command);
            ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Target, e.Target);
            ListRowHelper.Set(listRow, ListRowHelper.ColumnIndex.Value, e.Value);
        }

        private void recorder_Stopped(object sender, EventArgs e)
        {
            ActionManager.Update();
        }

        private void recorder_Started(object sender, EventArgs e)
        {
            ActionManager.Update();
        }

        public void Shutdown()
        {
            if (this.IsEmedding)
            {
                return;
            }

            ActionManager.Enabled = false;
            this.RemoveEventListner();
            this.Settings.Save();

            CheckForNewVersion.Dispose();
        }

        public void Update()
        {
            var workbookContext = this.GetActiveWorkbookContext();

            if (null == workbookContext)
            {
                this.GetActiveWindowContext().WorkbookContext = null;
                //                this.listControl.TestCases = null;
                this.currentWorkbookContext = null;
            }
            else if (null == this.currentWorkbookContext)
            {
                this.currentWorkbookContext = workbookContext;
                this.GetActiveWindowContext().WorkbookContext = this.currentWorkbookContext;
                //                this.listControl.TestCases = this.currentWorkbookContext.TestCases;
            }
            else if (this.currentWorkbookContext.Id != workbookContext.Id)
            {
                this.currentWorkbookContext = workbookContext;
                this.GetActiveWindowContext().WorkbookContext = this.currentWorkbookContext;
                //                this.listControl.TestCases = this.currentWorkbookContext.TestCases;
            }

            ActionManager.Update();
        }

        public WorkbookContext GetActiveWorkbookContext()
        {
            if (0 == App.Excel.Workbooks.Count)
            {
                return null;
            }

            return this.GetWorkBookContext(App.Excel.ActiveWorkbook);
        }

        public WorkbookContext GetWorkBookContext(Excel.Workbook workbook)
        {
            if (null == workbook)
            {
                throw new ArgumentNullException("workbook");
            }

            bool isNotCurrent = false;
            WorkbookContext workbookContext = null;

            if (null == this.currentWorkbookContext)
            {
                isNotCurrent = true;
            }
            else if (this.currentWorkbookContext.Id != WorkbookContext.GetContextId(workbook))
            {
                isNotCurrent = true;
            }

            if (isNotCurrent)
            {
                workbookContext = new WorkbookContext(workbook);
            }
            else
            {
                workbookContext = this.currentWorkbookContext;
                workbookContext.Update();
            }

            return workbookContext;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public AppSettings Settings
        {
            get;
            set;
        }

        public Version Version
        {
            get;
            private set;
        }

        public IWorkbookContext ActiveWorkbookContext
        {
            get
            {
                return this.GetActiveWorkbookContext();
            }
        }

        public void Execute(string actionName)
        {
            if (string.IsNullOrWhiteSpace(actionName))
            {
                throw new ArgumentNullException("actionName");
            }

            MessageDialog.IsSilent = true;
            ActionManager.Execute(ActionManager.GetActionId(actionName));
            MessageDialog.IsSilent = false;
        }

        public IWindowContext GetActiveWindowContext()
        {
            return this.windowContextManager.ActiveWindowContext;
        }

        protected bool UpdateProperty<T>(ref T field, T value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            var handler = this.PropertyChanged;

            if (null == handler)
            {
                return;
            }

            handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddEventListner()
        {
            App.Excel.WindowActivate += this.Excel_WindowActivate;
            App.Excel.WindowDeactivate += this.Excel_WindowDeactivate;
            App.Excel.WorkbookActivate += this.Excel_WorkbookActivate;
            App.Excel.WorkbookAfterSave += this.Excel_WorkbookAfterSave;
            App.Excel.WorkbookBeforeClose += this.Excel_WorkbookBeforeClose;
            App.Excel.WorkbookBeforeSave += this.Excel_WorkbookBeforeSave;
            App.Excel.WorkbookDeactivate += this.Excel_WorkbookDeactivate;
            App.Excel.WorkbookNewSheet += this.Excel_WorkbookNewSheet;
            App.Excel.WorkbookOpen += this.Excel_WorkbookOpen;
            App.Excel.SheetActivate += this.Excel_SheetActivate;
            App.Excel.SheetChange += this.Excel_SheetChange;
            App.Excel.SheetDeactivate += this.Excel_SheetDeactivate;
            App.Excel.SheetSelectionChange += this.Excel_SheetSelectionChange;
        }

        private void RemoveEventListner()
        {
            App.Excel.WindowActivate -= this.Excel_WindowActivate;
            App.Excel.WindowDeactivate -= this.Excel_WindowDeactivate;
            App.Excel.WorkbookActivate -= this.Excel_WorkbookActivate;
            App.Excel.WorkbookAfterSave -= this.Excel_WorkbookAfterSave;
            App.Excel.WorkbookBeforeClose -= this.Excel_WorkbookBeforeClose;
            App.Excel.WorkbookBeforeSave -= this.Excel_WorkbookBeforeSave;
            App.Excel.WorkbookDeactivate -= this.Excel_WorkbookDeactivate;
            App.Excel.WorkbookNewSheet -= this.Excel_WorkbookNewSheet;
            App.Excel.WorkbookOpen -= this.Excel_WorkbookOpen;
            App.Excel.SheetActivate -= this.Excel_SheetActivate;
            App.Excel.SheetChange -= this.Excel_SheetChange;
            App.Excel.SheetDeactivate -= this.Excel_SheetDeactivate;
            App.Excel.SheetSelectionChange -= this.Excel_SheetSelectionChange;
        }

        private void Excel_SheetSelectionChange(object worksheet, Excel.Range range)
        {
            //#if DEBUG
            //            Log.Logger.Debug("SheetSelectionChange");
            //#endif
        }

        private void Excel_SheetChange(object worksheet, Excel.Range range)
        {
            //#if DEBUG
            //            Log.Logger.Debug("SheetChange");
            //#endif
            //            this.Update();
        }

        private void Excel_SheetDeactivate(object worksheet)
        {
#if DEBUG
            Log.Logger.Debug("SheetDeactivate");
#endif
            //this.Update();
        }

        private void Excel_SheetActivate(object worksheet)
        {
#if DEBUG
            Log.Logger.Debug("SheetActivate");
#endif
            //this.Update();
        }

        private void Excel_WorkbookNewSheet(Excel.Workbook workbook, object worksheet)
        {
#if DEBUG
            Log.Logger.Debug("WorkbookNewSheet");
#endif
        }

        private void Excel_WorkbookOpen(Excel.Workbook workbook)
        {
#if DEBUG
            Log.Logger.Debug("WorkbookOpen");
#endif
            this.Update();
        }

        private void Excel_WorkbookBeforeSave(Excel.Workbook workbook, bool saveAsUI, ref bool cancel)
        {
#if DEBUG
            Log.Logger.Debug("WorkbookBeforeSave");
#endif
            WorkbookContext workbookConext = this.GetWorkBookContext(workbook);
            workbookConext.SaveSettings();
        }

        private void Excel_WorkbookAfterSave(Excel.Workbook workbook, bool success)
        {
#if DEBUG
            Log.Logger.Debug("WorkbookAfterSave");
#endif
        }

        private void Excel_WorkbookDeactivate(Excel.Workbook workbook)
        {
#if DEBUG
            Log.Logger.Debug("WorkbookDeactivate");
#endif
            // Last Workbook Closing.
            if (1 == App.Excel.Workbooks.Count)
            {
                this.GetActiveWindowContext().WorkbookContext = null;
                //this.listControl.TestCases = null;
            }
        }

        private void Excel_WorkbookBeforeClose(Excel.Workbook workbook, ref bool cancel)
        {
#if DEBUG
            Log.Logger.Debug("WorkbookBeforeClose");
#endif
        }

        private void Excel_WorkbookActivate(Excel.Workbook workbook)
        {
#if DEBUG
            Log.Logger.Debug("WorkbookActivate");
#endif
        }

        private void Excel_WindowActivate(Excel.Workbook workbook, Excel.Window window)
        {
#if DEBUG
            Log.Logger.Debug("WindowActivate");
#endif
            this.Update();
        }

        private void Excel_WindowDeactivate(Excel.Workbook workbook, Excel.Window window)
        {
#if DEBUG
            Log.Logger.Debug("WindowDeactivate");
#endif
            //this.Update();
        }
    }
}
