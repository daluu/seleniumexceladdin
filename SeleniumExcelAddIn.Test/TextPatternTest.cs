using SeleniumExcelAddIn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SeleniumExcelAddIn.v2010.Test
{
    /// <summary>
    ///TextMatchTest のテスト クラスです。すべての
    ///TextMatchTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class TextPatternTest
    {
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
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

        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod]
        public void IsMatchTest1()
        {
            string expected = "foo";
            string actual = "foo";
            Assert.IsTrue(TextPattern.IsMatch(expected, actual));
        }

        [TestMethod]
        public void IsMatchTest2()
        {
            string expected = "foo";
            string actual = "bar";
            Assert.IsFalse(TextPattern.IsMatch(expected, actual));
        }
        
        [TestMethod]
        public void IsMatchTest3()
        {
            string expected = "regexp:foo";
            string actual = "foo";
            Assert.IsTrue(TextPattern.IsMatch(expected, actual));
        }

        [TestMethod]
        public void IsMatchTest4()
        {
            string expected = "regexp:foo";
            string actual = "bar";
            Assert.IsFalse(TextPattern.IsMatch(expected, actual));
        }

        [TestMethod]
        public void IsMatchTest5()
        {
            string expected = @"regexp:\d+";
            string actual = "123";
            Assert.IsTrue(TextPattern.IsMatch(expected, actual));
        }

        [TestMethod]
        public void IsMatchTest6()
        {
            string expected = @"regexp:\d+";
            string actual = "foo123bar";
            Assert.IsTrue(TextPattern.IsMatch(expected, actual));
        }

        [TestMethod]
        public void IsContainTest1()
        {
            string expected = @"123";
            string actual = "foo123bar";
            Assert.IsTrue(TextPattern.IsContains(expected, actual));
        }

        [TestMethod]
        public void IsContainTest2()
        {
            string expected = @"789";
            string actual = "foo123bar";
            Assert.IsFalse(TextPattern.IsContains(expected, actual));
        }
        
        [TestMethod]
        public void IsContainTest3()
        {
            string expected = @"regexp:\d+";
            string actual = "foo123bar";
            Assert.IsTrue(TextPattern.IsContains(expected, actual));
        }

        [TestMethod]
        public void IsContainTest4()
        {
            string expected = @"regexp:\d+";
            string actual = "foobar";
            Assert.IsFalse(TextPattern.IsContains(expected, actual));
        }

        [TestMethod]
        public void RegExpi1()
        {
            string expected = @"regexpi:FOO";
            string actual = "xxxfooyyy";
            Assert.IsTrue(TextPattern.IsMatch(expected, actual));
        }

        [TestMethod]
        public void RegExpi2()
        {
            string expected = @"regexpi:foo";
            string actual = "xxxFOOyyy";
            Assert.IsTrue(TextPattern.IsMatch(expected, actual));
        }
    }
}
