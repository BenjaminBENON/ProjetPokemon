using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace TestsUnitaires
{
    [TestClass]
    public class UnitTest1
    {

        List<string> listTest = new List<string> { "test1", "test2", "test3" };

        [TestMethod]
        [TestCase (20,30,listTest,3,20,40)]


        public void TestMethod1(int posX, int posY, List<string> myList, int size, int posXExpected, int posYExpected)
        {

            Assert.That(posX, Is.EqualTo(posXExpected);
        }
    }
}
