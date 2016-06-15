using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test.logic;

namespace test.unitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testService = new TestService();
            Assert.IsTrue(false);
        }
    }
}
