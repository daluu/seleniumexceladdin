// Copyright (c) 2014 Takashi Yoshizawa

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;

namespace SeleniumExcelAddIn
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }

            ActionManager.Bind(ActionId.SyntaxCheck, this.syntaxCheckButton);
            ActionManager.Bind(ActionId.Run, this.runButton);
            ActionManager.Bind(ActionId.RunOnlyFailed, this.runOnlyFailedButton);
            ActionManager.Bind(ActionId.RunCurrentSheet, this.runCurrentButton);
            ActionManager.Bind(ActionId.ShowVersion, this.showVersionButton);
            ActionManager.Bind(ActionId.ToggleListPaneVisible, this.toggleListPaneVisibleButton);
            ActionManager.Bind(ActionId.AddTestCase, this.createScenarioButton);
            ActionManager.Bind(ActionId.AddTestData, this.createTestDataButton);
            ActionManager.Bind(ActionId.WebDriverInternetExplorer, this.ieButton);
            ActionManager.Bind(ActionId.WebDriverFirefox, this.firefoxButton);
            ActionManager.Bind(ActionId.WebDriverChrome, this.chromeButton);
            ActionManager.Bind(ActionId.EvidenceNext, this.nextButton);
            ActionManager.Bind(ActionId.EvidencePrev, this.prevButton);
            ActionManager.Bind(ActionId.EvidenceDeleteAll, this.deleteAllEvidenceButton);
            ActionManager.Bind(ActionId.EvidenceRecordFailed, this.failedEvidenceRecordButton);
            ActionManager.Bind(ActionId.EvidenceRecordPassed, this.passedEvidenceRecordButton);
            ActionManager.Bind(ActionId.HelpPaneVisible, this.helpButton);
            ActionManager.Bind(ActionId.BaseUrl, this.baseUrlButton);
            ActionManager.Bind(ActionId.ImportTestcase, this.importTestcaseButton);
            ActionManager.Bind(ActionId.Recording, this.recodingButton);
#if DEBUG
            this.debugGroup.Visible = true;
#else
            this.debugGroup.Visible = false;
#endif

            switch (App.OfficeVersion)
            {
                case OfficeVersion.v2013:
                    this.tab1.Label = this.tab1.Label.ToUpper();
                    break;
            }
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-jp");
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            var c = new Tools.ReferenceConverter();
            var s = c.Convert();

            File.WriteAllText(Path.Combine(App.TempDir, "commands.html"), s);
        }
    }
}
