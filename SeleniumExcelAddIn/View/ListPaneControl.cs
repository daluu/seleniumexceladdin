// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn.View
{
    public partial class ListPaneControl : UserControl
    {
        public ListPaneControl()
        {
            this.InitializeComponent();
        }

        private void PaneControl_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            ActionManager.Bind(ActionId.AddTestCase, this.createScenarioButton);
            ActionManager.Bind(ActionId.AddTestData, this.createTestDataButton);
            ActionManager.Bind(ActionId.Refresh, this.refreshButton);
            ActionManager.Bind(ActionId.Run, this.runButton);
            ActionManager.Bind(ActionId.RunOnlyFailed, this.runOnlyFailedMenuItem);
            ActionManager.Bind(ActionId.RunCurrentSheet, this.runCurrentMenuItem);
            ActionManager.Bind(ActionId.TestCaseCheckedToggle, this.scenarioCheckedToggleButton);
            ActionManager.Bind(ActionId.TestCaseCheckedAll, this.scenarioCheckedAllMenuItem);
            ActionManager.Bind(ActionId.TestCaseUncheckedAll, this.scenarioUncheckedallMenuItem);
            ActionManager.Bind(ActionId.ImportTestcase, this.importButton);

            this.testCaseColumn.Width = App.Context.Settings.ListPaneTestCaseColumnWidth;
            this.dataGridView1.ColumnWidthChanged += this.dataGridView1_ColumnWidthChanged;
            App.Excel.SheetActivate += new Excel.AppEvents_SheetActivateEventHandler(this.Excel_SheetActivate);
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            App.Context.Settings.ListPaneTestCaseColumnWidth = this.testCaseColumn.Width;
        }

        public TestCase SelectedTestCase
        {
            get
            {
                if (0 == this.dataGridView1.SelectedRows.Count)
                {
                    return null;
                }

                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                TestCase testCase = row.DataBoundItem as TestCase;

                return testCase;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (!App.Excel.ScreenUpdating)
            {
                return;
            }

            var testCase = this.SelectedTestCase;

            if (null == testCase)
            {
                return;
            }

            Excel.Worksheet activeWorksheet = App.Excel.ActiveSheet;

            if (null == activeWorksheet)
            {
                return;
            }

            if (activeWorksheet.Name == testCase.DisplayName)
            {
                return;
            }

            foreach (Excel.Worksheet worksheet in testCase.Workbook.Worksheets)
            {
                if (worksheet.Name == testCase.DisplayName)
                {
                    ExcelHelper.WorksheetActivate(worksheet);
                }
            }
        }

        private void Excel_SheetActivate(object sh)
        {
            this.dataGridView1.ClearSelection();

            Excel.Worksheet worksheet = (Excel.Worksheet)sh;
#if DEBUG
            Log.Logger.DebugFormat("*** ACTIVATE EVENT *** = {0}", worksheet.Name);
#endif
            Excel.ListObject listObject = ListObjectHelper.GetTestCases(worksheet).FirstOrDefault();

            if (null == listObject)
            {
#if DEBUG
                Log.Logger.DebugFormat("*** LISTOBJECT IS NULL ***");
#endif
                return;
            }

            string name = listObject.Name;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                TestCase testCase = row.DataBoundItem as TestCase;

                if (null == testCase)
                {
                    continue;
                }

                if (testCase.Name == name)
                {
#if DEBUG
                    Log.Logger.DebugFormat("*** SELECTED *** = {0}", name);
#endif
                    row.Selected = true;
                    return;
                }
            }
        }

        public TestCaseCollection TestCases
        {
            set
            {
                this.dataGridView1.DataSource = value;
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Draw Row Index Number

            if (0 <= e.ColumnIndex || e.RowIndex < 0)
            {
                return;
            }

            e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

            Rectangle rect = e.CellBounds;
            rect.Inflate(-2, -2);

            TextRenderer.DrawText(
                e.Graphics,
                (e.RowIndex + 1).ToString(CultureInfo.InvariantCulture),
                e.CellStyle.Font,
                rect,
                SystemColors.GrayText,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Activate Test Data Worksheet

            if (e.ColumnIndex != this.testDataColumn.Index)
            {
                return;
            }

            DataGridViewLinkCell cell = (DataGridViewLinkCell)this.dataGridView1[e.ColumnIndex, e.RowIndex];
            string testDataWorksheetName = (string)cell.Value;

            foreach (Excel.Worksheet worksheet in App.Excel.ActiveWorkbook.Worksheets)
            {
                if (worksheet.Name == testDataWorksheetName)
                {
                    ((Excel._Worksheet)worksheet).Activate();
                    return;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Build TaskScheduler Menu
            this.contextMenuStrip1.Items.Clear();

            var workbookContext = App.Context.GetActiveWorkbookContext();

            if (null == workbookContext)
            {
                return;
            }

            var item = new ToolStripMenuItem()
            {
                Text = Properties.Resources.TestDataMenuItem_Text,
                Image = Properties.Resources.link_break,
            };

            item.Click += this.item_Click1;
            this.contextMenuStrip1.Items.Add(item);

            if (0 == workbookContext.TestCases.Count)
            {
                return;
            }

            var testCase = this.SelectedTestCase;
            var id = string.Empty;

            if (null != testCase)
            {
                id = testCase.DataName;
            }

            var listObjects = ListObjectHelper.GetDataList(workbookContext.Workbook);

            foreach (var listObject in listObjects)
            {
                item = new ToolStripMenuItem()
                {
                    Text = ListObjectHelper.GetWorksheetName(listObject),
                    Tag = listObject,
                    Checked = listObject.Name == id,
                    //Image = Properties.Resources.database,
                };

                item.Click += this.item_Click2;
                this.contextMenuStrip1.Items.Add(item);
            }
        }

        private void item_Click1(object sender, EventArgs e)
        {
            // Clear Test Data Binding

            var testCase = this.SelectedTestCase;

            if (null == testCase)
            {
                return;
            }

            testCase.DataName = string.Empty;
        }

        private void item_Click2(object sender, EventArgs e)
        {
            // Set Test Data Binging

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Excel.ListObject listObject = (Excel.ListObject)item.Tag;
            var testCase = this.SelectedTestCase;

            if (null == testCase)
            {
                return;
            }

            testCase.DataName = listObject.Name;
        }
    }
}
