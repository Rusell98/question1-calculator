using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp3;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 测试addComments函数是否有效
        /// </summary>
        [TestMethod]
        public void AddCommentsTest()
        {
            Form1 calculator1 = new Form1();
            calculator1.addComments("1+2*(2+0.5)");
            Assert.AreEqual(calculator1.text, "1+2*(2+0.5)");
        }
        /// <summary>
        /// 在Form1.cs中重新编写一个便于测试的BottonEqual函数，便于测试；若测试通过，则等于按钮功能也无误
        /// </summary>
        [TestMethod]
        public void BottonEqualTest()
        {
            Form1 calculator2 = new Form1();
            Assert.AreEqual(calculator2.BottonEqual("5-2/(1-0.5)"), "1");
        }
    }
}
