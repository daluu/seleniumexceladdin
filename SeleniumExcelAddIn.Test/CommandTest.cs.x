using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExcelAddIn;
using SeleniumExcelAddIn.TestCommands;

namespace SeleniumExcelAddIn.v2010.Test
{
    [TestClass()]
    public class CommandTest
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

        [ClassInitialize()]
        public static void MyClassInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
        }
        
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            context.Driver.Dispose();
        }
        
        [TestInitialize()]
        public void MyTestInitialize()
        {
            context.Driver.Url = "http://selenium-excel-addin.jpn.org/test.html";
            context.Driver.Navigate().Refresh();
        }
        
        [TestCleanup()]
        public void MyTestCleanup()
        {
        }

        private static TestContextMock context = new TestContextMock();

        #region

        #region AddLocationStrategy

        //[TestMethod]
        //public void AddLocationStrategy1()
        //{
        //    var cmd = new x_AddLocationStrategyCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AddLocationStrategy2()
        //{
        //    var cmd = new x_AddLocationStrategyCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AddLocationStrategy3()
        //{
        //    var cmd = new x_AddLocationStrategyCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AddLocationStrategyAndWait

        //[TestMethod]
        //public void AddLocationStrategyAndWait1()
        //{
        //    var cmd = new x_AddLocationStrategyAndWaitCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AddLocationStrategyAndWait2()
        //{
        //    var cmd = new x_AddLocationStrategyAndWaitCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AddLocationStrategyAndWait3()
        //{
        //    var cmd = new x_AddLocationStrategyAndWaitCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AddScript

        //[TestMethod]
        //public void AddScript1()
        //{
        //    var cmd = new x_AddScriptCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AddScript2()
        //{
        //    var cmd = new x_AddScriptCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AddScript3()
        //{
        //    var cmd = new x_AddScriptCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AddScriptAndWait

        //[TestMethod]
        //public void AddScriptAndWait1()
        //{
        //    var cmd = new x_AddScriptAndWaitCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AddScriptAndWait2()
        //{
        //    var cmd = new x_AddScriptAndWaitCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AddScriptAndWait3()
        //{
        //    var cmd = new x_AddScriptAndWaitCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AddSelection

        //[TestMethod]
        //public void AddSelection1()
        //{
        //    var cmd = new x_AddSelectionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AddSelection2()
        //{
        //    var cmd = new x_AddSelectionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AddSelection3()
        //{
        //    var cmd = new x_AddSelectionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AddSelectionAndWait

        //[TestMethod]
        //public void AddSelectionAndWait1()
        //{
        //    var cmd = new x_AddSelectionAndWaitCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AddSelectionAndWait2()
        //{
        //    var cmd = new x_AddSelectionAndWaitCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AddSelectionAndWait3()
        //{
        //    var cmd = new x_AddSelectionAndWaitCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AllowNativeXpath

        //[TestMethod]
        //public void AllowNativeXpath1()
        //{
        //    var cmd = new x_AllowNativeXpathCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AllowNativeXpath2()
        //{
        //    var cmd = new x_AllowNativeXpathCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AllowNativeXpath3()
        //{
        //    var cmd = new x_AllowNativeXpathCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AllowNativeXpathAndWait

        //[TestMethod]
        //public void AllowNativeXpathAndWait1()
        //{
        //    var cmd = new x_AllowNativeXpathAndWaitCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AllowNativeXpathAndWait2()
        //{
        //    var cmd = new x_AllowNativeXpathAndWaitCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AllowNativeXpathAndWait3()
        //{
        //    var cmd = new x_AllowNativeXpathAndWaitCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AltKeyDown

        [TestMethod]
        public void AltKeyDown1()
        {
            var cmd = new x_AltKeyDownCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AltKeyDown2()
        {
            var cmd = new x_AltKeyDownCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AltKeyDown3()
        {
            var cmd = new x_AltKeyDownCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AltKeyDownAndWait

        [TestMethod]
        public void AltKeyDownAndWait1()
        {
            var cmd = new x_AltKeyDownAndWaitCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AltKeyDownAndWait2()
        {
            var cmd = new x_AltKeyDownAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AltKeyDownAndWait3()
        {
            var cmd = new x_AltKeyDownAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AltKeyUp

        [TestMethod]
        public void AltKeyUp1()
        {
            var cmd = new x_AltKeyUpCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AltKeyUp2()
        {
            var cmd = new x_AltKeyUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AltKeyUp3()
        {
            var cmd = new x_AltKeyUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AltKeyUpAndWait

        [TestMethod]
        public void AltKeyUpAndWait1()
        {
            var cmd = new x_AltKeyUpAndWaitCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AltKeyUpAndWait2()
        {
            var cmd = new x_AltKeyUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AltKeyUpAndWait3()
        {
            var cmd = new x_AltKeyUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AnswerOnNextPrompt

        [TestMethod]
        public void AnswerOnNextPrompt1()
        {
            var cmd = new AnswerOnNextPromptCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnswerOnNextPrompt2()
        {
            var cmd = new AnswerOnNextPromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AnswerOnNextPrompt3()
        {
            var cmd = new AnswerOnNextPromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertAlert

        [TestMethod]
        public void AssertAlert1()
        {
            var cmd = new AssertAlertCommand();
            var flag = cmd.Syntax;
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertAlert2()
        {
            var cmd = new AssertAlertCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertAlert3()
        {
            var cmd = new AssertAlertCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertAlertNotPresent

        [TestMethod]
        public void AssertAlertNotPresent1()
        {
            var cmd = new AssertAlertNotPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertAlertNotPresent2()
        {
            var cmd = new AssertAlertNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertAlertNotPresent3()
        {
            var cmd = new AssertAlertNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertAlertPresent

        [TestMethod]
        public void AssertAlertPresent1()
        {
            var cmd = new AssertAlertPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertAlertPresent2()
        {
            var cmd = new AssertAlertPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertAlertPresent3()
        {
            var cmd = new AssertAlertPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertAllButtons

        //[TestMethod]
        //public void AssertAllButtons1()
        //{
        //    var cmd = new x_AssertAllButtonsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertAllButtons2()
        //{
        //    var cmd = new x_AssertAllButtonsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertAllButtons3()
        //{
        //    var cmd = new x_AssertAllButtonsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertAllFields

        //[TestMethod]
        //public void AssertAllFields1()
        //{
        //    var cmd = new x_AssertAllFieldsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertAllFields2()
        //{
        //    var cmd = new x_AssertAllFieldsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertAllFields3()
        //{
        //    var cmd = new x_AssertAllFieldsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertAllLinks

        //[TestMethod]
        //public void AssertAllLinks1()
        //{
        //    var cmd = new x_AssertAllLinksCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertAllLinks2()
        //{
        //    var cmd = new x_AssertAllLinksCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertAllLinks3()
        //{
        //    var cmd = new x_AssertAllLinksCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertAllWindowIds

        //[TestMethod]
        //public void AssertAllWindowIds1()
        //{
        //    var cmd = new x_AssertAllWindowIdsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertAllWindowIds2()
        //{
        //    var cmd = new x_AssertAllWindowIdsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertAllWindowIds3()
        //{
        //    var cmd = new x_AssertAllWindowIdsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertAllWindowNames

        //[TestMethod]
        //public void AssertAllWindowNames1()
        //{
        //    var cmd = new x_AssertAllWindowNamesCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertAllWindowNames2()
        //{
        //    var cmd = new x_AssertAllWindowNamesCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertAllWindowNames3()
        //{
        //    var cmd = new x_AssertAllWindowNamesCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertAllWindowTitles

        //[TestMethod]
        //public void AssertAllWindowTitles1()
        //{
        //    var cmd = new x_AssertAllWindowTitlesCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertAllWindowTitles2()
        //{
        //    var cmd = new x_AssertAllWindowTitlesCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertAllWindowTitles3()
        //{
        //    var cmd = new x_AssertAllWindowTitlesCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertAttribute

        [TestMethod]
        public void AssertAttribute1()
        {
            var cmd = new AssertAttributeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertAttribute2()
        {
            var cmd = new AssertAttributeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertAttribute3()
        {
            var cmd = new AssertAttributeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertAttributeFromAllWindows

        //[TestMethod]
        //public void AssertAttributeFromAllWindows1()
        //{
        //    var cmd = new x_AssertAttributeFromAllWindowsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertAttributeFromAllWindows2()
        //{
        //    var cmd = new x_AssertAttributeFromAllWindowsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertAttributeFromAllWindows3()
        //{
        //    var cmd = new x_AssertAttributeFromAllWindowsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertBodyText

        [TestMethod]
        public void AssertBodyText1()
        {
            var cmd = new AssertBodyTextCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertBodyText2()
        {
            var cmd = new AssertBodyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertBodyText3()
        {
            var cmd = new AssertBodyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertChecked

        [TestMethod]
        public void AssertChecked1()
        {
            var cmd = new AssertCheckedCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertChecked2()
        {
            var cmd = new AssertCheckedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertChecked3()
        {
            var cmd = new AssertCheckedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertConfirmation

        [TestMethod]
        public void AssertConfirmation1()
        {
            var cmd = new AssertConfirmationCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertConfirmation2()
        {
            var cmd = new AssertConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertConfirmation3()
        {
            var cmd = new AssertConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertConfirmationNotPresent

        [TestMethod]
        public void AssertConfirmationNotPresent1()
        {
            var cmd = new AssertConfirmationNotPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertConfirmationNotPresent2()
        {
            var cmd = new AssertConfirmationNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertConfirmationNotPresent3()
        {
            var cmd = new AssertConfirmationNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertConfirmationPresent

        [TestMethod]
        public void AssertConfirmationPresent1()
        {
            var cmd = new AssertConfirmationPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertConfirmationPresent2()
        {
            var cmd = new AssertConfirmationPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertConfirmationPresent3()
        {
            var cmd = new AssertConfirmationPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertCookie

        [TestMethod]
        public void AssertCookie1()
        {
            var cmd = new AssertCookieCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertCookie2()
        {
            var cmd = new AssertCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertCookie3()
        {
            var cmd = new AssertCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertCookieByName

        [TestMethod]
        public void AssertCookieByName1()
        {
            var cmd = new AssertCookieByNameCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertCookieByName2()
        {
            var cmd = new AssertCookieByNameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertCookieByName3()
        {
            var cmd = new AssertCookieByNameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertCookieNotPresent

        [TestMethod]
        public void AssertCookieNotPresent1()
        {
            var cmd = new AssertCookieNotPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertCookieNotPresent2()
        {
            var cmd = new AssertCookieNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertCookieNotPresent3()
        {
            var cmd = new AssertCookieNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertCookiePresent

        [TestMethod]
        public void AssertCookiePresent1()
        {
            var cmd = new AssertCookiePresentCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertCookiePresent2()
        {
            var cmd = new AssertCookiePresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertCookiePresent3()
        {
            var cmd = new AssertCookiePresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertCursorPosition

        //[TestMethod]
        //public void AssertCursorPosition1()
        //{
        //    var cmd = new x_AssertCursorPositionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertCursorPosition2()
        //{
        //    var cmd = new x_AssertCursorPositionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertCursorPosition3()
        //{
        //    var cmd = new x_AssertCursorPositionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertEditable

        [TestMethod]
        public void AssertEditable1()
        {
            var cmd = new AssertEditableCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertEditable2()
        {
            var cmd = new AssertEditableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertEditable3()
        {
            var cmd = new AssertEditableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertElementHeight

        [TestMethod]
        public void AssertElementHeight1()
        {
            var cmd = new AssertElementHeightCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertElementHeight2()
        {
            var cmd = new AssertElementHeightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertElementHeight3()
        {
            var cmd = new AssertElementHeightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertElementIndex

        //[TestMethod]
        //public void AssertElementIndex1()
        //{
        //    var cmd = new x_AssertElementIndexCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertElementIndex2()
        //{
        //    var cmd = new x_AssertElementIndexCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertElementIndex3()
        //{
        //    var cmd = new x_AssertElementIndexCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertElementNotPresent

        [TestMethod]
        public void AssertElementNotPresent1()
        {
            var cmd = new AssertElementNotPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertElementNotPresent2()
        {
            var cmd = new AssertElementNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertElementNotPresent3()
        {
            var cmd = new AssertElementNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertElementPositionLeft

        [TestMethod]
        public void AssertElementPositionLeft1()
        {
            var cmd = new AssertElementPositionLeftCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertElementPositionLeft2()
        {
            var cmd = new AssertElementPositionLeftCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertElementPositionLeft3()
        {
            var cmd = new AssertElementPositionLeftCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertElementPositionTop

        [TestMethod]
        public void AssertElementPositionTop1()
        {
            var cmd = new AssertElementPositionTopCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertElementPositionTop2()
        {
            var cmd = new AssertElementPositionTopCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertElementPositionTop3()
        {
            var cmd = new AssertElementPositionTopCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertElementPresent

        [TestMethod]
        public void AssertElementPresent1()
        {
            var cmd = new AssertElementPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertElementPresent2()
        {
            var cmd = new AssertElementPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertElementPresent3()
        {
            var cmd = new AssertElementPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertElementWidth

        [TestMethod]
        public void AssertElementWidth1()
        {
            var cmd = new AssertElementWidthCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertElementWidth2()
        {
            var cmd = new AssertElementWidthCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertElementWidth3()
        {
            var cmd = new AssertElementWidthCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertEval

        //[TestMethod]
        //public void AssertEval1()
        //{
        //    var cmd = new x_AssertEvalCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertEval2()
        //{
        //    var cmd = new x_AssertEvalCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertEval3()
        //{
        //    var cmd = new x_AssertEvalCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertExpression

        //[TestMethod]
        //public void AssertExpression1()
        //{
        //    var cmd = new x_AssertExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertExpression2()
        //{
        //    var cmd = new x_AssertExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertExpression3()
        //{
        //    var cmd = new x_AssertExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertHtmlSource

        //[TestMethod]
        //public void AssertHtmlSource1()
        //{
        //    var cmd = new x_AssertHtmlSourceCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertHtmlSource2()
        //{
        //    var cmd = new x_AssertHtmlSourceCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertHtmlSource3()
        //{
        //    var cmd = new x_AssertHtmlSourceCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertLocation

        [TestMethod]
        public void AssertLocation1()
        {
            var cmd = new AssertLocationCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertLocation2()
        {
            var cmd = new AssertLocationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertLocation3()
        {
            var cmd = new AssertLocationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertMouseSpeed

        //[TestMethod]
        //public void AssertMouseSpeed1()
        //{
        //    var cmd = new x_AssertMouseSpeedCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertMouseSpeed2()
        //{
        //    var cmd = new x_AssertMouseSpeedCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertMouseSpeed3()
        //{
        //    var cmd = new x_AssertMouseSpeedCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotAlert

        [TestMethod]
        public void AssertNotAlert1()
        {
            var cmd = new AssertNotAlertCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotAlert2()
        {
            var cmd = new AssertNotAlertCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotAlert3()
        {
            var cmd = new AssertNotAlertCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotAllButtons

        //[TestMethod]
        //public void AssertNotAllButtons1()
        //{
        //    var cmd = new x_AssertNotAllButtonsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotAllButtons2()
        //{
        //    var cmd = new x_AssertNotAllButtonsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotAllButtons3()
        //{
        //    var cmd = new x_AssertNotAllButtonsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotAllFields

        //[TestMethod]
        //public void AssertNotAllFields1()
        //{
        //    var cmd = new x_AssertNotAllFieldsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotAllFields2()
        //{
        //    var cmd = new x_AssertNotAllFieldsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotAllFields3()
        //{
        //    var cmd = new x_AssertNotAllFieldsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotAllLinks

        //[TestMethod]
        //public void AssertNotAllLinks1()
        //{
        //    var cmd = new x_AssertNotAllLinksCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotAllLinks2()
        //{
        //    var cmd = new x_AssertNotAllLinksCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotAllLinks3()
        //{
        //    var cmd = new x_AssertNotAllLinksCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotAllWindowIds

        //[TestMethod]
        //public void AssertNotAllWindowIds1()
        //{
        //    var cmd = new x_AssertNotAllWindowIdsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotAllWindowIds2()
        //{
        //    var cmd = new x_AssertNotAllWindowIdsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotAllWindowIds3()
        //{
        //    var cmd = new x_AssertNotAllWindowIdsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotAllWindowNames

        //[TestMethod]
        //public void AssertNotAllWindowNames1()
        //{
        //    var cmd = new x_AssertNotAllWindowNamesCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotAllWindowNames2()
        //{
        //    var cmd = new x_AssertNotAllWindowNamesCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotAllWindowNames3()
        //{
        //    var cmd = new x_AssertNotAllWindowNamesCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotAllWindowTitles

        //[TestMethod]
        //public void AssertNotAllWindowTitles1()
        //{
        //    var cmd = new x_AssertNotAllWindowTitlesCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotAllWindowTitles2()
        //{
        //    var cmd = new x_AssertNotAllWindowTitlesCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotAllWindowTitles3()
        //{
        //    var cmd = new x_AssertNotAllWindowTitlesCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotAttribute

        [TestMethod]
        public void AssertNotAttribute1()
        {
            var cmd = new AssertNotAttributeCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotAttribute2()
        {
            var cmd = new AssertNotAttributeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotAttribute3()
        {
            var cmd = new AssertNotAttributeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotAttributeFromAllWindows

        //[TestMethod]
        //public void AssertNotAttributeFromAllWindows1()
        //{
        //    var cmd = new x_AssertNotAttributeFromAllWindowsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotAttributeFromAllWindows2()
        //{
        //    var cmd = new x_AssertNotAttributeFromAllWindowsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotAttributeFromAllWindows3()
        //{
        //    var cmd = new x_AssertNotAttributeFromAllWindowsCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotBodyText

        [TestMethod]
        public void AssertNotBodyText1()
        {
            var cmd = new AssertNotBodyTextCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotBodyText2()
        {
            var cmd = new AssertNotBodyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotBodyText3()
        {
            var cmd = new AssertNotBodyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotChecked

        [TestMethod]
        public void AssertNotChecked1()
        {
            var cmd = new AssertNotCheckedCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotChecked2()
        {
            var cmd = new AssertNotCheckedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotChecked3()
        {
            var cmd = new AssertNotCheckedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotConfirmation

        [TestMethod]
        public void AssertNotConfirmation1()
        {
            var cmd = new AssertNotConfirmationCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotConfirmation2()
        {
            var cmd = new AssertNotConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotConfirmation3()
        {
            var cmd = new AssertNotConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotCookie

        [TestMethod]
        public void AssertNotCookie1()
        {
            var cmd = new AssertNotCookieCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotCookie2()
        {
            var cmd = new AssertNotCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotCookie3()
        {
            var cmd = new AssertNotCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotCookieByName

        [TestMethod]
        public void AssertNotCookieByName1()
        {
            var cmd = new AssertNotCookieByNameCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotCookieByName2()
        {
            var cmd = new AssertNotCookieByNameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotCookieByName3()
        {
            var cmd = new AssertNotCookieByNameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotCursorPosition

        //[TestMethod]
        //public void AssertNotCursorPosition1()
        //{
        //    var cmd = new x_AssertNotCursorPositionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotCursorPosition2()
        //{
        //    var cmd = new x_AssertNotCursorPositionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotCursorPosition3()
        //{
        //    var cmd = new x_AssertNotCursorPositionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotEditable

        [TestMethod]
        public void AssertNotEditable1()
        {
            var cmd = new AssertNotEditableCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotEditable2()
        {
            var cmd = new AssertNotEditableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotEditable3()
        {
            var cmd = new AssertNotEditableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotElementHeight

        [TestMethod]
        public void AssertNotElementHeight1()
        {
            var cmd = new AssertNotElementHeightCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotElementHeight2()
        {
            var cmd = new AssertNotElementHeightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotElementHeight3()
        {
            var cmd = new AssertNotElementHeightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotElementIndex

        //[TestMethod]
        //public void AssertNotElementIndex1()
        //{
        //    var cmd = new x_AssertNotElementIndexCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotElementIndex2()
        //{
        //    var cmd = new x_AssertNotElementIndexCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotElementIndex3()
        //{
        //    var cmd = new x_AssertNotElementIndexCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotElementPositionLeft

        [TestMethod]
        public void AssertNotElementPositionLeft1()
        {
            var cmd = new AssertNotElementPositionLeftCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotElementPositionLeft2()
        {
            var cmd = new AssertNotElementPositionLeftCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotElementPositionLeft3()
        {
            var cmd = new AssertNotElementPositionLeftCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotElementPositionTop

        [TestMethod]
        public void AssertNotElementPositionTop1()
        {
            var cmd = new AssertNotElementPositionTopCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotElementPositionTop2()
        {
            var cmd = new AssertNotElementPositionTopCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotElementPositionTop3()
        {
            var cmd = new AssertNotElementPositionTopCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotElementWidth

        [TestMethod]
        public void AssertNotElementWidth1()
        {
            var cmd = new AssertNotElementWidthCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotElementWidth2()
        {
            var cmd = new AssertNotElementWidthCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotElementWidth3()
        {
            var cmd = new AssertNotElementWidthCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotEval

        //[TestMethod]
        //public void AssertNotEval1()
        //{
        //    var cmd = new x_AssertNotEvalCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotEval2()
        //{
        //    var cmd = new x_AssertNotEvalCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotEval3()
        //{
        //    var cmd = new x_AssertNotEvalCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotExpression

        //[TestMethod]
        //public void AssertNotExpression1()
        //{
        //    var cmd = new x_AssertNotExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotExpression2()
        //{
        //    var cmd = new x_AssertNotExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotExpression3()
        //{
        //    var cmd = new x_AssertNotExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotHtmlSource

        //[TestMethod]
        //public void AssertNotHtmlSource1()
        //{
        //    var cmd = new x_AssertNotHtmlSourceCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotHtmlSource2()
        //{
        //    var cmd = new x_AssertNotHtmlSourceCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotHtmlSource3()
        //{
        //    var cmd = new x_AssertNotHtmlSourceCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotLocation

        [TestMethod]
        public void AssertNotLocation1()
        {
            var cmd = new AssertNotLocationCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotLocation2()
        {
            var cmd = new AssertNotLocationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotLocation3()
        {
            var cmd = new AssertNotLocationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotMouseSpeed

        //[TestMethod]
        //public void AssertNotMouseSpeed1()
        //{
        //    var cmd = new x_AssertNotMouseSpeedCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotMouseSpeed2()
        //{
        //    var cmd = new x_AssertNotMouseSpeedCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotMouseSpeed3()
        //{
        //    var cmd = new x_AssertNotMouseSpeedCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotOrdered

        //[TestMethod]
        //public void AssertNotOrdered1()
        //{
        //    var cmd = new x_AssertNotOrderedCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotOrdered2()
        //{
        //    var cmd = new x_AssertNotOrderedCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotOrdered3()
        //{
        //    var cmd = new x_AssertNotOrderedCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotPrompt

        [TestMethod]
        public void AssertNotPrompt1()
        {
            var cmd = new AssertNotPromptCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotPrompt2()
        {
            var cmd = new AssertNotPromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotPrompt3()
        {
            var cmd = new AssertNotPromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectOptions

        [TestMethod]
        public void AssertNotSelectOptions1()
        {
            var cmd = new AssertNotSelectOptionsCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectOptions2()
        {
            var cmd = new AssertNotSelectOptionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectOptions3()
        {
            var cmd = new AssertNotSelectOptionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedId

        [TestMethod]
        public void AssertNotSelectedId1()
        {
            var cmd = new AssertNotSelectedIdCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedId2()
        {
            var cmd = new AssertNotSelectedIdCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedId3()
        {
            var cmd = new AssertNotSelectedIdCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedIds

        [TestMethod]
        public void AssertNotSelectedIds1()
        {
            var cmd = new AssertNotSelectedIdsCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedIds2()
        {
            var cmd = new AssertNotSelectedIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedIds3()
        {
            var cmd = new AssertNotSelectedIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedIndex

        [TestMethod]
        public void AssertNotSelectedIndex1()
        {
            var cmd = new AssertNotSelectedIndexCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedIndex2()
        {
            var cmd = new AssertNotSelectedIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedIndex3()
        {
            var cmd = new AssertNotSelectedIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedIndexes

        [TestMethod]
        public void AssertNotSelectedIndexes1()
        {
            var cmd = new AssertNotSelectedIndexesCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedIndexes2()
        {
            var cmd = new AssertNotSelectedIndexesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedIndexes3()
        {
            var cmd = new AssertNotSelectedIndexesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedLabel

        [TestMethod]
        public void AssertNotSelectedLabel1()
        {
            var cmd = new AssertNotSelectedLabelCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedLabel2()
        {
            var cmd = new AssertNotSelectedLabelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedLabel3()
        {
            var cmd = new AssertNotSelectedLabelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedLabels

        [TestMethod]
        public void AssertNotSelectedLabels1()
        {
            var cmd = new AssertNotSelectedLabelsCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedLabels2()
        {
            var cmd = new AssertNotSelectedLabelsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedLabels3()
        {
            var cmd = new AssertNotSelectedLabelsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedValue

        [TestMethod]
        public void AssertNotSelectedValue1()
        {
            var cmd = new AssertNotSelectedValueCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedValue2()
        {
            var cmd = new AssertNotSelectedValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedValue3()
        {
            var cmd = new AssertNotSelectedValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSelectedValues

        [TestMethod]
        public void AssertNotSelectedValues1()
        {
            var cmd = new AssertNotSelectedValuesCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSelectedValues2()
        {
            var cmd = new AssertNotSelectedValuesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSelectedValues3()
        {
            var cmd = new AssertNotSelectedValuesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSomethingSelected

        [TestMethod]
        public void AssertNotSomethingSelected1()
        {
            var cmd = new AssertNotSomethingSelectedCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotSomethingSelected2()
        {
            var cmd = new AssertNotSomethingSelectedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotSomethingSelected3()
        {
            var cmd = new AssertNotSomethingSelectedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotSpeed

        //[TestMethod]
        //public void AssertNotSpeed1()
        //{
        //    var cmd = new x_AssertNotSpeedCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotSpeed2()
        //{
        //    var cmd = new x_AssertNotSpeedCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotSpeed3()
        //{
        //    var cmd = new x_AssertNotSpeedCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotTable

        //[TestMethod]
        //public void AssertNotTable1()
        //{
        //    var cmd = new x_AssertNotTableCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotTable2()
        //{
        //    var cmd = new x_AssertNotTableCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotTable3()
        //{
        //    var cmd = new x_AssertNotTableCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotText

        [TestMethod]
        public void AssertNotText1()
        {
            var cmd = new AssertNotTextCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotText2()
        {
            var cmd = new AssertNotTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotText3()
        {
            var cmd = new AssertNotTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotTitle

        [TestMethod]
        public void AssertNotTitle1()
        {
            var cmd = new AssertNotTitleCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotTitle2()
        {
            var cmd = new AssertNotTitleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotTitle3()
        {
            var cmd = new AssertNotTitleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotValue

        [TestMethod]
        public void AssertNotValue1()
        {
            var cmd = new AssertNotValueCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotValue2()
        {
            var cmd = new AssertNotValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotValue3()
        {
            var cmd = new AssertNotValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotVisible

        [TestMethod]
        public void AssertNotVisible1()
        {
            var cmd = new AssertNotVisibleCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertNotVisible2()
        {
            var cmd = new AssertNotVisibleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertNotVisible3()
        {
            var cmd = new AssertNotVisibleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertNotWhetherThisFrameMatchFrameExpression

        //[TestMethod]
        //public void AssertNotWhetherThisFrameMatchFrameExpression1()
        //{
        //    var cmd = new x_AssertNotWhetherThisFrameMatchFrameExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotWhetherThisFrameMatchFrameExpression2()
        //{
        //    var cmd = new x_AssertNotWhetherThisFrameMatchFrameExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotWhetherThisFrameMatchFrameExpression3()
        //{
        //    var cmd = new x_AssertNotWhetherThisFrameMatchFrameExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotWhetherThisWindowMatchWindowExpression

        //[TestMethod]
        //public void AssertNotWhetherThisWindowMatchWindowExpression1()
        //{
        //    var cmd = new x_AssertNotWhetherThisWindowMatchWindowExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotWhetherThisWindowMatchWindowExpression2()
        //{
        //    var cmd = new x_AssertNotWhetherThisWindowMatchWindowExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotWhetherThisWindowMatchWindowExpression3()
        //{
        //    var cmd = new x_AssertNotWhetherThisWindowMatchWindowExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertNotXpathCount

        //[TestMethod]
        //public void AssertNotXpathCount1()
        //{
        //    var cmd = new x_AssertNotXpathCountCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertNotXpathCount2()
        //{
        //    var cmd = new x_AssertNotXpathCountCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertNotXpathCount3()
        //{
        //    var cmd = new x_AssertNotXpathCountCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertOrdered

        //[TestMethod]
        //public void AssertOrdered1()
        //{
        //    var cmd = new x_AssertOrderedCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertOrdered2()
        //{
        //    var cmd = new x_AssertOrderedCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertOrdered3()
        //{
        //    var cmd = new x_AssertOrderedCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertPrompt

        [TestMethod]
        public void AssertPrompt1()
        {
            var cmd = new AssertPromptCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertPrompt2()
        {
            var cmd = new AssertPromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertPrompt3()
        {
            var cmd = new AssertPromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertPromptNotPresent

        [TestMethod]
        public void AssertPromptNotPresent1()
        {
            var cmd = new AssertPromptNotPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertPromptNotPresent2()
        {
            var cmd = new AssertPromptNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertPromptNotPresent3()
        {
            var cmd = new AssertPromptNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertPromptPresent

        [TestMethod]
        public void AssertPromptPresent1()
        {
            var cmd = new AssertPromptPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertPromptPresent2()
        {
            var cmd = new AssertPromptPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertPromptPresent3()
        {
            var cmd = new AssertPromptPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectOptions

        [TestMethod]
        public void AssertSelectOptions1()
        {
            var cmd = new AssertSelectOptionsCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectOptions2()
        {
            var cmd = new AssertSelectOptionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectOptions3()
        {
            var cmd = new AssertSelectOptionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedId

        [TestMethod]
        public void AssertSelectedId1()
        {
            var cmd = new AssertSelectedIdCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedId2()
        {
            var cmd = new AssertSelectedIdCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedId3()
        {
            var cmd = new AssertSelectedIdCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedIds

        [TestMethod]
        public void AssertSelectedIds1()
        {
            var cmd = new AssertSelectedIdsCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedIds2()
        {
            var cmd = new AssertSelectedIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedIds3()
        {
            var cmd = new AssertSelectedIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedIndex

        [TestMethod]
        public void AssertSelectedIndex1()
        {
            var cmd = new AssertSelectedIndexCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedIndex2()
        {
            var cmd = new AssertSelectedIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedIndex3()
        {
            var cmd = new AssertSelectedIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedIndexes

        [TestMethod]
        public void AssertSelectedIndexes1()
        {
            var cmd = new AssertSelectedIndexesCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedIndexes2()
        {
            var cmd = new AssertSelectedIndexesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedIndexes3()
        {
            var cmd = new AssertSelectedIndexesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedLabel

        [TestMethod]
        public void AssertSelectedLabel1()
        {
            var cmd = new AssertSelectedLabelCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedLabel2()
        {
            var cmd = new AssertSelectedLabelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedLabel3()
        {
            var cmd = new AssertSelectedLabelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedLabels

        [TestMethod]
        public void AssertSelectedLabels1()
        {
            var cmd = new AssertSelectedLabelsCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedLabels2()
        {
            var cmd = new AssertSelectedLabelsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedLabels3()
        {
            var cmd = new AssertSelectedLabelsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedValue

        [TestMethod]
        public void AssertSelectedValue1()
        {
            var cmd = new AssertSelectedValueCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedValue2()
        {
            var cmd = new AssertSelectedValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedValue3()
        {
            var cmd = new AssertSelectedValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSelectedValues

        [TestMethod]
        public void AssertSelectedValues1()
        {
            var cmd = new AssertSelectedValuesCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSelectedValues2()
        {
            var cmd = new AssertSelectedValuesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSelectedValues3()
        {
            var cmd = new AssertSelectedValuesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSomethingSelected

        [TestMethod]
        public void AssertSomethingSelected1()
        {
            var cmd = new AssertSomethingSelectedCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertSomethingSelected2()
        {
            var cmd = new AssertSomethingSelectedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertSomethingSelected3()
        {
            var cmd = new AssertSomethingSelectedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertSpeed

        //[TestMethod]
        //public void AssertSpeed1()
        //{
        //    var cmd = new x_AssertSpeedCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertSpeed2()
        //{
        //    var cmd = new x_AssertSpeedCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertSpeed3()
        //{
        //    var cmd = new x_AssertSpeedCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertTable

        //[TestMethod]
        //public void AssertTable1()
        //{
        //    var cmd = new x_AssertTableCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertTable2()
        //{
        //    var cmd = new x_AssertTableCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertTable3()
        //{
        //    var cmd = new x_AssertTableCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertText

        [TestMethod]
        public void AssertText1()
        {
            var cmd = new AssertTextCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertText2()
        {
            var cmd = new AssertTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertText3()
        {
            var cmd = new AssertTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertTextNotPresent

        [TestMethod]
        public void AssertTextNotPresent1()
        {
            var cmd = new AssertTextNotPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertTextNotPresent2()
        {
            var cmd = new AssertTextNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertTextNotPresent3()
        {
            var cmd = new AssertTextNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertTextPresent

        [TestMethod]
        public void AssertTextPresent1()
        {
            var cmd = new AssertTextPresentCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertTextPresent2()
        {
            var cmd = new AssertTextPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertTextPresent3()
        {
            var cmd = new AssertTextPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertTitle

        [TestMethod]
        public void AssertTitle1()
        {
            var cmd = new AssertTitleCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertTitle2()
        {
            var cmd = new AssertTitleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertTitle3()
        {
            var cmd = new AssertTitleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertValue

        [TestMethod]
        public void AssertValue1()
        {
            var cmd = new AssertValueCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertValue2()
        {
            var cmd = new AssertValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertValue3()
        {
            var cmd = new AssertValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertVisible

        [TestMethod]
        public void AssertVisible1()
        {
            var cmd = new AssertVisibleCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(flag.HasFlag(TestCommandSyntax.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AssertVisible2()
        {
            var cmd = new AssertVisibleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void AssertVisible3()
        {
            var cmd = new AssertVisibleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region AssertWhetherThisFrameMatchFrameExpression

        //[TestMethod]
        //public void AssertWhetherThisFrameMatchFrameExpression1()
        //{
        //    var cmd = new x_AssertWhetherThisFrameMatchFrameExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertWhetherThisFrameMatchFrameExpression2()
        //{
        //    var cmd = new x_AssertWhetherThisFrameMatchFrameExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertWhetherThisFrameMatchFrameExpression3()
        //{
        //    var cmd = new x_AssertWhetherThisFrameMatchFrameExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertWhetherThisWindowMatchWindowExpression

        //[TestMethod]
        //public void AssertWhetherThisWindowMatchWindowExpression1()
        //{
        //    var cmd = new x_AssertWhetherThisWindowMatchWindowExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertWhetherThisWindowMatchWindowExpression2()
        //{
        //    var cmd = new x_AssertWhetherThisWindowMatchWindowExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertWhetherThisWindowMatchWindowExpression3()
        //{
        //    var cmd = new x_AssertWhetherThisWindowMatchWindowExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssertXpathCount

        //[TestMethod]
        //public void AssertXpathCount1()
        //{
        //    var cmd = new x_AssertXpathCountCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssertXpathCount2()
        //{
        //    var cmd = new x_AssertXpathCountCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssertXpathCount3()
        //{
        //    var cmd = new x_AssertXpathCountCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssignId

        //[TestMethod]
        //public void AssignId1()
        //{
        //    var cmd = new x_AssignIdCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssignId2()
        //{
        //    var cmd = new x_AssignIdCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssignId3()
        //{
        //    var cmd = new x_AssignIdCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region AssignIdAndWait

        //[TestMethod]
        //public void AssignIdAndWait1()
        //{
        //    var cmd = new x_AssignIdAndWaitCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void AssignIdAndWait2()
        //{
        //    var cmd = new x_AssignIdAndWaitCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void AssignIdAndWait3()
        //{
        //    var cmd = new x_AssignIdAndWaitCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region Break

        //[TestMethod]
        //public void Break1()
        //{
        //    var cmd = new x_BreakCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void Break2()
        //{
        //    var cmd = new x_BreakCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void Break3()
        //{
        //    var cmd = new x_BreakCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region CaptureEntirePageScreenshot

        [TestMethod]
        public void CaptureEntirePageScreenshot1()
        {
            var cmd = new CaptureEntirePageScreenshotCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CaptureEntirePageScreenshot2()
        {
            var cmd = new CaptureEntirePageScreenshotCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void CaptureEntirePageScreenshot3()
        {
            var cmd = new CaptureEntirePageScreenshotCommand();
            cmd.Execute(context);
        }

        #endregion

        #region CaptureEntirePageScreenshotAndWait

        [TestMethod]
        public void CaptureEntirePageScreenshotAndWait1()
        {
            var cmd = new CaptureEntirePageScreenshotAndWaitCommand();
            var flag = cmd.Syntax;
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Target));
            Assert.IsTrue(flag.HasFlag(TestCommandSyntax.Value));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CaptureEntirePageScreenshotAndWait2()
        {
            var cmd = new CaptureEntirePageScreenshotAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void CaptureEntirePageScreenshotAndWait3()
        {
            var cmd = new CaptureEntirePageScreenshotAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Check

        [TestMethod]
        public void Check1()
        {
            var cmd = new CheckCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Check2()
        {
            var cmd = new CheckCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Check3()
        {
            var cmd = new CheckCommand();
            cmd.Execute(context);
        }

        #endregion

        #region CheckAndWait

        [TestMethod]
        public void CheckAndWait1()
        {
            var cmd = new CheckAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckAndWait2()
        {
            var cmd = new CheckAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void CheckAndWait3()
        {
            var cmd = new CheckAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ChooseCancelOnNextConfirmation

        [TestMethod]
        public void ChooseCancelOnNextConfirmation1()
        {
            var cmd = new ChooseCancelOnNextConfirmationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChooseCancelOnNextConfirmation2()
        {
            var cmd = new ChooseCancelOnNextConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ChooseCancelOnNextConfirmation3()
        {
            var cmd = new ChooseCancelOnNextConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ChooseOkOnNextConfirmation

        [TestMethod]
        public void ChooseOkOnNextConfirmation1()
        {
            var cmd = new ChooseOkOnNextConfirmationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChooseOkOnNextConfirmation2()
        {
            var cmd = new ChooseOkOnNextConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ChooseOkOnNextConfirmation3()
        {
            var cmd = new ChooseOkOnNextConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ChooseOkOnNextConfirmationAndWait

        [TestMethod]
        public void ChooseOkOnNextConfirmationAndWait1()
        {
            var cmd = new ChooseOkOnNextConfirmationAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChooseOkOnNextConfirmationAndWait2()
        {
            var cmd = new ChooseOkOnNextConfirmationAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ChooseOkOnNextConfirmationAndWait3()
        {
            var cmd = new ChooseOkOnNextConfirmationAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Click

        [TestMethod]
        public void Click1()
        {
            var cmd = new ClickCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Click2()
        {
            var cmd = new ClickCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Click3()
        {
            var cmd = new ClickCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ClickAndWait

        [TestMethod]
        public void ClickAndWait1()
        {
            var cmd = new ClickAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClickAndWait2()
        {
            var cmd = new ClickAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ClickAndWait3()
        {
            var cmd = new ClickAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ClickAt

        [TestMethod]
        public void ClickAt1()
        {
            var cmd = new ClickAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClickAt2()
        {
            var cmd = new ClickAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ClickAt3()
        {
            var cmd = new ClickAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ClickAtAndWait

        [TestMethod]
        public void ClickAtAndWait1()
        {
            var cmd = new ClickAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClickAtAndWait2()
        {
            var cmd = new ClickAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ClickAtAndWait3()
        {
            var cmd = new ClickAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Close

        [TestMethod]
        public void Close1()
        {
            var cmd = new CloseCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Close2()
        {
            var cmd = new CloseCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Close3()
        {
            var cmd = new CloseCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ContextMenu

        [TestMethod]
        public void ContextMenu1()
        {
            var cmd = new ContextMenuCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContextMenu2()
        {
            var cmd = new ContextMenuCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ContextMenu3()
        {
            var cmd = new ContextMenuCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ContextMenuAndWait

        [TestMethod]
        public void ContextMenuAndWait1()
        {
            var cmd = new ContextMenuAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContextMenuAndWait2()
        {
            var cmd = new ContextMenuAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ContextMenuAndWait3()
        {
            var cmd = new ContextMenuAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ContextMenuAt

        [TestMethod]
        public void ContextMenuAt1()
        {
            var cmd = new ContextMenuAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContextMenuAt2()
        {
            var cmd = new ContextMenuAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ContextMenuAt3()
        {
            var cmd = new ContextMenuAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ContextMenuAtAndWait

        [TestMethod]
        public void ContextMenuAtAndWait1()
        {
            var cmd = new ContextMenuAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContextMenuAtAndWait2()
        {
            var cmd = new ContextMenuAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ContextMenuAtAndWait3()
        {
            var cmd = new ContextMenuAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ControlKeyDown

        [TestMethod]
        public void ControlKeyDown1()
        {
            var cmd = new ControlKeyDownCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ControlKeyDown2()
        {
            var cmd = new ControlKeyDownCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ControlKeyDown3()
        {
            var cmd = new ControlKeyDownCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ControlKeyDownAndWait

        [TestMethod]
        public void ControlKeyDownAndWait1()
        {
            var cmd = new ControlKeyDownAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ControlKeyDownAndWait2()
        {
            var cmd = new ControlKeyDownAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ControlKeyDownAndWait3()
        {
            var cmd = new ControlKeyDownAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ControlKeyUp

        [TestMethod]
        public void ControlKeyUp1()
        {
            var cmd = new ControlKeyUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ControlKeyUp2()
        {
            var cmd = new ControlKeyUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ControlKeyUp3()
        {
            var cmd = new ControlKeyUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ControlKeyUpAndWait

        [TestMethod]
        public void ControlKeyUpAndWait1()
        {
            var cmd = new ControlKeyUpAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ControlKeyUpAndWait2()
        {
            var cmd = new ControlKeyUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ControlKeyUpAndWait3()
        {
            var cmd = new ControlKeyUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region CreateCookie

        [TestMethod]
        public void CreateCookie1()
        {
            var cmd = new CreateCookieCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCookie2()
        {
            var cmd = new CreateCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void CreateCookie3()
        {
            var cmd = new CreateCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region CreateCookieAndWait

        [TestMethod]
        public void CreateCookieAndWait1()
        {
            var cmd = new CreateCookieAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateCookieAndWait2()
        {
            var cmd = new CreateCookieAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void CreateCookieAndWait3()
        {
            var cmd = new CreateCookieAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DeleteAllVisibleCookies

        [TestMethod]
        public void DeleteAllVisibleCookies1()
        {
            var cmd = new DeleteAllVisibleCookiesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteAllVisibleCookies2()
        {
            var cmd = new DeleteAllVisibleCookiesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DeleteAllVisibleCookies3()
        {
            var cmd = new DeleteAllVisibleCookiesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DeleteAllVisibleCookiesAndWait

        [TestMethod]
        public void DeleteAllVisibleCookiesAndWait1()
        {
            var cmd = new DeleteAllVisibleCookiesAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteAllVisibleCookiesAndWait2()
        {
            var cmd = new DeleteAllVisibleCookiesAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DeleteAllVisibleCookiesAndWait3()
        {
            var cmd = new DeleteAllVisibleCookiesAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DeleteCookie

        [TestMethod]
        public void DeleteCookie1()
        {
            var cmd = new DeleteCookieCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteCookie2()
        {
            var cmd = new DeleteCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DeleteCookie3()
        {
            var cmd = new DeleteCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DeleteCookieAndWait

        [TestMethod]
        public void DeleteCookieAndWait1()
        {
            var cmd = new DeleteCookieAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteCookieAndWait2()
        {
            var cmd = new DeleteCookieAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DeleteCookieAndWait3()
        {
            var cmd = new DeleteCookieAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DeselectPopUp

        [TestMethod]
        public void DeselectPopUp1()
        {
            var cmd = new x_DeselectPopUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeselectPopUp2()
        {
            var cmd = new x_DeselectPopUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DeselectPopUp3()
        {
            var cmd = new x_DeselectPopUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DeselectPopUpAndWait

        [TestMethod]
        public void DeselectPopUpAndWait1()
        {
            var cmd = new x_DeselectPopUpAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeselectPopUpAndWait2()
        {
            var cmd = new x_DeselectPopUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DeselectPopUpAndWait3()
        {
            var cmd = new x_DeselectPopUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DoubleClick

        [TestMethod]
        public void DoubleClick1()
        {
            var cmd = new DoubleClickCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoubleClick2()
        {
            var cmd = new DoubleClickCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DoubleClick3()
        {
            var cmd = new DoubleClickCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DoubleClickAndWait

        [TestMethod]
        public void DoubleClickAndWait1()
        {
            var cmd = new DoubleClickAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoubleClickAndWait2()
        {
            var cmd = new DoubleClickAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DoubleClickAndWait3()
        {
            var cmd = new DoubleClickAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DoubleClickAt

        [TestMethod]
        public void DoubleClickAt1()
        {
            var cmd = new DoubleClickAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoubleClickAt2()
        {
            var cmd = new DoubleClickAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DoubleClickAt3()
        {
            var cmd = new DoubleClickAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DoubleClickAtAndWait

        [TestMethod]
        public void DoubleClickAtAndWait1()
        {
            var cmd = new DoubleClickAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoubleClickAtAndWait2()
        {
            var cmd = new DoubleClickAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DoubleClickAtAndWait3()
        {
            var cmd = new DoubleClickAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DragAndDrop

        [TestMethod]
        public void DragAndDrop1()
        {
            var cmd = new DragAndDropCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DragAndDrop2()
        {
            var cmd = new DragAndDropCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DragAndDrop3()
        {
            var cmd = new DragAndDropCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DragAndDropAndWait

        [TestMethod]
        public void DragAndDropAndWait1()
        {
            var cmd = new DragAndDropAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DragAndDropAndWait2()
        {
            var cmd = new DragAndDropAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DragAndDropAndWait3()
        {
            var cmd = new DragAndDropAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DragAndDropToObject

        [TestMethod]
        public void DragAndDropToObject1()
        {
            var cmd = new DragAndDropToObjectCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DragAndDropToObject2()
        {
            var cmd = new DragAndDropToObjectCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DragAndDropToObject3()
        {
            var cmd = new DragAndDropToObjectCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DragAndDropToObjectAndWait

        [TestMethod]
        public void DragAndDropToObjectAndWait1()
        {
            var cmd = new DragAndDropToObjectAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DragAndDropToObjectAndWait2()
        {
            var cmd = new DragAndDropToObjectAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DragAndDropToObjectAndWait3()
        {
            var cmd = new DragAndDropToObjectAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Dragdrop

        [TestMethod]
        public void Dragdrop1()
        {
            var cmd = new DragdropCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Dragdrop2()
        {
            var cmd = new DragdropCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Dragdrop3()
        {
            var cmd = new DragdropCommand();
            cmd.Execute(context);
        }

        #endregion

        #region DragdropAndWait

        [TestMethod]
        public void DragdropAndWait1()
        {
            var cmd = new DragdropAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DragdropAndWait2()
        {
            var cmd = new DragdropAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void DragdropAndWait3()
        {
            var cmd = new DragdropAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Echo

        [TestMethod]
        public void Echo1()
        {
            var cmd = new EchoCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Echo2()
        {
            var cmd = new EchoCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Echo3()
        {
            var cmd = new EchoCommand();
            cmd.Execute(context);
        }

        #endregion

        #region FireEvent

        [TestMethod]
        public void FireEvent1()
        {
            var cmd = new x_FireEventCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FireEvent2()
        {
            var cmd = new x_FireEventCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void FireEvent3()
        {
            var cmd = new x_FireEventCommand();
            cmd.Execute(context);
        }

        #endregion

        #region FireEventAndWait

        [TestMethod]
        public void FireEventAndWait1()
        {
            var cmd = new x_FireEventAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FireEventAndWait2()
        {
            var cmd = new x_FireEventAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void FireEventAndWait3()
        {
            var cmd = new x_FireEventAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Focus

        [TestMethod]
        public void Focus1()
        {
            var cmd = new FocusCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Focus2()
        {
            var cmd = new FocusCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Focus3()
        {
            var cmd = new FocusCommand();
            cmd.Execute(context);
        }

        #endregion

        #region FocusAndWait

        [TestMethod]
        public void FocusAndWait1()
        {
            var cmd = new FocusAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FocusAndWait2()
        {
            var cmd = new FocusAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void FocusAndWait3()
        {
            var cmd = new FocusAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region GoBack

        [TestMethod]
        public void GoBack1()
        {
            var cmd = new GoBackCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GoBack2()
        {
            var cmd = new GoBackCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void GoBack3()
        {
            var cmd = new GoBackCommand();
            cmd.Execute(context);
        }

        #endregion

        #region GoBackAndWait

        [TestMethod]
        public void GoBackAndWait1()
        {
            var cmd = new GoBackAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GoBackAndWait2()
        {
            var cmd = new GoBackAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void GoBackAndWait3()
        {
            var cmd = new GoBackAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Highlight

        [TestMethod]
        public void Highlight1()
        {
            var cmd = new x_HighlightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Highlight2()
        {
            var cmd = new x_HighlightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Highlight3()
        {
            var cmd = new x_HighlightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region HighlightAndWait

        [TestMethod]
        public void HighlightAndWait1()
        {
            var cmd = new x_HighlightAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HighlightAndWait2()
        {
            var cmd = new x_HighlightAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void HighlightAndWait3()
        {
            var cmd = new x_HighlightAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region IgnoreAttributesWithoutValue

        [TestMethod]
        public void IgnoreAttributesWithoutValue1()
        {
            var cmd = new x_IgnoreAttributesWithoutValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IgnoreAttributesWithoutValue2()
        {
            var cmd = new x_IgnoreAttributesWithoutValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void IgnoreAttributesWithoutValue3()
        {
            var cmd = new x_IgnoreAttributesWithoutValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region IgnoreAttributesWithoutValueAndWait

        [TestMethod]
        public void IgnoreAttributesWithoutValueAndWait1()
        {
            var cmd = new x_IgnoreAttributesWithoutValueAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IgnoreAttributesWithoutValueAndWait2()
        {
            var cmd = new x_IgnoreAttributesWithoutValueAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void IgnoreAttributesWithoutValueAndWait3()
        {
            var cmd = new x_IgnoreAttributesWithoutValueAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region KeyDown

        [TestMethod]
        public void KeyDown1()
        {
            var cmd = new KeyDownCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyDown2()
        {
            var cmd = new KeyDownCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void KeyDown3()
        {
            var cmd = new KeyDownCommand();
            cmd.Execute(context);
        }

        #endregion

        #region KeyDownAndWait

        [TestMethod]
        public void KeyDownAndWait1()
        {
            var cmd = new KeyDownAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyDownAndWait2()
        {
            var cmd = new KeyDownAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void KeyDownAndWait3()
        {
            var cmd = new KeyDownAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region KeyPress

        [TestMethod]
        public void KeyPress1()
        {
            var cmd = new KeyPressCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyPress2()
        {
            var cmd = new KeyPressCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void KeyPress3()
        {
            var cmd = new KeyPressCommand();
            cmd.Execute(context);
        }

        #endregion

        #region KeyPressAndWait

        [TestMethod]
        public void KeyPressAndWait1()
        {
            var cmd = new KeyPressAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyPressAndWait2()
        {
            var cmd = new KeyPressAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void KeyPressAndWait3()
        {
            var cmd = new KeyPressAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region KeyUp

        [TestMethod]
        public void KeyUp1()
        {
            var cmd = new KeyUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyUp2()
        {
            var cmd = new KeyUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void KeyUp3()
        {
            var cmd = new KeyUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region KeyUpAndWait

        [TestMethod]
        public void KeyUpAndWait1()
        {
            var cmd = new KeyUpAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KeyUpAndWait2()
        {
            var cmd = new KeyUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void KeyUpAndWait3()
        {
            var cmd = new KeyUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MetaKeyDown

        [TestMethod]
        public void MetaKeyDown1()
        {
            var cmd = new MetaKeyDownCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MetaKeyDown2()
        {
            var cmd = new MetaKeyDownCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MetaKeyDown3()
        {
            var cmd = new MetaKeyDownCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MetaKeyDownAndWait

        [TestMethod]
        public void MetaKeyDownAndWait1()
        {
            var cmd = new MetaKeyDownAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MetaKeyDownAndWait2()
        {
            var cmd = new MetaKeyDownAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MetaKeyDownAndWait3()
        {
            var cmd = new MetaKeyDownAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MetaKeyUp

        [TestMethod]
        public void MetaKeyUp1()
        {
            var cmd = new MetaKeyUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MetaKeyUp2()
        {
            var cmd = new MetaKeyUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MetaKeyUp3()
        {
            var cmd = new MetaKeyUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MetaKeyUpAndWait

        [TestMethod]
        public void MetaKeyUpAndWait1()
        {
            var cmd = new MetaKeyUpAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MetaKeyUpAndWait2()
        {
            var cmd = new MetaKeyUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MetaKeyUpAndWait3()
        {
            var cmd = new MetaKeyUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDown

        [TestMethod]
        public void MouseDown1()
        {
            var cmd = new MouseDownCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDown2()
        {
            var cmd = new MouseDownCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDown3()
        {
            var cmd = new MouseDownCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDownAndWait

        [TestMethod]
        public void MouseDownAndWait1()
        {
            var cmd = new MouseDownAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDownAndWait2()
        {
            var cmd = new MouseDownAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDownAndWait3()
        {
            var cmd = new MouseDownAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDownAt

        [TestMethod]
        public void MouseDownAt1()
        {
            var cmd = new MouseDownAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDownAt2()
        {
            var cmd = new MouseDownAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDownAt3()
        {
            var cmd = new MouseDownAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDownAtAndWait

        [TestMethod]
        public void MouseDownAtAndWait1()
        {
            var cmd = new MouseDownAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDownAtAndWait2()
        {
            var cmd = new MouseDownAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDownAtAndWait3()
        {
            var cmd = new MouseDownAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDownRight

        [TestMethod]
        public void MouseDownRight1()
        {
            var cmd = new x_MouseDownRightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDownRight2()
        {
            var cmd = new x_MouseDownRightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDownRight3()
        {
            var cmd = new x_MouseDownRightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDownRightAndWait

        [TestMethod]
        public void MouseDownRightAndWait1()
        {
            var cmd = new x_MouseDownRightAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDownRightAndWait2()
        {
            var cmd = new x_MouseDownRightAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDownRightAndWait3()
        {
            var cmd = new x_MouseDownRightAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDownRightAt

        [TestMethod]
        public void MouseDownRightAt1()
        {
            var cmd = new x_MouseDownRightAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDownRightAt2()
        {
            var cmd = new x_MouseDownRightAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDownRightAt3()
        {
            var cmd = new x_MouseDownRightAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseDownRightAtAndWait

        [TestMethod]
        public void MouseDownRightAtAndWait1()
        {
            var cmd = new x_MouseDownRightAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseDownRightAtAndWait2()
        {
            var cmd = new x_MouseDownRightAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseDownRightAtAndWait3()
        {
            var cmd = new x_MouseDownRightAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseMove

        [TestMethod]
        public void MouseMove1()
        {
            var cmd = new MouseMoveCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseMove2()
        {
            var cmd = new MouseMoveCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseMove3()
        {
            var cmd = new MouseMoveCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseMoveAndWait

        [TestMethod]
        public void MouseMoveAndWait1()
        {
            var cmd = new MouseMoveAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseMoveAndWait2()
        {
            var cmd = new MouseMoveAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseMoveAndWait3()
        {
            var cmd = new MouseMoveAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseMoveAt

        [TestMethod]
        public void MouseMoveAt1()
        {
            var cmd = new MouseMoveAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseMoveAt2()
        {
            var cmd = new MouseMoveAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseMoveAt3()
        {
            var cmd = new MouseMoveAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseMoveAtAndWait

        [TestMethod]
        public void MouseMoveAtAndWait1()
        {
            var cmd = new MouseMoveAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseMoveAtAndWait2()
        {
            var cmd = new MouseMoveAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseMoveAtAndWait3()
        {
            var cmd = new MouseMoveAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseOut

        [TestMethod]
        public void MouseOut1()
        {
            var cmd = new x_MouseOutCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseOut2()
        {
            var cmd = new x_MouseOutCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseOut3()
        {
            var cmd = new x_MouseOutCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseOutAndWait

        [TestMethod]
        public void MouseOutAndWait1()
        {
            var cmd = new x_MouseOutAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseOutAndWait2()
        {
            var cmd = new x_MouseOutAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseOutAndWait3()
        {
            var cmd = new x_MouseOutAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseOver

        [TestMethod]
        public void MouseOver1()
        {
            var cmd = new MouseOverCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseOver2()
        {
            var cmd = new MouseOverCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseOver3()
        {
            var cmd = new MouseOverCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseOverAndWait

        [TestMethod]
        public void MouseOverAndWait1()
        {
            var cmd = new MouseOverAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseOverAndWait2()
        {
            var cmd = new MouseOverAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseOverAndWait3()
        {
            var cmd = new MouseOverAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUp

        [TestMethod]
        public void MouseUp1()
        {
            var cmd = new MouseUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUp2()
        {
            var cmd = new MouseUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUp3()
        {
            var cmd = new MouseUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUpAndWait

        [TestMethod]
        public void MouseUpAndWait1()
        {
            var cmd = new MouseUpAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUpAndWait2()
        {
            var cmd = new MouseUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUpAndWait3()
        {
            var cmd = new MouseUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUpAt

        [TestMethod]
        public void MouseUpAt1()
        {
            var cmd = new MouseUpAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUpAt2()
        {
            var cmd = new MouseUpAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUpAt3()
        {
            var cmd = new MouseUpAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUpAtAndWait

        [TestMethod]
        public void MouseUpAtAndWait1()
        {
            var cmd = new MouseUpAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUpAtAndWait2()
        {
            var cmd = new MouseUpAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUpAtAndWait3()
        {
            var cmd = new MouseUpAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUpRight

        [TestMethod]
        public void MouseUpRight1()
        {
            var cmd = new x_MouseUpRightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUpRight2()
        {
            var cmd = new x_MouseUpRightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUpRight3()
        {
            var cmd = new x_MouseUpRightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUpRightAndWait

        [TestMethod]
        public void MouseUpRightAndWait1()
        {
            var cmd = new x_MouseUpRightAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUpRightAndWait2()
        {
            var cmd = new x_MouseUpRightAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUpRightAndWait3()
        {
            var cmd = new x_MouseUpRightAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUpRightAt

        [TestMethod]
        public void MouseUpRightAt1()
        {
            var cmd = new x_MouseUpRightAtCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUpRightAt2()
        {
            var cmd = new x_MouseUpRightAtCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUpRightAt3()
        {
            var cmd = new x_MouseUpRightAtCommand();
            cmd.Execute(context);
        }

        #endregion

        #region MouseUpRightAtAndWait

        [TestMethod]
        public void MouseUpRightAtAndWait1()
        {
            var cmd = new x_MouseUpRightAtAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MouseUpRightAtAndWait2()
        {
            var cmd = new x_MouseUpRightAtAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void MouseUpRightAtAndWait3()
        {
            var cmd = new x_MouseUpRightAtAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Open

        [TestMethod]
        public void Open1()
        {
            var cmd = new OpenCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Open2()
        {
            var cmd = new OpenCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Open3()
        {
            var cmd = new OpenCommand();
            cmd.Execute(context);
        }

        #endregion

        #region OpenWindow

        [TestMethod]
        public void OpenWindow1()
        {
            var cmd = new OpenWindowCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OpenWindow2()
        {
            var cmd = new OpenWindowCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void OpenWindow3()
        {
            var cmd = new OpenWindowCommand();
            cmd.Execute(context);
        }

        #endregion

        #region OpenWindowAndWait

        [TestMethod]
        public void OpenWindowAndWait1()
        {
            var cmd = new OpenWindowAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OpenWindowAndWait2()
        {
            var cmd = new OpenWindowAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void OpenWindowAndWait3()
        {
            var cmd = new OpenWindowAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Pause

        [TestMethod]
        public void Pause1()
        {
            var cmd = new PauseCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Pause2()
        {
            var cmd = new PauseCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Pause3()
        {
            var cmd = new PauseCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Refresh

        [TestMethod]
        public void Refresh1()
        {
            var cmd = new RefreshCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Refresh2()
        {
            var cmd = new RefreshCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Refresh3()
        {
            var cmd = new RefreshCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RefreshAndWait

        [TestMethod]
        public void RefreshAndWait1()
        {
            var cmd = new RefreshAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RefreshAndWait2()
        {
            var cmd = new RefreshAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RefreshAndWait3()
        {
            var cmd = new RefreshAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RemoveAllSelections

        [TestMethod]
        public void RemoveAllSelections1()
        {
            var cmd = new x_RemoveAllSelectionsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveAllSelections2()
        {
            var cmd = new x_RemoveAllSelectionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RemoveAllSelections3()
        {
            var cmd = new x_RemoveAllSelectionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RemoveAllSelectionsAndWait

        [TestMethod]
        public void RemoveAllSelectionsAndWait1()
        {
            var cmd = new x_RemoveAllSelectionsAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveAllSelectionsAndWait2()
        {
            var cmd = new x_RemoveAllSelectionsAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RemoveAllSelectionsAndWait3()
        {
            var cmd = new x_RemoveAllSelectionsAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RemoveScript

        [TestMethod]
        public void RemoveScript1()
        {
            var cmd = new x_RemoveScriptCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveScript2()
        {
            var cmd = new x_RemoveScriptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RemoveScript3()
        {
            var cmd = new x_RemoveScriptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RemoveScriptAndWait

        [TestMethod]
        public void RemoveScriptAndWait1()
        {
            var cmd = new x_RemoveScriptAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveScriptAndWait2()
        {
            var cmd = new x_RemoveScriptAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RemoveScriptAndWait3()
        {
            var cmd = new x_RemoveScriptAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RemoveSelection

        [TestMethod]
        public void RemoveSelection1()
        {
            var cmd = new x_RemoveSelectionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveSelection2()
        {
            var cmd = new x_RemoveSelectionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RemoveSelection3()
        {
            var cmd = new x_RemoveSelectionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RemoveSelectionAndWait

        [TestMethod]
        public void RemoveSelectionAndWait1()
        {
            var cmd = new x_RemoveSelectionAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveSelectionAndWait2()
        {
            var cmd = new x_RemoveSelectionAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RemoveSelectionAndWait3()
        {
            var cmd = new x_RemoveSelectionAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Rollup

        [TestMethod]
        public void Rollup1()
        {
            var cmd = new x_RollupCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Rollup2()
        {
            var cmd = new x_RollupCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Rollup3()
        {
            var cmd = new x_RollupCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RollupAndWait

        [TestMethod]
        public void RollupAndWait1()
        {
            var cmd = new x_RollupAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RollupAndWait2()
        {
            var cmd = new x_RollupAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RollupAndWait3()
        {
            var cmd = new x_RollupAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RunScript

        [TestMethod]
        public void RunScript1()
        {
            var cmd = new x_RunScriptCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RunScript2()
        {
            var cmd = new x_RunScriptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RunScript3()
        {
            var cmd = new x_RunScriptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region RunScriptAndWait

        [TestMethod]
        public void RunScriptAndWait1()
        {
            var cmd = new x_RunScriptAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RunScriptAndWait2()
        {
            var cmd = new x_RunScriptAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void RunScriptAndWait3()
        {
            var cmd = new x_RunScriptAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Select

        [TestMethod]
        public void Select1()
        {
            var cmd = new SelectCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Select2()
        {
            var cmd = new SelectCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Select3()
        {
            var cmd = new SelectCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SelectAndWait

        [TestMethod]
        public void SelectAndWait1()
        {
            var cmd = new SelectAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectAndWait2()
        {
            var cmd = new SelectAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SelectAndWait3()
        {
            var cmd = new SelectAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SelectFrame

        [TestMethod]
        public void SelectFrame1()
        {
            var cmd = new SelectFrameCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectFrame2()
        {
            var cmd = new SelectFrameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SelectFrame3()
        {
            var cmd = new SelectFrameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SelectPopUp

        [TestMethod]
        public void SelectPopUp1()
        {
            var cmd = new SelectPopUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectPopUp2()
        {
            var cmd = new SelectPopUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SelectPopUp3()
        {
            var cmd = new SelectPopUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SelectPopUpAndWait

        [TestMethod]
        public void SelectPopUpAndWait1()
        {
            var cmd = new SelectPopUpAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectPopUpAndWait2()
        {
            var cmd = new SelectPopUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SelectPopUpAndWait3()
        {
            var cmd = new SelectPopUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SelectWindow

        [TestMethod]
        public void SelectWindow1()
        {
            var cmd = new SelectWindowCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SelectWindow2()
        {
            var cmd = new SelectWindowCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SelectWindow3()
        {
            var cmd = new SelectWindowCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SendKeys

        [TestMethod]
        public void SendKeys1()
        {
            var cmd = new SendKeysCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SendKeys2()
        {
            var cmd = new SendKeysCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SendKeys3()
        {
            var cmd = new SendKeysCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetBrowserLogLevel

        [TestMethod]
        public void SetBrowserLogLevel1()
        {
            var cmd = new x_SetBrowserLogLevelCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetBrowserLogLevel2()
        {
            var cmd = new x_SetBrowserLogLevelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetBrowserLogLevel3()
        {
            var cmd = new x_SetBrowserLogLevelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetBrowserLogLevelAndWait

        [TestMethod]
        public void SetBrowserLogLevelAndWait1()
        {
            var cmd = new x_SetBrowserLogLevelAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetBrowserLogLevelAndWait2()
        {
            var cmd = new x_SetBrowserLogLevelAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetBrowserLogLevelAndWait3()
        {
            var cmd = new x_SetBrowserLogLevelAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetCursorPosition

        [TestMethod]
        public void SetCursorPosition1()
        {
            var cmd = new x_SetCursorPositionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetCursorPosition2()
        {
            var cmd = new x_SetCursorPositionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetCursorPosition3()
        {
            var cmd = new x_SetCursorPositionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetCursorPositionAndWait

        [TestMethod]
        public void SetCursorPositionAndWait1()
        {
            var cmd = new x_SetCursorPositionAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetCursorPositionAndWait2()
        {
            var cmd = new x_SetCursorPositionAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetCursorPositionAndWait3()
        {
            var cmd = new x_SetCursorPositionAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetMouseSpeed

        [TestMethod]
        public void SetMouseSpeed1()
        {
            var cmd = new x_SetMouseSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetMouseSpeed2()
        {
            var cmd = new x_SetMouseSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetMouseSpeed3()
        {
            var cmd = new x_SetMouseSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetMouseSpeedAndWait

        [TestMethod]
        public void SetMouseSpeedAndWait1()
        {
            var cmd = new x_SetMouseSpeedAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetMouseSpeedAndWait2()
        {
            var cmd = new x_SetMouseSpeedAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetMouseSpeedAndWait3()
        {
            var cmd = new x_SetMouseSpeedAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetSpeed

        [TestMethod]
        public void SetSpeed1()
        {
            var cmd = new x_SetSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetSpeed2()
        {
            var cmd = new x_SetSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetSpeed3()
        {
            var cmd = new x_SetSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetSpeedAndWait

        [TestMethod]
        public void SetSpeedAndWait1()
        {
            var cmd = new x_SetSpeedAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetSpeedAndWait2()
        {
            var cmd = new x_SetSpeedAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetSpeedAndWait3()
        {
            var cmd = new x_SetSpeedAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SetTimeout

        [TestMethod]
        public void SetTimeout1()
        {
            var cmd = new SetTimeoutCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetTimeout2()
        {
            var cmd = new SetTimeoutCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SetTimeout3()
        {
            var cmd = new SetTimeoutCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ShiftKeyDown

        [TestMethod]
        public void ShiftKeyDown1()
        {
            var cmd = new ShiftKeyDownCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShiftKeyDown2()
        {
            var cmd = new ShiftKeyDownCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ShiftKeyDown3()
        {
            var cmd = new ShiftKeyDownCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ShiftKeyDownAndWait

        [TestMethod]
        public void ShiftKeyDownAndWait1()
        {
            var cmd = new ShiftKeyDownAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShiftKeyDownAndWait2()
        {
            var cmd = new ShiftKeyDownAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ShiftKeyDownAndWait3()
        {
            var cmd = new ShiftKeyDownAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ShiftKeyUp

        [TestMethod]
        public void ShiftKeyUp1()
        {
            var cmd = new ShiftKeyUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShiftKeyUp2()
        {
            var cmd = new ShiftKeyUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ShiftKeyUp3()
        {
            var cmd = new ShiftKeyUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region ShiftKeyUpAndWait

        [TestMethod]
        public void ShiftKeyUpAndWait1()
        {
            var cmd = new ShiftKeyUpAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShiftKeyUpAndWait2()
        {
            var cmd = new ShiftKeyUpAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void ShiftKeyUpAndWait3()
        {
            var cmd = new ShiftKeyUpAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Store

        [TestMethod]
        public void Store1()
        {
            var cmd = new StoreCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Store2()
        {
            var cmd = new StoreCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Store3()
        {
            var cmd = new StoreCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAlert

        [TestMethod]
        public void StoreAlert1()
        {
            var cmd = new StoreAlertCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAlert2()
        {
            var cmd = new StoreAlertCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAlert3()
        {
            var cmd = new StoreAlertCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAlertPresent

        [TestMethod]
        public void StoreAlertPresent1()
        {
            var cmd = new StoreAlertPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAlertPresent2()
        {
            var cmd = new StoreAlertPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAlertPresent3()
        {
            var cmd = new StoreAlertPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAllButtons

        [TestMethod]
        public void StoreAllButtons1()
        {
            var cmd = new x_StoreAllButtonsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAllButtons2()
        {
            var cmd = new x_StoreAllButtonsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAllButtons3()
        {
            var cmd = new x_StoreAllButtonsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAllFields

        [TestMethod]
        public void StoreAllFields1()
        {
            var cmd = new x_StoreAllFieldsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAllFields2()
        {
            var cmd = new x_StoreAllFieldsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAllFields3()
        {
            var cmd = new x_StoreAllFieldsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAllLinks

        [TestMethod]
        public void StoreAllLinks1()
        {
            var cmd = new x_StoreAllLinksCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAllLinks2()
        {
            var cmd = new x_StoreAllLinksCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAllLinks3()
        {
            var cmd = new x_StoreAllLinksCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAllWindowIds

        [TestMethod]
        public void StoreAllWindowIds1()
        {
            var cmd = new x_StoreAllWindowIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAllWindowIds2()
        {
            var cmd = new x_StoreAllWindowIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAllWindowIds3()
        {
            var cmd = new x_StoreAllWindowIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAllWindowNames

        [TestMethod]
        public void StoreAllWindowNames1()
        {
            var cmd = new x_StoreAllWindowNamesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAllWindowNames2()
        {
            var cmd = new x_StoreAllWindowNamesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAllWindowNames3()
        {
            var cmd = new x_StoreAllWindowNamesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAllWindowTitles

        [TestMethod]
        public void StoreAllWindowTitles1()
        {
            var cmd = new x_StoreAllWindowTitlesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAllWindowTitles2()
        {
            var cmd = new x_StoreAllWindowTitlesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAllWindowTitles3()
        {
            var cmd = new x_StoreAllWindowTitlesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAttribute

        [TestMethod]
        public void StoreAttribute1()
        {
            var cmd = new StoreAttributeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAttribute2()
        {
            var cmd = new StoreAttributeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAttribute3()
        {
            var cmd = new StoreAttributeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreAttributeFromAllWindows

        [TestMethod]
        public void StoreAttributeFromAllWindows1()
        {
            var cmd = new x_StoreAttributeFromAllWindowsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreAttributeFromAllWindows2()
        {
            var cmd = new x_StoreAttributeFromAllWindowsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreAttributeFromAllWindows3()
        {
            var cmd = new x_StoreAttributeFromAllWindowsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreBodyText

        [TestMethod]
        public void StoreBodyText1()
        {
            var cmd = new StoreBodyTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreBodyText2()
        {
            var cmd = new StoreBodyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreBodyText3()
        {
            var cmd = new StoreBodyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreChecked

        [TestMethod]
        public void StoreChecked1()
        {
            var cmd = new StoreCheckedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreChecked2()
        {
            var cmd = new StoreCheckedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreChecked3()
        {
            var cmd = new StoreCheckedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreConfirmation

        [TestMethod]
        public void StoreConfirmation1()
        {
            var cmd = new StoreConfirmationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreConfirmation2()
        {
            var cmd = new StoreConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreConfirmation3()
        {
            var cmd = new StoreConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreConfirmationPresent

        [TestMethod]
        public void StoreConfirmationPresent1()
        {
            var cmd = new StoreConfirmationPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreConfirmationPresent2()
        {
            var cmd = new StoreConfirmationPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreConfirmationPresent3()
        {
            var cmd = new StoreConfirmationPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreCookie

        [TestMethod]
        public void StoreCookie1()
        {
            var cmd = new StoreCookieCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreCookie2()
        {
            var cmd = new StoreCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreCookie3()
        {
            var cmd = new StoreCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreCookieByName

        [TestMethod]
        public void StoreCookieByName1()
        {
            var cmd = new StoreCookieByNameCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreCookieByName2()
        {
            var cmd = new StoreCookieByNameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreCookieByName3()
        {
            var cmd = new StoreCookieByNameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreCookiePresent

        [TestMethod]
        public void StoreCookiePresent1()
        {
            var cmd = new StoreCookiePresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreCookiePresent2()
        {
            var cmd = new StoreCookiePresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreCookiePresent3()
        {
            var cmd = new StoreCookiePresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreCursorPosition

        [TestMethod]
        public void StoreCursorPosition1()
        {
            var cmd = new x_StoreCursorPositionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreCursorPosition2()
        {
            var cmd = new x_StoreCursorPositionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreCursorPosition3()
        {
            var cmd = new x_StoreCursorPositionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreEditable

        [TestMethod]
        public void StoreEditable1()
        {
            var cmd = new StoreEditableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreEditable2()
        {
            var cmd = new StoreEditableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreEditable3()
        {
            var cmd = new StoreEditableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreElementHeight

        [TestMethod]
        public void StoreElementHeight1()
        {
            var cmd = new StoreElementHeightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreElementHeight2()
        {
            var cmd = new StoreElementHeightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreElementHeight3()
        {
            var cmd = new StoreElementHeightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreElementIndex

        [TestMethod]
        public void StoreElementIndex1()
        {
            var cmd = new x_StoreElementIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreElementIndex2()
        {
            var cmd = new x_StoreElementIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreElementIndex3()
        {
            var cmd = new x_StoreElementIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreElementPositionLeft

        [TestMethod]
        public void StoreElementPositionLeft1()
        {
            var cmd = new StoreElementPositionLeftCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreElementPositionLeft2()
        {
            var cmd = new StoreElementPositionLeftCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreElementPositionLeft3()
        {
            var cmd = new StoreElementPositionLeftCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreElementPositionTop

        [TestMethod]
        public void StoreElementPositionTop1()
        {
            var cmd = new StoreElementPositionTopCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreElementPositionTop2()
        {
            var cmd = new StoreElementPositionTopCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreElementPositionTop3()
        {
            var cmd = new StoreElementPositionTopCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreElementPresent

        [TestMethod]
        public void StoreElementPresent1()
        {
            var cmd = new StoreElementPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreElementPresent2()
        {
            var cmd = new StoreElementPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreElementPresent3()
        {
            var cmd = new StoreElementPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreElementWidth

        [TestMethod]
        public void StoreElementWidth1()
        {
            var cmd = new StoreElementWidthCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreElementWidth2()
        {
            var cmd = new StoreElementWidthCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreElementWidth3()
        {
            var cmd = new StoreElementWidthCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreEval

        [TestMethod]
        public void StoreEval1()
        {
            var cmd = new x_StoreEvalCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreEval2()
        {
            var cmd = new x_StoreEvalCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreEval3()
        {
            var cmd = new x_StoreEvalCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreExpression

        [TestMethod]
        public void StoreExpression1()
        {
            var cmd = new x_StoreExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreExpression2()
        {
            var cmd = new x_StoreExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreExpression3()
        {
            var cmd = new x_StoreExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreHtmlSource

        [TestMethod]
        public void StoreHtmlSource1()
        {
            var cmd = new x_StoreHtmlSourceCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreHtmlSource2()
        {
            var cmd = new x_StoreHtmlSourceCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreHtmlSource3()
        {
            var cmd = new x_StoreHtmlSourceCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreLocation

        [TestMethod]
        public void StoreLocation1()
        {
            var cmd = new StoreLocationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreLocation2()
        {
            var cmd = new StoreLocationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreLocation3()
        {
            var cmd = new StoreLocationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreMouseSpeed

        [TestMethod]
        public void StoreMouseSpeed1()
        {
            var cmd = new x_StoreMouseSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreMouseSpeed2()
        {
            var cmd = new x_StoreMouseSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreMouseSpeed3()
        {
            var cmd = new x_StoreMouseSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreOrdered

        [TestMethod]
        public void StoreOrdered1()
        {
            var cmd = new x_StoreOrderedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreOrdered2()
        {
            var cmd = new x_StoreOrderedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreOrdered3()
        {
            var cmd = new x_StoreOrderedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StorePrompt

        [TestMethod]
        public void StorePrompt1()
        {
            var cmd = new StorePromptCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StorePrompt2()
        {
            var cmd = new StorePromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StorePrompt3()
        {
            var cmd = new StorePromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StorePromptPresent

        [TestMethod]
        public void StorePromptPresent1()
        {
            var cmd = new StorePromptPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StorePromptPresent2()
        {
            var cmd = new StorePromptPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StorePromptPresent3()
        {
            var cmd = new StorePromptPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectOptions

        [TestMethod]
        public void StoreSelectOptions1()
        {
            var cmd = new StoreSelectOptionsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectOptions2()
        {
            var cmd = new StoreSelectOptionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectOptions3()
        {
            var cmd = new StoreSelectOptionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedId

        [TestMethod]
        public void StoreSelectedId1()
        {
            var cmd = new StoreSelectedIdCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedId2()
        {
            var cmd = new StoreSelectedIdCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedId3()
        {
            var cmd = new StoreSelectedIdCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedIds

        [TestMethod]
        public void StoreSelectedIds1()
        {
            var cmd = new StoreSelectedIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedIds2()
        {
            var cmd = new StoreSelectedIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedIds3()
        {
            var cmd = new StoreSelectedIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedIndex

        [TestMethod]
        public void StoreSelectedIndex1()
        {
            var cmd = new StoreSelectedIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedIndex2()
        {
            var cmd = new StoreSelectedIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedIndex3()
        {
            var cmd = new StoreSelectedIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedIndexes

        [TestMethod]
        public void StoreSelectedIndexes1()
        {
            var cmd = new StoreSelectedIndexesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedIndexes2()
        {
            var cmd = new StoreSelectedIndexesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedIndexes3()
        {
            var cmd = new StoreSelectedIndexesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedLabel

        [TestMethod]
        public void StoreSelectedLabel1()
        {
            var cmd = new StoreSelectedLabelCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedLabel2()
        {
            var cmd = new StoreSelectedLabelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedLabel3()
        {
            var cmd = new StoreSelectedLabelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedLabels

        [TestMethod]
        public void StoreSelectedLabels1()
        {
            var cmd = new StoreSelectedLabelsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedLabels2()
        {
            var cmd = new StoreSelectedLabelsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedLabels3()
        {
            var cmd = new StoreSelectedLabelsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedValue

        [TestMethod]
        public void StoreSelectedValue1()
        {
            var cmd = new StoreSelectedValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedValue2()
        {
            var cmd = new StoreSelectedValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedValue3()
        {
            var cmd = new StoreSelectedValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSelectedValues

        [TestMethod]
        public void StoreSelectedValues1()
        {
            var cmd = new StoreSelectedValuesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSelectedValues2()
        {
            var cmd = new StoreSelectedValuesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSelectedValues3()
        {
            var cmd = new StoreSelectedValuesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSomethingSelected

        [TestMethod]
        public void StoreSomethingSelected1()
        {
            var cmd = new StoreSomethingSelectedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSomethingSelected2()
        {
            var cmd = new StoreSomethingSelectedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSomethingSelected3()
        {
            var cmd = new StoreSomethingSelectedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreSpeed

        [TestMethod]
        public void StoreSpeed1()
        {
            var cmd = new x_StoreSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreSpeed2()
        {
            var cmd = new x_StoreSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreSpeed3()
        {
            var cmd = new x_StoreSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreTable

        [TestMethod]
        public void StoreTable1()
        {
            var cmd = new x_StoreTableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreTable2()
        {
            var cmd = new x_StoreTableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreTable3()
        {
            var cmd = new x_StoreTableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreText

        [TestMethod]
        public void StoreText1()
        {
            var cmd = new StoreTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreText2()
        {
            var cmd = new StoreTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreText3()
        {
            var cmd = new StoreTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreTextPresent

        [TestMethod]
        public void StoreTextPresent1()
        {
            var cmd = new StoreTextPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreTextPresent2()
        {
            var cmd = new StoreTextPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreTextPresent3()
        {
            var cmd = new StoreTextPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreTitle

        [TestMethod]
        public void StoreTitle1()
        {
            var cmd = new StoreTitleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreTitle2()
        {
            var cmd = new StoreTitleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreTitle3()
        {
            var cmd = new StoreTitleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreValue

        [TestMethod]
        public void StoreValue1()
        {
            var cmd = new StoreValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreValue2()
        {
            var cmd = new StoreValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreValue3()
        {
            var cmd = new StoreValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreVisible

        [TestMethod]
        public void StoreVisible1()
        {
            var cmd = new StoreVisibleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreVisible2()
        {
            var cmd = new StoreVisibleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreVisible3()
        {
            var cmd = new StoreVisibleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreWhetherThisFrameMatchFrameExpression

        [TestMethod]
        public void StoreWhetherThisFrameMatchFrameExpression1()
        {
            var cmd = new x_StoreWhetherThisFrameMatchFrameExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreWhetherThisFrameMatchFrameExpression2()
        {
            var cmd = new x_StoreWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreWhetherThisFrameMatchFrameExpression3()
        {
            var cmd = new x_StoreWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreWhetherThisWindowMatchWindowExpression

        [TestMethod]
        public void StoreWhetherThisWindowMatchWindowExpression1()
        {
            var cmd = new x_StoreWhetherThisWindowMatchWindowExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreWhetherThisWindowMatchWindowExpression2()
        {
            var cmd = new x_StoreWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreWhetherThisWindowMatchWindowExpression3()
        {
            var cmd = new x_StoreWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region StoreXpathCount

        [TestMethod]
        public void StoreXpathCount1()
        {
            var cmd = new x_StoreXpathCountCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StoreXpathCount2()
        {
            var cmd = new x_StoreXpathCountCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void StoreXpathCount3()
        {
            var cmd = new x_StoreXpathCountCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Submit

        [TestMethod]
        public void Submit1()
        {
            var cmd = new SubmitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Submit2()
        {
            var cmd = new SubmitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Submit3()
        {
            var cmd = new SubmitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region SubmitAndWait

        [TestMethod]
        public void SubmitAndWait1()
        {
            var cmd = new SubmitAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SubmitAndWait2()
        {
            var cmd = new SubmitAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void SubmitAndWait3()
        {
            var cmd = new SubmitAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Type

        [TestMethod]
        public void Type1()
        {
            var cmd = new TypeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Type2()
        {
            var cmd = new TypeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Type3()
        {
            var cmd = new TypeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region TypeAndWait

        [TestMethod]
        public void TypeAndWait1()
        {
            var cmd = new TypeAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TypeAndWait2()
        {
            var cmd = new TypeAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void TypeAndWait3()
        {
            var cmd = new TypeAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region TypeKeys

        [TestMethod]
        public void TypeKeys1()
        {
            var cmd = new TypeKeysCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TypeKeys2()
        {
            var cmd = new TypeKeysCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void TypeKeys3()
        {
            var cmd = new TypeKeysCommand();
            cmd.Execute(context);
        }

        #endregion

        #region TypeKeysAndWait

        [TestMethod]
        public void TypeKeysAndWait1()
        {
            var cmd = new TypeKeysAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TypeKeysAndWait2()
        {
            var cmd = new TypeKeysAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void TypeKeysAndWait3()
        {
            var cmd = new TypeKeysAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region Uncheck

        [TestMethod]
        public void Uncheck1()
        {
            var cmd = new UncheckCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Uncheck2()
        {
            var cmd = new UncheckCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void Uncheck3()
        {
            var cmd = new UncheckCommand();
            cmd.Execute(context);
        }

        #endregion

        #region UncheckAndWait

        [TestMethod]
        public void UncheckAndWait1()
        {
            var cmd = new UncheckAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UncheckAndWait2()
        {
            var cmd = new UncheckAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void UncheckAndWait3()
        {
            var cmd = new UncheckAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region UseXpathLibrary

        [TestMethod]
        public void UseXpathLibrary1()
        {
            var cmd = new x_UseXpathLibraryCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UseXpathLibrary2()
        {
            var cmd = new x_UseXpathLibraryCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void UseXpathLibrary3()
        {
            var cmd = new x_UseXpathLibraryCommand();
            cmd.Execute(context);
        }

        #endregion

        #region UseXpathLibraryAndWait

        [TestMethod]
        public void UseXpathLibraryAndWait1()
        {
            var cmd = new x_UseXpathLibraryAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UseXpathLibraryAndWait2()
        {
            var cmd = new x_UseXpathLibraryAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void UseXpathLibraryAndWait3()
        {
            var cmd = new x_UseXpathLibraryAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAlert

        [TestMethod]
        public void VerifyAlert1()
        {
            var cmd = new VerifyAlertCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAlert2()
        {
            var cmd = new VerifyAlertCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAlert3()
        {
            var cmd = new VerifyAlertCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAlertNotPresent

        [TestMethod]
        public void VerifyAlertNotPresent1()
        {
            var cmd = new VerifyAlertNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAlertNotPresent2()
        {
            var cmd = new VerifyAlertNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAlertNotPresent3()
        {
            var cmd = new VerifyAlertNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAlertPresent

        [TestMethod]
        public void VerifyAlertPresent1()
        {
            var cmd = new VerifyAlertPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAlertPresent2()
        {
            var cmd = new VerifyAlertPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAlertPresent3()
        {
            var cmd = new VerifyAlertPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAllButtons

        [TestMethod]
        public void VerifyAllButtons1()
        {
            var cmd = new x_VerifyAllButtonsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAllButtons2()
        {
            var cmd = new x_VerifyAllButtonsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAllButtons3()
        {
            var cmd = new x_VerifyAllButtonsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAllFields

        [TestMethod]
        public void VerifyAllFields1()
        {
            var cmd = new x_VerifyAllFieldsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAllFields2()
        {
            var cmd = new x_VerifyAllFieldsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAllFields3()
        {
            var cmd = new x_VerifyAllFieldsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAllLinks

        [TestMethod]
        public void VerifyAllLinks1()
        {
            var cmd = new x_VerifyAllLinksCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAllLinks2()
        {
            var cmd = new x_VerifyAllLinksCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAllLinks3()
        {
            var cmd = new x_VerifyAllLinksCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAllWindowIds

        [TestMethod]
        public void VerifyAllWindowIds1()
        {
            var cmd = new x_VerifyAllWindowIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAllWindowIds2()
        {
            var cmd = new x_VerifyAllWindowIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAllWindowIds3()
        {
            var cmd = new x_VerifyAllWindowIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAllWindowNames

        [TestMethod]
        public void VerifyAllWindowNames1()
        {
            var cmd = new x_VerifyAllWindowNamesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAllWindowNames2()
        {
            var cmd = new x_VerifyAllWindowNamesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAllWindowNames3()
        {
            var cmd = new x_VerifyAllWindowNamesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAllWindowTitles

        [TestMethod]
        public void VerifyAllWindowTitles1()
        {
            var cmd = new x_VerifyAllWindowTitlesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAllWindowTitles2()
        {
            var cmd = new x_VerifyAllWindowTitlesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAllWindowTitles3()
        {
            var cmd = new x_VerifyAllWindowTitlesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAttribute

        [TestMethod]
        public void VerifyAttribute1()
        {
            var cmd = new VerifyAttributeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAttribute2()
        {
            var cmd = new VerifyAttributeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAttribute3()
        {
            var cmd = new VerifyAttributeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyAttributeFromAllWindows

        [TestMethod]
        public void VerifyAttributeFromAllWindows1()
        {
            var cmd = new x_VerifyAttributeFromAllWindowsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyAttributeFromAllWindows2()
        {
            var cmd = new x_VerifyAttributeFromAllWindowsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyAttributeFromAllWindows3()
        {
            var cmd = new x_VerifyAttributeFromAllWindowsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyBodyText

        [TestMethod]
        public void VerifyBodyText1()
        {
            var cmd = new VerifyBodyTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyBodyText2()
        {
            var cmd = new VerifyBodyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyBodyText3()
        {
            var cmd = new VerifyBodyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyChecked

        [TestMethod]
        public void VerifyChecked1()
        {
            var cmd = new VerifyCheckedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyChecked2()
        {
            var cmd = new VerifyCheckedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyChecked3()
        {
            var cmd = new VerifyCheckedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyConfirmation

        [TestMethod]
        public void VerifyConfirmation1()
        {
            var cmd = new VerifyConfirmationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyConfirmation2()
        {
            var cmd = new VerifyConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyConfirmation3()
        {
            var cmd = new VerifyConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyConfirmationNotPresent

        [TestMethod]
        public void VerifyConfirmationNotPresent1()
        {
            var cmd = new VerifyConfirmationNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyConfirmationNotPresent2()
        {
            var cmd = new VerifyConfirmationNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyConfirmationNotPresent3()
        {
            var cmd = new VerifyConfirmationNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyConfirmationPresent

        [TestMethod]
        public void VerifyConfirmationPresent1()
        {
            var cmd = new VerifyConfirmationPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyConfirmationPresent2()
        {
            var cmd = new VerifyConfirmationPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyConfirmationPresent3()
        {
            var cmd = new VerifyConfirmationPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyCookie

        [TestMethod]
        public void VerifyCookie1()
        {
            var cmd = new VerifyCookieCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyCookie2()
        {
            var cmd = new VerifyCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyCookie3()
        {
            var cmd = new VerifyCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyCookieByName

        [TestMethod]
        public void VerifyCookieByName1()
        {
            var cmd = new VerifyCookieByNameCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyCookieByName2()
        {
            var cmd = new VerifyCookieByNameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyCookieByName3()
        {
            var cmd = new VerifyCookieByNameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyCookieNotPresent

        [TestMethod]
        public void VerifyCookieNotPresent1()
        {
            var cmd = new VerifyCookieNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyCookieNotPresent2()
        {
            var cmd = new VerifyCookieNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyCookieNotPresent3()
        {
            var cmd = new VerifyCookieNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyCookiePresent

        [TestMethod]
        public void VerifyCookiePresent1()
        {
            var cmd = new VerifyCookiePresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyCookiePresent2()
        {
            var cmd = new VerifyCookiePresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyCookiePresent3()
        {
            var cmd = new VerifyCookiePresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyCursorPosition

        [TestMethod]
        public void VerifyCursorPosition1()
        {
            var cmd = new x_VerifyCursorPositionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyCursorPosition2()
        {
            var cmd = new x_VerifyCursorPositionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyCursorPosition3()
        {
            var cmd = new x_VerifyCursorPositionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyEditable

        [TestMethod]
        public void VerifyEditable1()
        {
            var cmd = new VerifyEditableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyEditable2()
        {
            var cmd = new VerifyEditableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyEditable3()
        {
            var cmd = new VerifyEditableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyElementHeight

        [TestMethod]
        public void VerifyElementHeight1()
        {
            var cmd = new VerifyElementHeightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyElementHeight2()
        {
            var cmd = new VerifyElementHeightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyElementHeight3()
        {
            var cmd = new VerifyElementHeightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyElementIndex

        [TestMethod]
        public void VerifyElementIndex1()
        {
            var cmd = new x_VerifyElementIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyElementIndex2()
        {
            var cmd = new x_VerifyElementIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyElementIndex3()
        {
            var cmd = new x_VerifyElementIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyElementNotPresent

        [TestMethod]
        public void VerifyElementNotPresent1()
        {
            var cmd = new VerifyElementNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyElementNotPresent2()
        {
            var cmd = new VerifyElementNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyElementNotPresent3()
        {
            var cmd = new VerifyElementNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyElementPositionLeft

        [TestMethod]
        public void VerifyElementPositionLeft1()
        {
            var cmd = new VerifyElementPositionLeftCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyElementPositionLeft2()
        {
            var cmd = new VerifyElementPositionLeftCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyElementPositionLeft3()
        {
            var cmd = new VerifyElementPositionLeftCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyElementPositionTop

        [TestMethod]
        public void VerifyElementPositionTop1()
        {
            var cmd = new VerifyElementPositionTopCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyElementPositionTop2()
        {
            var cmd = new VerifyElementPositionTopCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyElementPositionTop3()
        {
            var cmd = new VerifyElementPositionTopCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyElementPresent

        [TestMethod]
        public void VerifyElementPresent1()
        {
            var cmd = new VerifyElementPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyElementPresent2()
        {
            var cmd = new VerifyElementPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyElementPresent3()
        {
            var cmd = new VerifyElementPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyElementWidth

        [TestMethod]
        public void VerifyElementWidth1()
        {
            var cmd = new VerifyElementWidthCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyElementWidth2()
        {
            var cmd = new VerifyElementWidthCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyElementWidth3()
        {
            var cmd = new VerifyElementWidthCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyEval

        [TestMethod]
        public void VerifyEval1()
        {
            var cmd = new x_VerifyEvalCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyEval2()
        {
            var cmd = new x_VerifyEvalCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyEval3()
        {
            var cmd = new x_VerifyEvalCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyExpression

        [TestMethod]
        public void VerifyExpression1()
        {
            var cmd = new x_VerifyExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyExpression2()
        {
            var cmd = new x_VerifyExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyExpression3()
        {
            var cmd = new x_VerifyExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyHtmlSource

        [TestMethod]
        public void VerifyHtmlSource1()
        {
            var cmd = new x_VerifyHtmlSourceCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyHtmlSource2()
        {
            var cmd = new x_VerifyHtmlSourceCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyHtmlSource3()
        {
            var cmd = new x_VerifyHtmlSourceCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyLocation

        [TestMethod]
        public void VerifyLocation1()
        {
            var cmd = new VerifyLocationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyLocation2()
        {
            var cmd = new VerifyLocationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyLocation3()
        {
            var cmd = new VerifyLocationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyMouseSpeed

        [TestMethod]
        public void VerifyMouseSpeed1()
        {
            var cmd = new x_VerifyMouseSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyMouseSpeed2()
        {
            var cmd = new x_VerifyMouseSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyMouseSpeed3()
        {
            var cmd = new x_VerifyMouseSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAlert

        [TestMethod]
        public void VerifyNotAlert1()
        {
            var cmd = new VerifyNotAlertCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAlert2()
        {
            var cmd = new VerifyNotAlertCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAlert3()
        {
            var cmd = new VerifyNotAlertCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAllButtons

        [TestMethod]
        public void VerifyNotAllButtons1()
        {
            var cmd = new x_VerifyNotAllButtonsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAllButtons2()
        {
            var cmd = new x_VerifyNotAllButtonsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAllButtons3()
        {
            var cmd = new x_VerifyNotAllButtonsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAllFields

        [TestMethod]
        public void VerifyNotAllFields1()
        {
            var cmd = new x_VerifyNotAllFieldsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAllFields2()
        {
            var cmd = new x_VerifyNotAllFieldsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAllFields3()
        {
            var cmd = new x_VerifyNotAllFieldsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAllLinks

        [TestMethod]
        public void VerifyNotAllLinks1()
        {
            var cmd = new x_VerifyNotAllLinksCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAllLinks2()
        {
            var cmd = new x_VerifyNotAllLinksCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAllLinks3()
        {
            var cmd = new x_VerifyNotAllLinksCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAllWindowIds

        [TestMethod]
        public void VerifyNotAllWindowIds1()
        {
            var cmd = new x_VerifyNotAllWindowIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAllWindowIds2()
        {
            var cmd = new x_VerifyNotAllWindowIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAllWindowIds3()
        {
            var cmd = new x_VerifyNotAllWindowIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAllWindowNames

        [TestMethod]
        public void VerifyNotAllWindowNames1()
        {
            var cmd = new x_VerifyNotAllWindowNamesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAllWindowNames2()
        {
            var cmd = new x_VerifyNotAllWindowNamesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAllWindowNames3()
        {
            var cmd = new x_VerifyNotAllWindowNamesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAllWindowTitles

        [TestMethod]
        public void VerifyNotAllWindowTitles1()
        {
            var cmd = new x_VerifyNotAllWindowTitlesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAllWindowTitles2()
        {
            var cmd = new x_VerifyNotAllWindowTitlesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAllWindowTitles3()
        {
            var cmd = new x_VerifyNotAllWindowTitlesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAttribute

        [TestMethod]
        public void VerifyNotAttribute1()
        {
            var cmd = new VerifyNotAttributeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAttribute2()
        {
            var cmd = new VerifyNotAttributeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAttribute3()
        {
            var cmd = new VerifyNotAttributeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotAttributeFromAllWindows

        [TestMethod]
        public void VerifyNotAttributeFromAllWindows1()
        {
            var cmd = new x_VerifyNotAttributeFromAllWindowsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotAttributeFromAllWindows2()
        {
            var cmd = new x_VerifyNotAttributeFromAllWindowsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotAttributeFromAllWindows3()
        {
            var cmd = new x_VerifyNotAttributeFromAllWindowsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotBodyText

        [TestMethod]
        public void VerifyNotBodyText1()
        {
            var cmd = new VerifyNotBodyTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotBodyText2()
        {
            var cmd = new VerifyNotBodyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotBodyText3()
        {
            var cmd = new VerifyNotBodyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotChecked

        [TestMethod]
        public void VerifyNotChecked1()
        {
            var cmd = new VerifyNotCheckedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotChecked2()
        {
            var cmd = new VerifyNotCheckedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotChecked3()
        {
            var cmd = new VerifyNotCheckedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotConfirmation

        [TestMethod]
        public void VerifyNotConfirmation1()
        {
            var cmd = new VerifyNotConfirmationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotConfirmation2()
        {
            var cmd = new VerifyNotConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotConfirmation3()
        {
            var cmd = new VerifyNotConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotCookie

        [TestMethod]
        public void VerifyNotCookie1()
        {
            var cmd = new VerifyNotCookieCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotCookie2()
        {
            var cmd = new VerifyNotCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotCookie3()
        {
            var cmd = new VerifyNotCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotCookieByName

        [TestMethod]
        public void VerifyNotCookieByName1()
        {
            var cmd = new VerifyNotCookieByNameCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotCookieByName2()
        {
            var cmd = new VerifyNotCookieByNameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotCookieByName3()
        {
            var cmd = new VerifyNotCookieByNameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotCursorPosition

        [TestMethod]
        public void VerifyNotCursorPosition1()
        {
            var cmd = new x_VerifyNotCursorPositionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotCursorPosition2()
        {
            var cmd = new x_VerifyNotCursorPositionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotCursorPosition3()
        {
            var cmd = new x_VerifyNotCursorPositionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotEditable

        [TestMethod]
        public void VerifyNotEditable1()
        {
            var cmd = new VerifyNotEditableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotEditable2()
        {
            var cmd = new VerifyNotEditableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotEditable3()
        {
            var cmd = new VerifyNotEditableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotElementHeight

        [TestMethod]
        public void VerifyNotElementHeight1()
        {
            var cmd = new VerifyNotElementHeightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotElementHeight2()
        {
            var cmd = new VerifyNotElementHeightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotElementHeight3()
        {
            var cmd = new VerifyNotElementHeightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotElementIndex

        [TestMethod]
        public void VerifyNotElementIndex1()
        {
            var cmd = new x_VerifyNotElementIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotElementIndex2()
        {
            var cmd = new x_VerifyNotElementIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotElementIndex3()
        {
            var cmd = new x_VerifyNotElementIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotElementPositionLeft

        [TestMethod]
        public void VerifyNotElementPositionLeft1()
        {
            var cmd = new VerifyNotElementPositionLeftCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotElementPositionLeft2()
        {
            var cmd = new VerifyNotElementPositionLeftCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotElementPositionLeft3()
        {
            var cmd = new VerifyNotElementPositionLeftCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotElementPositionTop

        [TestMethod]
        public void VerifyNotElementPositionTop1()
        {
            var cmd = new VerifyNotElementPositionTopCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotElementPositionTop2()
        {
            var cmd = new VerifyNotElementPositionTopCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotElementPositionTop3()
        {
            var cmd = new VerifyNotElementPositionTopCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotElementWidth

        [TestMethod]
        public void VerifyNotElementWidth1()
        {
            var cmd = new VerifyNotElementWidthCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotElementWidth2()
        {
            var cmd = new VerifyNotElementWidthCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotElementWidth3()
        {
            var cmd = new VerifyNotElementWidthCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotEval

        [TestMethod]
        public void VerifyNotEval1()
        {
            var cmd = new x_VerifyNotEvalCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotEval2()
        {
            var cmd = new x_VerifyNotEvalCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotEval3()
        {
            var cmd = new x_VerifyNotEvalCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotExpression

        [TestMethod]
        public void VerifyNotExpression1()
        {
            var cmd = new x_VerifyNotExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotExpression2()
        {
            var cmd = new x_VerifyNotExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotExpression3()
        {
            var cmd = new x_VerifyNotExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotHtmlSource

        [TestMethod]
        public void VerifyNotHtmlSource1()
        {
            var cmd = new x_VerifyNotHtmlSourceCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotHtmlSource2()
        {
            var cmd = new x_VerifyNotHtmlSourceCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotHtmlSource3()
        {
            var cmd = new x_VerifyNotHtmlSourceCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotLocation

        [TestMethod]
        public void VerifyNotLocation1()
        {
            var cmd = new VerifyNotLocationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotLocation2()
        {
            var cmd = new VerifyNotLocationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotLocation3()
        {
            var cmd = new VerifyNotLocationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotMouseSpeed

        [TestMethod]
        public void VerifyNotMouseSpeed1()
        {
            var cmd = new x_VerifyNotMouseSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotMouseSpeed2()
        {
            var cmd = new x_VerifyNotMouseSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotMouseSpeed3()
        {
            var cmd = new x_VerifyNotMouseSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotOrdered

        [TestMethod]
        public void VerifyNotOrdered1()
        {
            var cmd = new x_VerifyNotOrderedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotOrdered2()
        {
            var cmd = new x_VerifyNotOrderedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotOrdered3()
        {
            var cmd = new x_VerifyNotOrderedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotPrompt

        [TestMethod]
        public void VerifyNotPrompt1()
        {
            var cmd = new VerifyNotPromptCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotPrompt2()
        {
            var cmd = new VerifyNotPromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotPrompt3()
        {
            var cmd = new VerifyNotPromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectOptions

        [TestMethod]
        public void VerifyNotSelectOptions1()
        {
            var cmd = new VerifyNotSelectOptionsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectOptions2()
        {
            var cmd = new VerifyNotSelectOptionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectOptions3()
        {
            var cmd = new VerifyNotSelectOptionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedId

        [TestMethod]
        public void VerifyNotSelectedId1()
        {
            var cmd = new VerifyNotSelectedIdCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedId2()
        {
            var cmd = new VerifyNotSelectedIdCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedId3()
        {
            var cmd = new VerifyNotSelectedIdCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedIds

        [TestMethod]
        public void VerifyNotSelectedIds1()
        {
            var cmd = new VerifyNotSelectedIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedIds2()
        {
            var cmd = new VerifyNotSelectedIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedIds3()
        {
            var cmd = new VerifyNotSelectedIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedIndex

        [TestMethod]
        public void VerifyNotSelectedIndex1()
        {
            var cmd = new VerifyNotSelectedIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedIndex2()
        {
            var cmd = new VerifyNotSelectedIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedIndex3()
        {
            var cmd = new VerifyNotSelectedIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedIndexes

        [TestMethod]
        public void VerifyNotSelectedIndexes1()
        {
            var cmd = new VerifyNotSelectedIndexesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedIndexes2()
        {
            var cmd = new VerifyNotSelectedIndexesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedIndexes3()
        {
            var cmd = new VerifyNotSelectedIndexesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedLabel

        [TestMethod]
        public void VerifyNotSelectedLabel1()
        {
            var cmd = new VerifyNotSelectedLabelCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedLabel2()
        {
            var cmd = new VerifyNotSelectedLabelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedLabel3()
        {
            var cmd = new VerifyNotSelectedLabelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedLabels

        [TestMethod]
        public void VerifyNotSelectedLabels1()
        {
            var cmd = new VerifyNotSelectedLabelsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedLabels2()
        {
            var cmd = new VerifyNotSelectedLabelsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedLabels3()
        {
            var cmd = new VerifyNotSelectedLabelsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedValue

        [TestMethod]
        public void VerifyNotSelectedValue1()
        {
            var cmd = new VerifyNotSelectedValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedValue2()
        {
            var cmd = new VerifyNotSelectedValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedValue3()
        {
            var cmd = new VerifyNotSelectedValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSelectedValues

        [TestMethod]
        public void VerifyNotSelectedValues1()
        {
            var cmd = new VerifyNotSelectedValuesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSelectedValues2()
        {
            var cmd = new VerifyNotSelectedValuesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSelectedValues3()
        {
            var cmd = new VerifyNotSelectedValuesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSomethingSelected

        [TestMethod]
        public void VerifyNotSomethingSelected1()
        {
            var cmd = new VerifyNotSomethingSelectedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSomethingSelected2()
        {
            var cmd = new VerifyNotSomethingSelectedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSomethingSelected3()
        {
            var cmd = new VerifyNotSomethingSelectedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotSpeed

        [TestMethod]
        public void VerifyNotSpeed1()
        {
            var cmd = new x_VerifyNotSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotSpeed2()
        {
            var cmd = new x_VerifyNotSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotSpeed3()
        {
            var cmd = new x_VerifyNotSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotTable

        [TestMethod]
        public void VerifyNotTable1()
        {
            var cmd = new x_VerifyNotTableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotTable2()
        {
            var cmd = new x_VerifyNotTableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotTable3()
        {
            var cmd = new x_VerifyNotTableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotText

        [TestMethod]
        public void VerifyNotText1()
        {
            var cmd = new VerifyNotTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotText2()
        {
            var cmd = new VerifyNotTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotText3()
        {
            var cmd = new VerifyNotTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotTitle

        [TestMethod]
        public void VerifyNotTitle1()
        {
            var cmd = new VerifyNotTitleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotTitle2()
        {
            var cmd = new VerifyNotTitleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotTitle3()
        {
            var cmd = new VerifyNotTitleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotValue

        [TestMethod]
        public void VerifyNotValue1()
        {
            var cmd = new VerifyNotValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotValue2()
        {
            var cmd = new VerifyNotValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotValue3()
        {
            var cmd = new VerifyNotValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotVisible

        [TestMethod]
        public void VerifyNotVisible1()
        {
            var cmd = new VerifyNotVisibleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotVisible2()
        {
            var cmd = new VerifyNotVisibleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotVisible3()
        {
            var cmd = new VerifyNotVisibleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotWhetherThisFrameMatchFrameExpression

        [TestMethod]
        public void VerifyNotWhetherThisFrameMatchFrameExpression1()
        {
            var cmd = new x_VerifyNotWhetherThisFrameMatchFrameExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotWhetherThisFrameMatchFrameExpression2()
        {
            var cmd = new x_VerifyNotWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotWhetherThisFrameMatchFrameExpression3()
        {
            var cmd = new x_VerifyNotWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotWhetherThisWindowMatchWindowExpression

        [TestMethod]
        public void VerifyNotWhetherThisWindowMatchWindowExpression1()
        {
            var cmd = new x_VerifyNotWhetherThisWindowMatchWindowExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotWhetherThisWindowMatchWindowExpression2()
        {
            var cmd = new x_VerifyNotWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotWhetherThisWindowMatchWindowExpression3()
        {
            var cmd = new x_VerifyNotWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyNotXpathCount

        [TestMethod]
        public void VerifyNotXpathCount1()
        {
            var cmd = new x_VerifyNotXpathCountCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyNotXpathCount2()
        {
            var cmd = new x_VerifyNotXpathCountCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyNotXpathCount3()
        {
            var cmd = new x_VerifyNotXpathCountCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyOrdered

        [TestMethod]
        public void VerifyOrdered1()
        {
            var cmd = new x_VerifyOrderedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyOrdered2()
        {
            var cmd = new x_VerifyOrderedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyOrdered3()
        {
            var cmd = new x_VerifyOrderedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyPrompt

        [TestMethod]
        public void VerifyPrompt1()
        {
            var cmd = new VerifyPromptCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyPrompt2()
        {
            var cmd = new VerifyPromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyPrompt3()
        {
            var cmd = new VerifyPromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyPromptNotPresent

        [TestMethod]
        public void VerifyPromptNotPresent1()
        {
            var cmd = new VerifyPromptNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyPromptNotPresent2()
        {
            var cmd = new VerifyPromptNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyPromptNotPresent3()
        {
            var cmd = new VerifyPromptNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyPromptPresent

        [TestMethod]
        public void VerifyPromptPresent1()
        {
            var cmd = new VerifyPromptPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyPromptPresent2()
        {
            var cmd = new VerifyPromptPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyPromptPresent3()
        {
            var cmd = new VerifyPromptPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectOptions

        [TestMethod]
        public void VerifySelectOptions1()
        {
            var cmd = new VerifySelectOptionsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectOptions2()
        {
            var cmd = new VerifySelectOptionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectOptions3()
        {
            var cmd = new VerifySelectOptionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectedId

        [TestMethod]
        public void VerifySelectedId1()
        {
            var cmd = new VerifySelectedIdCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectedId2()
        {
            var cmd = new VerifySelectedIdCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectedId3()
        {
            var cmd = new VerifySelectedIdCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectedIds

        [TestMethod]
        public void VerifySelectedIds1()
        {
            var cmd = new VerifySelectedIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectedIds2()
        {
            var cmd = new VerifySelectedIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectedIds3()
        {
            var cmd = new VerifySelectedIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectedIndex

        [TestMethod]
        public void VerifySelectedIndex1()
        {
            var cmd = new VerifySelectedIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectedIndex2()
        {
            var cmd = new VerifySelectedIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectedIndex3()
        {
            var cmd = new VerifySelectedIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectedLabel

        [TestMethod]
        public void VerifySelectedLabel1()
        {
            var cmd = new VerifySelectedLabelCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectedLabel2()
        {
            var cmd = new VerifySelectedLabelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectedLabel3()
        {
            var cmd = new VerifySelectedLabelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectedLabels

        [TestMethod]
        public void VerifySelectedLabels1()
        {
            var cmd = new VerifySelectedLabelsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectedLabels2()
        {
            var cmd = new VerifySelectedLabelsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectedLabels3()
        {
            var cmd = new VerifySelectedLabelsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectedValue

        [TestMethod]
        public void VerifySelectedValue1()
        {
            var cmd = new VerifySelectedValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectedValue2()
        {
            var cmd = new VerifySelectedValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectedValue3()
        {
            var cmd = new VerifySelectedValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySelectedValues

        [TestMethod]
        public void VerifySelectedValues1()
        {
            var cmd = new VerifySelectedValuesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySelectedValues2()
        {
            var cmd = new VerifySelectedValuesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySelectedValues3()
        {
            var cmd = new VerifySelectedValuesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySomethingSelected

        [TestMethod]
        public void VerifySomethingSelected1()
        {
            var cmd = new VerifySomethingSelectedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySomethingSelected2()
        {
            var cmd = new VerifySomethingSelectedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySomethingSelected3()
        {
            var cmd = new VerifySomethingSelectedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifySpeed

        [TestMethod]
        public void VerifySpeed1()
        {
            var cmd = new x_VerifySpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifySpeed2()
        {
            var cmd = new x_VerifySpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifySpeed3()
        {
            var cmd = new x_VerifySpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyTable

        [TestMethod]
        public void VerifyTable1()
        {
            var cmd = new x_VerifyTableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyTable2()
        {
            var cmd = new x_VerifyTableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyTable3()
        {
            var cmd = new x_VerifyTableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyText

        [TestMethod]
        public void VerifyText1()
        {
            var cmd = new VerifyTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyText2()
        {
            var cmd = new VerifyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyText3()
        {
            var cmd = new VerifyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyTextNotPresent

        [TestMethod]
        public void VerifyTextNotPresent1()
        {
            var cmd = new VerifyTextNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyTextNotPresent2()
        {
            var cmd = new VerifyTextNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyTextNotPresent3()
        {
            var cmd = new VerifyTextNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyTextPresent

        [TestMethod]
        public void VerifyTextPresent1()
        {
            var cmd = new VerifyTextPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyTextPresent2()
        {
            var cmd = new VerifyTextPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyTextPresent3()
        {
            var cmd = new VerifyTextPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyTitle

        [TestMethod]
        public void VerifyTitle1()
        {
            var cmd = new VerifyTitleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyTitle2()
        {
            var cmd = new VerifyTitleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyTitle3()
        {
            var cmd = new VerifyTitleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyValue

        [TestMethod]
        public void VerifyValue1()
        {
            var cmd = new VerifyValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyValue2()
        {
            var cmd = new VerifyValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyValue3()
        {
            var cmd = new VerifyValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyVisible

        [TestMethod]
        public void VerifyVisible1()
        {
            var cmd = new VerifyVisibleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyVisible2()
        {
            var cmd = new VerifyVisibleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyVisible3()
        {
            var cmd = new VerifyVisibleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyWhetherThisFrameMatchFrameExpression

        [TestMethod]
        public void VerifyWhetherThisFrameMatchFrameExpression1()
        {
            var cmd = new x_VerifyWhetherThisFrameMatchFrameExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyWhetherThisFrameMatchFrameExpression2()
        {
            var cmd = new x_VerifyWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyWhetherThisFrameMatchFrameExpression3()
        {
            var cmd = new x_VerifyWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyWhetherThisWindowMatchWindowExpression

        [TestMethod]
        public void VerifyWhetherThisWindowMatchWindowExpression1()
        {
            var cmd = new x_VerifyWhetherThisWindowMatchWindowExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyWhetherThisWindowMatchWindowExpression2()
        {
            var cmd = new x_VerifyWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyWhetherThisWindowMatchWindowExpression3()
        {
            var cmd = new x_VerifyWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region VerifyXpathCount

        [TestMethod]
        public void VerifyXpathCount1()
        {
            var cmd = new x_VerifyXpathCountCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyXpathCount2()
        {
            var cmd = new x_VerifyXpathCountCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void VerifyXpathCount3()
        {
            var cmd = new x_VerifyXpathCountCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForAlert

        [TestMethod]
        public void WaitForAlert1()
        {
            var cmd = new WaitForAlertCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAlert2()
        {
            var cmd = new WaitForAlertCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAlert3()
        {
            var cmd = new WaitForAlertCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForAlertNotPresent

        [TestMethod]
        public void WaitForAlertNotPresent1()
        {
            var cmd = new WaitForAlertNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAlertNotPresent2()
        {
            var cmd = new WaitForAlertNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAlertNotPresent3()
        {
            var cmd = new WaitForAlertNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForAlertPresent

        [TestMethod]
        public void WaitForAlertPresent1()
        {
            var cmd = new WaitForAlertPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAlertPresent2()
        {
            var cmd = new WaitForAlertPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAlertPresent3()
        {
            var cmd = new WaitForAlertPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForAllButtons

        [TestMethod]
        public void WaitForAllButtons1()
        {
            var cmd = new x_WaitForAllButtonsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAllButtons2()
        {
            var cmd = new x_WaitForAllButtonsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAllButtons3()
        {
            var cmd = new x_WaitForAllButtonsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForAllFields

        [TestMethod]
        public void WaitForAllFields1()
        {
            var cmd = new x_WaitForAllFieldsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAllFields2()
        {
            var cmd = new x_WaitForAllFieldsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAllFields3()
        {
            var cmd = new x_WaitForAllFieldsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForAllLinks

        [TestMethod]
        public void WaitForAllLinks1()
        {
            var cmd = new x_WaitForAllLinksCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAllLinks2()
        {
            var cmd = new x_WaitForAllLinksCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAllLinks3()
        {
            var cmd = new x_WaitForAllLinksCommand();
            cmd.Execute(context);
        }

        #endregion

        //#region WaitForAllWindowIds

        //[TestMethod]
        //public void WaitForAllWindowIds1()
        //{
        //    var cmd = new x_WaitForAllWindowIdsCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForAllWindowIds2()
        //{
        //    var cmd = new x_WaitForAllWindowIdsCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForAllWindowIds3()
        //{
        //    var cmd = new x_WaitForAllWindowIdsCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForAllWindowNames

        //[TestMethod]
        //public void WaitForAllWindowNames1()
        //{
        //    var cmd = new x_WaitForAllWindowNamesCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForAllWindowNames2()
        //{
        //    var cmd = new x_WaitForAllWindowNamesCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForAllWindowNames3()
        //{
        //    var cmd = new x_WaitForAllWindowNamesCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForAllWindowTitles

        //[TestMethod]
        //public void WaitForAllWindowTitles1()
        //{
        //    var cmd = new x_WaitForAllWindowTitlesCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForAllWindowTitles2()
        //{
        //    var cmd = new x_WaitForAllWindowTitlesCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForAllWindowTitles3()
        //{
        //    var cmd = new x_WaitForAllWindowTitlesCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        #region WaitForAttribute

        [TestMethod]
        public void WaitForAttribute1()
        {
            var cmd = new WaitForAttributeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAttribute2()
        {
            var cmd = new WaitForAttributeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAttribute3()
        {
            var cmd = new WaitForAttributeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForAttributeFromAllWindows

        [TestMethod]
        public void WaitForAttributeFromAllWindows1()
        {
            var cmd = new x_WaitForAttributeFromAllWindowsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForAttributeFromAllWindows2()
        {
            var cmd = new x_WaitForAttributeFromAllWindowsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForAttributeFromAllWindows3()
        {
            var cmd = new x_WaitForAttributeFromAllWindowsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForBodyText

        [TestMethod]
        public void WaitForBodyText1()
        {
            var cmd = new WaitForBodyTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForBodyText2()
        {
            var cmd = new WaitForBodyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForBodyText3()
        {
            var cmd = new WaitForBodyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForChecked

        [TestMethod]
        public void WaitForChecked1()
        {
            var cmd = new WaitForCheckedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForChecked2()
        {
            var cmd = new WaitForCheckedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForChecked3()
        {
            var cmd = new WaitForCheckedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForCondition

        [TestMethod]
        public void WaitForCondition1()
        {
            var cmd = new x_WaitForConditionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForCondition2()
        {
            var cmd = new x_WaitForConditionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForCondition3()
        {
            var cmd = new x_WaitForConditionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForConfirmation

        [TestMethod]
        public void WaitForConfirmation1()
        {
            var cmd = new WaitForConfirmationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForConfirmation2()
        {
            var cmd = new WaitForConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForConfirmation3()
        {
            var cmd = new WaitForConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForConfirmationNotPresent

        [TestMethod]
        public void WaitForConfirmationNotPresent1()
        {
            var cmd = new WaitForConfirmationNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForConfirmationNotPresent2()
        {
            var cmd = new WaitForConfirmationNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForConfirmationNotPresent3()
        {
            var cmd = new WaitForConfirmationNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForConfirmationPresent

        [TestMethod]
        public void WaitForConfirmationPresent1()
        {
            var cmd = new WaitForConfirmationPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForConfirmationPresent2()
        {
            var cmd = new WaitForConfirmationPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForConfirmationPresent3()
        {
            var cmd = new WaitForConfirmationPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForCookie

        [TestMethod]
        public void WaitForCookie1()
        {
            var cmd = new WaitForCookieCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForCookie2()
        {
            var cmd = new WaitForCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForCookie3()
        {
            var cmd = new WaitForCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForCookieByName

        [TestMethod]
        public void WaitForCookieByName1()
        {
            var cmd = new WaitForCookieByNameCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForCookieByName2()
        {
            var cmd = new WaitForCookieByNameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForCookieByName3()
        {
            var cmd = new WaitForCookieByNameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForCookieNotPresent

        [TestMethod]
        public void WaitForCookieNotPresent1()
        {
            var cmd = new WaitForCookieNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForCookieNotPresent2()
        {
            var cmd = new WaitForCookieNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForCookieNotPresent3()
        {
            var cmd = new WaitForCookieNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForCookiePresent

        [TestMethod]
        public void WaitForCookiePresent1()
        {
            var cmd = new WaitForCookiePresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForCookiePresent2()
        {
            var cmd = new WaitForCookiePresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForCookiePresent3()
        {
            var cmd = new WaitForCookiePresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForCursorPosition

        [TestMethod]
        public void WaitForCursorPosition1()
        {
            var cmd = new x_WaitForCursorPositionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForCursorPosition2()
        {
            var cmd = new x_WaitForCursorPositionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForCursorPosition3()
        {
            var cmd = new x_WaitForCursorPositionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForEditable

        [TestMethod]
        public void WaitForEditable1()
        {
            var cmd = new WaitForEditableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForEditable2()
        {
            var cmd = new WaitForEditableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForEditable3()
        {
            var cmd = new WaitForEditableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForElementHeight

        [TestMethod]
        public void WaitForElementHeight1()
        {
            var cmd = new WaitForElementHeightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForElementHeight2()
        {
            var cmd = new WaitForElementHeightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForElementHeight3()
        {
            var cmd = new WaitForElementHeightCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForElementIndex

        [TestMethod]
        public void WaitForElementIndex1()
        {
            var cmd = new x_WaitForElementIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForElementIndex2()
        {
            var cmd = new x_WaitForElementIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForElementIndex3()
        {
            var cmd = new x_WaitForElementIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForElementNotPresent

        [TestMethod]
        public void WaitForElementNotPresent1()
        {
            var cmd = new WaitForElementNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForElementNotPresent2()
        {
            var cmd = new WaitForElementNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForElementNotPresent3()
        {
            var cmd = new WaitForElementNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForElementPositionLeft

        [TestMethod]
        public void WaitForElementPositionLeft1()
        {
            var cmd = new WaitForElementPositionLeftCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForElementPositionLeft2()
        {
            var cmd = new WaitForElementPositionLeftCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForElementPositionLeft3()
        {
            var cmd = new WaitForElementPositionLeftCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForElementPositionTop

        [TestMethod]
        public void WaitForElementPositionTop1()
        {
            var cmd = new WaitForElementPositionTopCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForElementPositionTop2()
        {
            var cmd = new WaitForElementPositionTopCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForElementPositionTop3()
        {
            var cmd = new WaitForElementPositionTopCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForElementPresent

        [TestMethod]
        public void WaitForElementPresent1()
        {
            var cmd = new WaitForElementPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForElementPresent2()
        {
            var cmd = new WaitForElementPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForElementPresent3()
        {
            var cmd = new WaitForElementPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForElementWidth

        [TestMethod]
        public void WaitForElementWidth1()
        {
            var cmd = new WaitForElementWidthCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForElementWidth2()
        {
            var cmd = new WaitForElementWidthCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForElementWidth3()
        {
            var cmd = new WaitForElementWidthCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForEval

        [TestMethod]
        public void WaitForEval1()
        {
            var cmd = new x_WaitForEvalCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForEval2()
        {
            var cmd = new x_WaitForEvalCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForEval3()
        {
            var cmd = new x_WaitForEvalCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForExpression

        [TestMethod]
        public void WaitForExpression1()
        {
            var cmd = new x_WaitForExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForExpression2()
        {
            var cmd = new x_WaitForExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForExpression3()
        {
            var cmd = new x_WaitForExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForFrameToLoad

        [TestMethod]
        public void WaitForFrameToLoad1()
        {
            var cmd = new WaitForFrameToLoadCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForFrameToLoad2()
        {
            var cmd = new WaitForFrameToLoadCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForFrameToLoad3()
        {
            var cmd = new WaitForFrameToLoadCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForHtmlSource

        [TestMethod]
        public void WaitForHtmlSource1()
        {
            var cmd = new x_WaitForHtmlSourceCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForHtmlSource2()
        {
            var cmd = new x_WaitForHtmlSourceCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForHtmlSource3()
        {
            var cmd = new x_WaitForHtmlSourceCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForLocation

        [TestMethod]
        public void WaitForLocation1()
        {
            var cmd = new WaitForLocationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForLocation2()
        {
            var cmd = new WaitForLocationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForLocation3()
        {
            var cmd = new WaitForLocationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForMouseSpeed

        [TestMethod]
        public void WaitForMouseSpeed1()
        {
            var cmd = new x_WaitForMouseSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForMouseSpeed2()
        {
            var cmd = new x_WaitForMouseSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForMouseSpeed3()
        {
            var cmd = new x_WaitForMouseSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAlert

        [TestMethod]
        public void WaitForNotAlert1()
        {
            var cmd = new WaitForNotAlertCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAlert2()
        {
            var cmd = new WaitForNotAlertCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAlert3()
        {
            var cmd = new WaitForNotAlertCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAllButtons

        [TestMethod]
        public void WaitForNotAllButtons1()
        {
            var cmd = new x_WaitForNotAllButtonsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAllButtons2()
        {
            var cmd = new x_WaitForNotAllButtonsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAllButtons3()
        {
            var cmd = new x_WaitForNotAllButtonsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAllFields

        [TestMethod]
        public void WaitForNotAllFields1()
        {
            var cmd = new x_WaitForNotAllFieldsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAllFields2()
        {
            var cmd = new x_WaitForNotAllFieldsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAllFields3()
        {
            var cmd = new x_WaitForNotAllFieldsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAllLinks

        [TestMethod]
        public void WaitForNotAllLinks1()
        {
            var cmd = new x_WaitForNotAllLinksCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAllLinks2()
        {
            var cmd = new x_WaitForNotAllLinksCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAllLinks3()
        {
            var cmd = new x_WaitForNotAllLinksCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAllWindowIds

        [TestMethod]
        public void WaitForNotAllWindowIds1()
        {
            var cmd = new x_WaitForNotAllWindowIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAllWindowIds2()
        {
            var cmd = new x_WaitForNotAllWindowIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAllWindowIds3()
        {
            var cmd = new x_WaitForNotAllWindowIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAllWindowNames

        [TestMethod]
        public void WaitForNotAllWindowNames1()
        {
            var cmd = new x_WaitForNotAllWindowNamesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAllWindowNames2()
        {
            var cmd = new x_WaitForNotAllWindowNamesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAllWindowNames3()
        {
            var cmd = new x_WaitForNotAllWindowNamesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAllWindowTitles

        [TestMethod]
        public void WaitForNotAllWindowTitles1()
        {
            var cmd = new x_WaitForNotAllWindowTitlesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAllWindowTitles2()
        {
            var cmd = new x_WaitForNotAllWindowTitlesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAllWindowTitles3()
        {
            var cmd = new x_WaitForNotAllWindowTitlesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAttribute

        [TestMethod]
        public void WaitForNotAttribute1()
        {
            var cmd = new WaitForNotAttributeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAttribute2()
        {
            var cmd = new WaitForNotAttributeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAttribute3()
        {
            var cmd = new WaitForNotAttributeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotAttributeFromAllWindows

        [TestMethod]
        public void WaitForNotAttributeFromAllWindows1()
        {
            var cmd = new x_WaitForNotAttributeFromAllWindowsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotAttributeFromAllWindows2()
        {
            var cmd = new x_WaitForNotAttributeFromAllWindowsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotAttributeFromAllWindows3()
        {
            var cmd = new x_WaitForNotAttributeFromAllWindowsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotBodyText

        [TestMethod]
        public void WaitForNotBodyText1()
        {
            var cmd = new WaitForNotBodyTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotBodyText2()
        {
            var cmd = new WaitForNotBodyTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotBodyText3()
        {
            var cmd = new WaitForNotBodyTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotChecked

        [TestMethod]
        public void WaitForNotChecked1()
        {
            var cmd = new WaitForNotCheckedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotChecked2()
        {
            var cmd = new WaitForNotCheckedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotChecked3()
        {
            var cmd = new WaitForNotCheckedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotConfirmation

        [TestMethod]
        public void WaitForNotConfirmation1()
        {
            var cmd = new WaitForNotConfirmationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotConfirmation2()
        {
            var cmd = new WaitForNotConfirmationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotConfirmation3()
        {
            var cmd = new WaitForNotConfirmationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotCookie

        [TestMethod]
        public void WaitForNotCookie1()
        {
            var cmd = new WaitForNotCookieCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotCookie2()
        {
            var cmd = new WaitForNotCookieCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotCookie3()
        {
            var cmd = new WaitForNotCookieCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotCookieByName

        [TestMethod]
        public void WaitForNotCookieByName1()
        {
            var cmd = new WaitForNotCookieByNameCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotCookieByName2()
        {
            var cmd = new WaitForNotCookieByNameCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotCookieByName3()
        {
            var cmd = new WaitForNotCookieByNameCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotCursorPosition

        [TestMethod]
        public void WaitForNotCursorPosition1()
        {
            var cmd = new x_WaitForNotCursorPositionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotCursorPosition2()
        {
            var cmd = new x_WaitForNotCursorPositionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotCursorPosition3()
        {
            var cmd = new x_WaitForNotCursorPositionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotEditable

        [TestMethod]
        public void WaitForNotEditable1()
        {
            var cmd = new WaitForNotEditableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotEditable2()
        {
            var cmd = new WaitForNotEditableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotEditable3()
        {
            var cmd = new WaitForNotEditableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotElementHeight

        [TestMethod]
        public void WaitForNotElementHeight1()
        {
            var cmd = new WaitForNotElementHeightCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotElementHeight2()
        {
            var cmd = new WaitForNotElementHeightCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotElementHeight3()
        {
            var cmd = new WaitForNotElementHeightCommand();
            cmd.Execute(context);
        }

        #endregion

        //#region WaitForNotElementIndex

        //[TestMethod]
        //public void WaitForNotElementIndex1()
        //{
        //    var cmd = new x_WaitForNotElementIndexCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForNotElementIndex2()
        //{
        //    var cmd = new x_WaitForNotElementIndexCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForNotElementIndex3()
        //{
        //    var cmd = new x_WaitForNotElementIndexCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForNotElementPositionLeft

        //[TestMethod]
        //public void WaitForNotElementPositionLeft1()
        //{
        //    var cmd = new WaitForNotElementPositionLeftCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForNotElementPositionLeft2()
        //{
        //    var cmd = new WaitForNotElementPositionLeftCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForNotElementPositionLeft3()
        //{
        //    var cmd = new WaitForNotElementPositionLeftCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForNotElementPositionTop

        //[TestMethod]
        //public void WaitForNotElementPositionTop1()
        //{
        //    var cmd = new WaitForNotElementPositionTopCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForNotElementPositionTop2()
        //{
        //    var cmd = new WaitForNotElementPositionTopCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForNotElementPositionTop3()
        //{
        //    var cmd = new WaitForNotElementPositionTopCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForNotElementWidth

        //[TestMethod]
        //public void WaitForNotElementWidth1()
        //{
        //    var cmd = new WaitForNotElementWidthCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForNotElementWidth2()
        //{
        //    var cmd = new WaitForNotElementWidthCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForNotElementWidth3()
        //{
        //    var cmd = new WaitForNotElementWidthCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForNotEval

        //[TestMethod]
        //public void WaitForNotEval1()
        //{
        //    var cmd = new x_WaitForNotEvalCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForNotEval2()
        //{
        //    var cmd = new x_WaitForNotEvalCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForNotEval3()
        //{
        //    var cmd = new x_WaitForNotEvalCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForNotExpression

        //[TestMethod]
        //public void WaitForNotExpression1()
        //{
        //    var cmd = new x_WaitForNotExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForNotExpression2()
        //{
        //    var cmd = new x_WaitForNotExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForNotExpression3()
        //{
        //    var cmd = new x_WaitForNotExpressionCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        //#region WaitForNotHtmlSource

        //[TestMethod]
        //public void WaitForNotHtmlSource1()
        //{
        //    var cmd = new x_WaitForNotHtmlSourceCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForNotHtmlSource2()
        //{
        //    var cmd = new x_WaitForNotHtmlSourceCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForNotHtmlSource3()
        //{
        //    var cmd = new x_WaitForNotHtmlSourceCommand();
        //    cmd.Execute(context);
        //}

        //#endregion

        #region WaitForNotLocation

        [TestMethod]
        public void WaitForNotLocation1()
        {
            var cmd = new WaitForNotLocationCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotLocation2()
        {
            var cmd = new WaitForNotLocationCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotLocation3()
        {
            var cmd = new WaitForNotLocationCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotMouseSpeed

        [TestMethod]
        public void WaitForNotMouseSpeed1()
        {
            var cmd = new x_WaitForNotMouseSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotMouseSpeed2()
        {
            var cmd = new x_WaitForNotMouseSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotMouseSpeed3()
        {
            var cmd = new x_WaitForNotMouseSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotOrdered

        [TestMethod]
        public void WaitForNotOrdered1()
        {
            var cmd = new x_WaitForNotOrderedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotOrdered2()
        {
            var cmd = new x_WaitForNotOrderedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotOrdered3()
        {
            var cmd = new x_WaitForNotOrderedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotPrompt

        [TestMethod]
        public void WaitForNotPrompt1()
        {
            var cmd = new WaitForNotPromptCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotPrompt2()
        {
            var cmd = new WaitForNotPromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotPrompt3()
        {
            var cmd = new WaitForNotPromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectOptions

        [TestMethod]
        public void WaitForNotSelectOptions1()
        {
            var cmd = new WaitForNotSelectOptionsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectOptions2()
        {
            var cmd = new WaitForNotSelectOptionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectOptions3()
        {
            var cmd = new WaitForNotSelectOptionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedId

        [TestMethod]
        public void WaitForNotSelectedId1()
        {
            var cmd = new WaitForNotSelectedIdCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedId2()
        {
            var cmd = new WaitForNotSelectedIdCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedId3()
        {
            var cmd = new WaitForNotSelectedIdCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedIds

        [TestMethod]
        public void WaitForNotSelectedIds1()
        {
            var cmd = new WaitForNotSelectedIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedIds2()
        {
            var cmd = new WaitForNotSelectedIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedIds3()
        {
            var cmd = new WaitForNotSelectedIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedIndex

        [TestMethod]
        public void WaitForNotSelectedIndex1()
        {
            var cmd = new WaitForNotSelectedIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedIndex2()
        {
            var cmd = new WaitForNotSelectedIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedIndex3()
        {
            var cmd = new WaitForNotSelectedIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedIndexes

        [TestMethod]
        public void WaitForNotSelectedIndexes1()
        {
            var cmd = new WaitForNotSelectedIndexesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedIndexes2()
        {
            var cmd = new WaitForNotSelectedIndexesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedIndexes3()
        {
            var cmd = new WaitForNotSelectedIndexesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedLabel

        [TestMethod]
        public void WaitForNotSelectedLabel1()
        {
            var cmd = new WaitForNotSelectedLabelCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedLabel2()
        {
            var cmd = new WaitForNotSelectedLabelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedLabel3()
        {
            var cmd = new WaitForNotSelectedLabelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedLabels

        [TestMethod]
        public void WaitForNotSelectedLabels1()
        {
            var cmd = new WaitForNotSelectedLabelsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedLabels2()
        {
            var cmd = new WaitForNotSelectedLabelsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedLabels3()
        {
            var cmd = new WaitForNotSelectedLabelsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedValue

        [TestMethod]
        public void WaitForNotSelectedValue1()
        {
            var cmd = new WaitForNotSelectedValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedValue2()
        {
            var cmd = new WaitForNotSelectedValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedValue3()
        {
            var cmd = new WaitForNotSelectedValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSelectedValues

        [TestMethod]
        public void WaitForNotSelectedValues1()
        {
            var cmd = new WaitForNotSelectedValuesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSelectedValues2()
        {
            var cmd = new WaitForNotSelectedValuesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSelectedValues3()
        {
            var cmd = new WaitForNotSelectedValuesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSomethingSelected

        [TestMethod]
        public void WaitForNotSomethingSelected1()
        {
            var cmd = new WaitForNotSomethingSelectedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSomethingSelected2()
        {
            var cmd = new WaitForNotSomethingSelectedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSomethingSelected3()
        {
            var cmd = new WaitForNotSomethingSelectedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotSpeed

        [TestMethod]
        public void WaitForNotSpeed1()
        {
            var cmd = new x_WaitForNotSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotSpeed2()
        {
            var cmd = new x_WaitForNotSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotSpeed3()
        {
            var cmd = new x_WaitForNotSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotTable

        [TestMethod]
        public void WaitForNotTable1()
        {
            var cmd = new x_WaitForNotTableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotTable2()
        {
            var cmd = new x_WaitForNotTableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotTable3()
        {
            var cmd = new x_WaitForNotTableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotText

        [TestMethod]
        public void WaitForNotText1()
        {
            var cmd = new WaitForNotTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotText2()
        {
            var cmd = new WaitForNotTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotText3()
        {
            var cmd = new WaitForNotTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotTitle

        [TestMethod]
        public void WaitForNotTitle1()
        {
            var cmd = new WaitForNotTitleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotTitle2()
        {
            var cmd = new WaitForNotTitleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotTitle3()
        {
            var cmd = new WaitForNotTitleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotValue

        [TestMethod]
        public void WaitForNotValue1()
        {
            var cmd = new WaitForNotValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotValue2()
        {
            var cmd = new WaitForNotValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotValue3()
        {
            var cmd = new WaitForNotValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotVisible

        [TestMethod]
        public void WaitForNotVisible1()
        {
            var cmd = new WaitForNotVisibleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotVisible2()
        {
            var cmd = new WaitForNotVisibleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotVisible3()
        {
            var cmd = new WaitForNotVisibleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotWhetherThisFrameMatchFrameExpression

        [TestMethod]
        public void WaitForNotWhetherThisFrameMatchFrameExpression1()
        {
            var cmd = new x_WaitForNotWhetherThisFrameMatchFrameExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotWhetherThisFrameMatchFrameExpression2()
        {
            var cmd = new x_WaitForNotWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotWhetherThisFrameMatchFrameExpression3()
        {
            var cmd = new x_WaitForNotWhetherThisFrameMatchFrameExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotWhetherThisWindowMatchWindowExpression

        [TestMethod]
        public void WaitForNotWhetherThisWindowMatchWindowExpression1()
        {
            var cmd = new x_WaitForNotWhetherThisWindowMatchWindowExpressionCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotWhetherThisWindowMatchWindowExpression2()
        {
            var cmd = new x_WaitForNotWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotWhetherThisWindowMatchWindowExpression3()
        {
            var cmd = new x_WaitForNotWhetherThisWindowMatchWindowExpressionCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForNotXpathCount

        [TestMethod]
        public void WaitForNotXpathCount1()
        {
            var cmd = new x_WaitForNotXpathCountCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForNotXpathCount2()
        {
            var cmd = new x_WaitForNotXpathCountCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForNotXpathCount3()
        {
            var cmd = new x_WaitForNotXpathCountCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForOrdered

        [TestMethod]
        public void WaitForOrdered1()
        {
            var cmd = new x_WaitForOrderedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForOrdered2()
        {
            var cmd = new x_WaitForOrderedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForOrdered3()
        {
            var cmd = new x_WaitForOrderedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForPageToLoad

        [TestMethod]
        public void WaitForPageToLoad1()
        {
            var cmd = new WaitForPageToLoadCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForPageToLoad2()
        {
            var cmd = new WaitForPageToLoadCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForPageToLoad3()
        {
            var cmd = new WaitForPageToLoadCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForPopUp

        [TestMethod]
        public void WaitForPopUp1()
        {
            var cmd = new x_WaitForPopUpCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForPopUp2()
        {
            var cmd = new x_WaitForPopUpCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForPopUp3()
        {
            var cmd = new x_WaitForPopUpCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForPrompt

        [TestMethod]
        public void WaitForPrompt1()
        {
            var cmd = new WaitForPromptCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForPrompt2()
        {
            var cmd = new WaitForPromptCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForPrompt3()
        {
            var cmd = new WaitForPromptCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForPromptNotPresent

        [TestMethod]
        public void WaitForPromptNotPresent1()
        {
            var cmd = new WaitForPromptNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForPromptNotPresent2()
        {
            var cmd = new WaitForPromptNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForPromptNotPresent3()
        {
            var cmd = new WaitForPromptNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForPromptPresent

        [TestMethod]
        public void WaitForPromptPresent1()
        {
            var cmd = new WaitForPromptPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForPromptPresent2()
        {
            var cmd = new WaitForPromptPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForPromptPresent3()
        {
            var cmd = new WaitForPromptPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectOptions

        [TestMethod]
        public void WaitForSelectOptions1()
        {
            var cmd = new WaitForSelectOptionsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectOptions2()
        {
            var cmd = new WaitForSelectOptionsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectOptions3()
        {
            var cmd = new WaitForSelectOptionsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedId

        [TestMethod]
        public void WaitForSelectedId1()
        {
            var cmd = new WaitForSelectedIdCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedId2()
        {
            var cmd = new WaitForSelectedIdCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedId3()
        {
            var cmd = new WaitForSelectedIdCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedIds

        [TestMethod]
        public void WaitForSelectedIds1()
        {
            var cmd = new WaitForSelectedIdsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedIds2()
        {
            var cmd = new WaitForSelectedIdsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedIds3()
        {
            var cmd = new WaitForSelectedIdsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedIndex

        [TestMethod]
        public void WaitForSelectedIndex1()
        {
            var cmd = new WaitForSelectedIndexCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedIndex2()
        {
            var cmd = new WaitForSelectedIndexCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedIndex3()
        {
            var cmd = new WaitForSelectedIndexCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedIndexes

        [TestMethod]
        public void WaitForSelectedIndexes1()
        {
            var cmd = new WaitForSelectedIndexesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedIndexes2()
        {
            var cmd = new WaitForSelectedIndexesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedIndexes3()
        {
            var cmd = new WaitForSelectedIndexesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedLabel

        [TestMethod]
        public void WaitForSelectedLabel1()
        {
            var cmd = new WaitForSelectedLabelCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedLabel2()
        {
            var cmd = new WaitForSelectedLabelCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedLabel3()
        {
            var cmd = new WaitForSelectedLabelCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedLabels

        [TestMethod]
        public void WaitForSelectedLabels1()
        {
            var cmd = new WaitForSelectedLabelsCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedLabels2()
        {
            var cmd = new WaitForSelectedLabelsCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedLabels3()
        {
            var cmd = new WaitForSelectedLabelsCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedValue

        [TestMethod]
        public void WaitForSelectedValue1()
        {
            var cmd = new WaitForSelectedValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedValue2()
        {
            var cmd = new WaitForSelectedValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedValue3()
        {
            var cmd = new WaitForSelectedValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSelectedValues

        [TestMethod]
        public void WaitForSelectedValues1()
        {
            var cmd = new WaitForSelectedValuesCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSelectedValues2()
        {
            var cmd = new WaitForSelectedValuesCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSelectedValues3()
        {
            var cmd = new WaitForSelectedValuesCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSomethingSelected

        [TestMethod]
        public void WaitForSomethingSelected1()
        {
            var cmd = new WaitForSomethingSelectedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSomethingSelected2()
        {
            var cmd = new WaitForSomethingSelectedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSomethingSelected3()
        {
            var cmd = new WaitForSomethingSelectedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForSpeed

        [TestMethod]
        public void WaitForSpeed1()
        {
            var cmd = new x_WaitForSpeedCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForSpeed2()
        {
            var cmd = new x_WaitForSpeedCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForSpeed3()
        {
            var cmd = new x_WaitForSpeedCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForTable

        [TestMethod]
        public void WaitForTable1()
        {
            var cmd = new x_WaitForTableCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForTable2()
        {
            var cmd = new x_WaitForTableCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForTable3()
        {
            var cmd = new x_WaitForTableCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForText

        [TestMethod]
        public void WaitForText1()
        {
            var cmd = new WaitForTextCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForText2()
        {
            var cmd = new WaitForTextCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForText3()
        {
            var cmd = new WaitForTextCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForTextNotPresent

        [TestMethod]
        public void WaitForTextNotPresent1()
        {
            var cmd = new WaitForTextNotPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForTextNotPresent2()
        {
            var cmd = new WaitForTextNotPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForTextNotPresent3()
        {
            var cmd = new WaitForTextNotPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForTextPresent

        [TestMethod]
        public void WaitForTextPresent1()
        {
            var cmd = new WaitForTextPresentCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForTextPresent2()
        {
            var cmd = new WaitForTextPresentCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForTextPresent3()
        {
            var cmd = new WaitForTextPresentCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForTitle

        [TestMethod]
        public void WaitForTitle1()
        {
            var cmd = new WaitForTitleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForTitle2()
        {
            var cmd = new WaitForTitleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForTitle3()
        {
            var cmd = new WaitForTitleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForValue

        [TestMethod]
        public void WaitForValue1()
        {
            var cmd = new WaitForValueCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForValue2()
        {
            var cmd = new WaitForValueCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForValue3()
        {
            var cmd = new WaitForValueCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForVisible

        [TestMethod]
        public void WaitForVisible1()
        {
            var cmd = new WaitForVisibleCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaitForVisible2()
        {
            var cmd = new WaitForVisibleCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WaitForVisible3()
        {
            var cmd = new WaitForVisibleCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WaitForWhetherThisFrameMatchFrameExpression

        //[TestMethod]
        //public void WaitForWhetherThisFrameMatchFrameExpression1()
        //{
        //    var cmd = new x_WaitForWhetherThisFrameMatchFrameExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForWhetherThisFrameMatchFrameExpression2()
        //{
        //    var cmd = new x_WaitForWhetherThisFrameMatchFrameExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForWhetherThisFrameMatchFrameExpression3()
        //{
        //    var cmd = new x_WaitForWhetherThisFrameMatchFrameExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region WaitForWhetherThisWindowMatchWindowExpression

        //[TestMethod]
        //public void WaitForWhetherThisWindowMatchWindowExpression1()
        //{
        //    var cmd = new x_WaitForWhetherThisWindowMatchWindowExpressionCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForWhetherThisWindowMatchWindowExpression2()
        //{
        //    var cmd = new x_WaitForWhetherThisWindowMatchWindowExpressionCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForWhetherThisWindowMatchWindowExpression3()
        //{
        //    var cmd = new x_WaitForWhetherThisWindowMatchWindowExpressionCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region WaitForXpathCount

        //[TestMethod]
        //public void WaitForXpathCount1()
        //{
        //    var cmd = new x_WaitForXpathCountCommand();
        //    var flag = cmd.Syntax;
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void WaitForXpathCount2()
        //{
        //    var cmd = new x_WaitForXpathCountCommand();
        //    cmd.Execute(null);
        //}

        //[TestMethod]
        //public void WaitForXpathCount3()
        //{
        //    var cmd = new x_WaitForXpathCountCommand();
        //    cmd.Execute(context);
        //}

        #endregion

        #region WindowFocus

        [TestMethod]
        public void WindowFocus1()
        {
            var cmd = new WindowFocusCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WindowFocus2()
        {
            var cmd = new WindowFocusCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WindowFocus3()
        {
            var cmd = new WindowFocusCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WindowFocusAndWait

        [TestMethod]
        public void WindowFocusAndWait1()
        {
            var cmd = new WindowFocusAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WindowFocusAndWait2()
        {
            var cmd = new WindowFocusAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WindowFocusAndWait3()
        {
            var cmd = new WindowFocusAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WindowMaximize

        [TestMethod]
        public void WindowMaximize1()
        {
            var cmd = new WindowMaximizeCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WindowMaximize2()
        {
            var cmd = new WindowMaximizeCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WindowMaximize3()
        {
            var cmd = new WindowMaximizeCommand();
            cmd.Execute(context);
        }

        #endregion

        #region WindowMaximizeAndWait

        [TestMethod]
        public void WindowMaximizeAndWait1()
        {
            var cmd = new WindowMaximizeAndWaitCommand();
            var flag = cmd.Syntax;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WindowMaximizeAndWait2()
        {
            var cmd = new WindowMaximizeAndWaitCommand();
            cmd.Execute(null);
        }

        [TestMethod]
        public void WindowMaximizeAndWait3()
        {
            var cmd = new WindowMaximizeAndWaitCommand();
            cmd.Execute(context);
        }

        #endregion
        

        #endregion
    }
}
