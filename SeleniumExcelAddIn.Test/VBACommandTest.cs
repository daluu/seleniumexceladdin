using SeleniumExcelAddIn.TestCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumExcelAddIn.v2010.Test
{


    /// <summary>
    ///VBACommandTest のテスト クラスです。すべての
    ///VBACommandTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class VBACommandTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext
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


        [TestMethod()]
        public void GetMacroTest1()
        {
            string s = "foo";
            string expected = "foo";
            string actual = VbaCommand.GetMacro(s);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMacroTest2()
        {
            string s = "foo";
            string expected = "foo";
            string actual = VbaCommand.GetMacro(s);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMacroTest3()
        {
            string s = "foo=";
            string expected = "foo";
            string actual = VbaCommand.GetMacro(s);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMacroTest4()
        {
            string s = "foo=a";
            string expected = "foo";
            string actual = VbaCommand.GetMacro(s);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMacroTest5()
        {
            string s = "foo=a,b";
            string expected = "foo";
            string actual = VbaCommand.GetMacro(s);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetArgsTest1()
        {
            string s = "foo";
            string[] expected = { };
            IEnumerable<string> actual = VbaCommand.GetArgs(s);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestMethod()]
        public void GetArgsTest2()
        {
            string s = "foo=";
            string[] expected = { };
            IEnumerable<string> actual = VbaCommand.GetArgs(s);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestMethod()]
        public void GetArgsTest3()
        {
            string s = "foo=a";
            string[] expected = { "a" };
            IEnumerable<string> actual = VbaCommand.GetArgs(s);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestMethod()]
        public void GetArgsTest4()
        {
            string s = "foo=a,b";
            string[] expected = { "a", "b" };
            IEnumerable<string> actual = VbaCommand.GetArgs(s);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }
    }
}
