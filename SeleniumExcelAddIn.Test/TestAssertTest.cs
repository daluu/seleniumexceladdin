using SeleniumExcelAddIn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SeleniumExcelAddIn.v2010.Test
{
    [TestClass()]
    public class TestAssertTest
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

        [TestMethod()]
        public void IsTrueTest()
        {
            TestCommandHelper.AssertIsTrue(true);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void IsTrueTest2()
        {
            TestCommandHelper.AssertIsTrue(false);
        }

        [TestMethod()]
        public void IsNullTest()
        {
            object obj = null;
            TestCommandHelper.AssertIsNull(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void IsNullTest2()
        {
            object obj = new object();
            TestCommandHelper.AssertIsNull(obj);
        }

        [TestMethod()]
        public void IsNotNullWithMessageTest()
        {
            object obj = new object();
            string message = "ok";
            TestCommandHelper.AssertIsNotNull(obj, message);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void IsNotNullWithMessageTest2()
        {
            object obj = null;
            string message = "ok";
            TestCommandHelper.AssertIsNotNull(obj, message);
        }

        [TestMethod()]
        public void IsNotNullTest()
        {
            object obj = new object();
            TestCommandHelper.AssertIsNotNull(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void IsNotNullTest2()
        {
            object obj = null;
            TestCommandHelper.AssertIsNotNull(obj);
        }

        [TestMethod()]
        public void IsFalseTest()
        {
            TestCommandHelper.AssertIsFalse(false);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void IsFalseTest2()
        {
            TestCommandHelper.AssertIsFalse(true);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void FailTest()
        {
            TestCommandHelper.AssertFail();
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void FailTest1()
        {
            TestCommandHelper.AssertFail("ok");
        }

        [TestMethod()]
        public void ArePresentTest()
        {
            string expected = "Foo";
            string actual = "Bar Foo Bar";
            TestCommandHelper.AssertAreContains(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void ArePresentTest2()
        {
            string expected = "Foo";
            string actual = "xxx";
            TestCommandHelper.AssertAreContains(expected, actual);
        }

        [TestMethod()]
        public void AreNotPresentTest()
        {
            string expected = "Foo";
            string actual = "Bar";

            TestCommandHelper.AssertAreNotContains(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void AreNotPresentTest2()
        {
            string expected = "Foo";
            string actual = "Foo Bar";

            TestCommandHelper.AssertAreNotContains(expected, actual);
        }

        [TestMethod()]
        public void AreNotEqualTest()
        {
            string expected = "Foo";
            string actual = "Bar";
            TestCommandHelper.AssertAreNotEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void AreNotEqualTest2()
        {
            string expected = "Foo";
            string actual = "Foo";
            TestCommandHelper.AssertAreNotEqual(expected, actual);
        }

        [TestMethod()]
        public void AreEqualTest()
        {
            string expected = "Foo";
            string actual = "Foo";
            TestCommandHelper.AssertAreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(TestAssertFailedException))]
        public void AreEqualTest2()
        {
            string expected = "Foo";
            string actual = "Bar";
            TestCommandHelper.AssertAreEqual(expected, actual);
        }
    }
}
