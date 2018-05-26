using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExcelAddIn;

namespace SeleniumExcelAddIn.v2010.Test
{
    [TestClass()]
    public class TestCommandSyntaxTest
    {
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContextInstance;

        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region


        [TestMethod]
        public void AnswerOnNextPromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AnswerOnNextPrompt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertAlertSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertAlert");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertAlertNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertAlertNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertAlertPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertAlertPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertAttributeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertAttribute");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertBodyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertBodyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertCheckedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertChecked");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertConfirmation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertConfirmationNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertConfirmationNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertConfirmationPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertConfirmationPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertCookieByNameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertCookieByName");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertCookieNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertCookieNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertCookiePresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertCookiePresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertEditableSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertEditable");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertElementHeightSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertElementHeight");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertElementNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertElementNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertElementPositionLeftSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertElementPositionLeft");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertElementPositionTopSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertElementPositionTop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertElementPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertElementPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertElementWidthSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertElementWidth");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertLocationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertLocation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotAlertSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotAlert");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotAttributeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotAttribute");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotBodyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotBodyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotCheckedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotChecked");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotConfirmation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotCookieByNameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotCookieByName");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotEditableSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotEditable");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotElementHeightSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotElementHeight");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotElementPositionLeftSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotElementPositionLeft");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotElementPositionTopSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotElementPositionTop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotElementWidthSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotElementWidth");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotLocationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotLocation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotPromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotPrompt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedIdSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedId");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedIdsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedIds");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedIndexSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedIndex");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedIndexesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedIndexes");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedLabelSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedLabel");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedLabelsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedLabels");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectedValuesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectedValues");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSelectOptionsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSelectOptions");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotSomethingSelectedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotSomethingSelected");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotTitleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotTitle");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertNotVisibleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertNotVisible");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertPromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertPrompt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertPromptNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertPromptNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertPromptPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertPromptPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedIdSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedId");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedIdsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedIds");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedIndexSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedIndex");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedIndexesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedIndexes");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedLabelSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedLabel");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedLabelsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedLabels");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectedValuesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectedValues");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSelectOptionsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSelectOptions");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertSomethingSelectedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertSomethingSelected");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertTextNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertTextNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertTextPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertTextPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertTitleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertTitle");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void AssertVisibleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("AssertVisible");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void CaptureEntirePageScreenshotSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("CaptureEntirePageScreenshot");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void CaptureEntirePageScreenshotAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("CaptureEntirePageScreenshotAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void CheckSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Check");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void CheckAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("CheckAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ChooseCancelOnNextConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ChooseCancelOnNextConfirmation");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ChooseOkOnNextConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ChooseOkOnNextConfirmation");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ChooseOkOnNextConfirmationAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ChooseOkOnNextConfirmationAndWait");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ClickSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Click");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ClickAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ClickAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ClickAtSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ClickAt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ClickAtAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ClickAtAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void CloseSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Close");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ContextMenuSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ContextMenu");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ContextMenuAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ContextMenuAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ContextMenuAtSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ContextMenuAt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void ContextMenuAtAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("ContextMenuAtAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void CreateCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("CreateCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void CreateCookieAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("CreateCookieAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DeleteAllVisibleCookiesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DeleteAllVisibleCookies");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DeleteAllVisibleCookiesAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DeleteAllVisibleCookiesAndWait");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DeleteCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DeleteCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DeleteCookieAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DeleteCookieAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DoubleClickSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DoubleClick");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DoubleClickAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DoubleClickAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DoubleClickAtSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DoubleClickAt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DoubleClickAtAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DoubleClickAtAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DragAndDropSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DragAndDrop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DragAndDropAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DragAndDropAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DragAndDropToObjectSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DragAndDropToObject");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void DragAndDropToObjectAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("DragAndDropToObjectAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void EchoSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Echo");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void FocusSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Focus");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void FocusAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("FocusAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void GoBackSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("GoBack");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void GoBackAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("GoBackAndWait");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void GoForwardSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("GoForward");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void GoForwardAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("GoForwardAndWait");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseDownSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseDown");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseDownAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseDownAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseDownAtSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseDownAt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseDownAtAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseDownAtAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseMoveSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseMove");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseMoveAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseMoveAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseMoveAtSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseMoveAt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseMoveAtAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseMoveAtAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseUpSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseUp");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseUpAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseUpAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseUpAtSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseUpAt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void MouseUpAtAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("MouseUpAtAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void OpenSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Open");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void OpenWindowSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("OpenWindow");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void OpenWindowAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("OpenWindowAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void PauseSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Pause");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void RefreshSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Refresh");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void RefreshAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("RefreshAndWait");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SelectSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Select");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SelectAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SelectAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SelectFrameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SelectFrame");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SelectPopUpSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SelectPopUp");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SelectPopUpAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SelectPopUpAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SelectWindowSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SelectWindow");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SendKeysSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SendKeys");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SetTimeoutSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SetTimeout");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Store");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreAlertSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreAlert");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreAttributeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreAttribute");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreBodyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreBodyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreCheckedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreChecked");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreConfirmation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreConfirmationPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreConfirmationPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreCookieByNameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreCookieByName");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreCookiePresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreCookiePresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreEditableSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreEditable");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreElementHeightSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreElementHeight");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreElementPositionLeftSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreElementPositionLeft");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreElementPositionTopSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreElementPositionTop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreElementPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreElementPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreElementWidthSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreElementWidth");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreLocationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreLocation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StorePromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StorePrompt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StorePromptPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StorePromptPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedIdSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedId");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedIdsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedIds");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedIndexSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedIndex");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedIndexesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedIndexes");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedLabelSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedLabel");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedLabelsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedLabels");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectedValuesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectedValues");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSelectOptionsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSelectOptions");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreSomethingSelectedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreSomethingSelected");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreTextPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreTextPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreTitleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreTitle");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void StoreVisibleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("StoreVisible");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SubmitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Submit");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void SubmitAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("SubmitAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void TypeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Type");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void TypeAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("TypeAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void TypeKeysSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("TypeKeys");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void TypeKeysAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("TypeKeysAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void UncheckSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("Uncheck");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void UncheckAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("UncheckAndWait");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VBASyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VBA");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyAlertSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyAlert");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyAlertNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyAlertNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyAlertPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyAlertPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyAttributeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyAttribute");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyBodyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyBodyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyCheckedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyChecked");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyConfirmation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyConfirmationNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyConfirmationNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyConfirmationPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyConfirmationPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyCookieByNameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyCookieByName");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyCookieNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyCookieNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyCookiePresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyCookiePresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyEditableSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyEditable");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyElementHeightSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyElementHeight");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyElementNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyElementNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyElementPositionLeftSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyElementPositionLeft");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyElementPositionTopSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyElementPositionTop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyElementPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyElementPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyElementWidthSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyElementWidth");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyLocationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyLocation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotAlertSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotAlert");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotAttributeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotAttribute");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotBodyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotBodyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotCheckedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotChecked");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotConfirmation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotCookieByNameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotCookieByName");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotEditableSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotEditable");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotElementHeightSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotElementHeight");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotElementPositionLeftSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotElementPositionLeft");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotElementPositionTopSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotElementPositionTop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotElementWidthSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotElementWidth");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotLocationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotLocation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotPromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotPrompt");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedIdSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedId");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedIdsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedIds");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedIndexSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedIndex");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedIndexesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedIndexes");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedLabelSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedLabel");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedLabelsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedLabels");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectedValuesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectedValues");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSelectOptionsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSelectOptions");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotSomethingSelectedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotSomethingSelected");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotTitleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotTitle");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyNotVisibleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyNotVisible");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyPromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyPrompt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyPromptNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyPromptNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyPromptPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyPromptPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectedIdSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectedId");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectedIdsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectedIds");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectedIndexSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectedIndex");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectedLabelSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectedLabel");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectedLabelsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectedLabels");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectedValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectedValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectedValuesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectedValues");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySelectOptionsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySelectOptions");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifySomethingSelectedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifySomethingSelected");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyTextNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyTextNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyTextPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyTextPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyTitleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyTitle");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void VerifyVisibleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("VerifyVisible");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForAlertSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForAlert");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForAlertNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForAlertNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForAlertPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForAlertPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForAttributeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForAttribute");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForBodyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForBodyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForCheckedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForChecked");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForConfirmation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForConfirmationNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForConfirmationNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForConfirmationPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForConfirmationPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForCookieByNameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForCookieByName");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForCookieNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForCookieNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForCookiePresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForCookiePresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForEditableSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForEditable");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForElementHeightSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForElementHeight");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForElementNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForElementNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForElementPositionLeftSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForElementPositionLeft");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForElementPositionTopSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForElementPositionTop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForElementPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForElementPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForElementWidthSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForElementWidth");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForFrameToLoadSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForFrameToLoad");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForLocationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForLocation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotAlertSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotAlert");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotAttributeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotAttribute");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotBodyTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotBodyText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotCheckedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotChecked");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotConfirmationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotConfirmation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotCookieSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotCookie");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotCookieByNameSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotCookieByName");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotEditableSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotEditable");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotElementHeightSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotElementHeight");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotElementPositionLeftSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotElementPositionLeft");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotElementPositionTopSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotElementPositionTop");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotElementWidthSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotElementWidth");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotLocationSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotLocation");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotPromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotPrompt");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedIdSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedId");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedIdsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedIds");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedIndexSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedIndex");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedIndexesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedIndexes");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedLabelSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedLabel");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedLabelsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedLabels");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectedValuesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectedValues");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSelectOptionsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSelectOptions");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotSomethingSelectedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotSomethingSelected");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotTitleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotTitle");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForNotVisibleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForNotVisible");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForPageToLoadSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForPageToLoad");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        //[TestMethod]
        //public void WaitForPopUpSyntaxTest()
        //{
        //    var command = TestCommandFactory.CreateCommand("WaitForPopUp");
        //    Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
        //    Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        //}

        [TestMethod]
        public void WaitForPromptSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForPrompt");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForPromptNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForPromptNotPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForPromptPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForPromptPresent");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedIdSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedId");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedIdsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedIds");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedIndexSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedIndex");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedIndexesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedIndexes");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedLabelSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedLabel");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedLabelsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedLabels");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectedValuesSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectedValues");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSelectOptionsSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSelectOptions");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForSomethingSelectedSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForSomethingSelected");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForTextSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForText");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForTextNotPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForTextNotPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForTextPresentSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForTextPresent");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForTitleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForTitle");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForValueSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForValue");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WaitForVisibleSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WaitForVisible");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        //[TestMethod]
        //public void WindowFocusSyntaxTest()
        //{
        //    var command = TestCommandFactory.CreateCommand("WindowFocus");
        //    Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
        //    Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        //}

        //[TestMethod]
        //public void WindowFocusAndWaitSyntaxTest()
        //{
        //    var command = TestCommandFactory.CreateCommand("WindowFocusAndWait");
        //    Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
        //    Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        //}

        [TestMethod]
        public void WindowMaximizeSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WindowMaximize");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        public void WindowMaximizeAndWaitSyntaxTest()
        {
            var command = TestCommandFactory.CreateCommand("WindowMaximizeAndWait");
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }

        #endregion
    }
}
