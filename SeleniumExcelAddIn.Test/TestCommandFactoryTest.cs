using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExcelAddIn;

namespace SeleniumExcelAddIn.v2010.Test
{
    [TestClass()]
    public class TestCommandFactoryTest
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
        public void NamespcaeTest()
        {
            var asm = Assembly.GetAssembly(typeof(TestCommandFactory));

            Type[] types = asm.GetTypes();
            List<Type> list = new List<Type>();

            foreach (var type in types)
            {
                if (!type.IsClass)
                {
                    continue;
                }

                if (type.Name.EndsWith("Command"))
                {
                    Assert.AreEqual("SeleniumExcelAddIn.TestCommands", type.Namespace, type.Name);
                }

                if (type.Namespace == "SeleniumExcelAddIn.TestCommands" && -1 == type.Name.IndexOf("_"))
                {
                    list.Add(type);
                }
            }

            var a = list.Select(i => i.Name).ToList();
            a.Sort();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateCommandErrorTest()
        {
            var command = TestCommandFactory.CreateCommand("xxx");
            Assert.IsTrue(command.Syntax.HasFlag(TestCommandSyntax.Target));
            Assert.IsFalse(command.Syntax.HasFlag(TestCommandSyntax.Value));
        }
    }
}
