// Copyright (c) 2014 Takashi Yoshizawa

using System;
using SeleniumExcelAddIn.Actions;

namespace SeleniumExcelAddIn
{
    public enum ActionId
    {
        [Action(typeof(RefreshAction))]
        Refresh,

        [Action(typeof(RunAction))]
        Run,

        [Action(typeof(RunOnlyFailedAction))]
        RunOnlyFailed,

        [Action(typeof(RunCurrentAction))]
        RunCurrentSheet,

        [Action(typeof(SyntaxCheckAction))]
        SyntaxCheck,

        [Action(typeof(ShowVersionAction))]
        ShowVersion,
        
        [Action(typeof(ToggleListPaneVisibleAction))]
        ToggleListPaneVisible,

        [Action(typeof(TestCaseAddAction))]
        AddTestCase,

        [Action(typeof(TestDataAddAction))]
        AddTestData,

        [Action(typeof(WebDriverInternetExplorerAction))]
        WebDriverInternetExplorer,

        [Action(typeof(WebDriverFirefoxAction))]
        WebDriverFirefox,

        [Action(typeof(WebDriverChromeAction))]
        WebDriverChrome,

        [Action(typeof(TestCaseCheckedAllAction))]
        TestCaseCheckedAll,

        [Action(typeof(TestCaseUncheckedAllAction))]
        TestCaseUncheckedAll,

        [Action(typeof(TestCaseCheckedToggleAction))]
        TestCaseCheckedToggle,

        [Action(typeof(EvidenceNextAction))]
        ErrorNext,

        [Action(typeof(EvidencePrevAction))]
        ErrorPrev,

        [Action(typeof(EvidenceDeleteAllAction))]
        EvidenceDeleteAll,

        [Action(typeof(EvidenceNextAction))]
        EvidenceNext,

        [Action(typeof(EvidencePrevAction))]
        EvidencePrev,

        [Action(typeof(EvidenceRecordFailedAction))]
        EvidenceRecordFailed,

        [Action(typeof(EvidenceRecordPassedAction))]
        EvidenceRecordPassed,

        [Action(typeof(HelpAction))]
        Help,

        [Action(typeof(BaseUrlAction))]
        BaseUrl,

        [Action(typeof(CheckNewVersionAction))]
        CheckNewVersion,

        [Action(typeof(ImportTestcaseAction))]
        ImportTestcase,

        [Action(typeof(ToggleHelpPaneVisibleAction))]
        HelpPaneVisible,

        [Action(typeof(RecordingAction))]
        Recording,

        [Action(typeof(RecordingStartAction))]
        RecordingStart,

        [Action(typeof(RecordingStopAction))]
        RecordingStop,
    }
}
