using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    using ConsoleApp1;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int num1 = 100;
            int num2 = 200;

            Assert.AreEqual(Program.Add(num1, num2), 300);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string a = "abc";
            string b = "def";
            Assert.AreEqual(Program.GetValue(a, b), "abcdef");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsTrue(Program.IsBool());
        }
    }
}
