using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestUnitaireNUnit
{
    public class Tests
    {


        List<string> listTest = new List<string> { "test1", "test2", "test3" };

        [Test]
        [TestCase(20, 30, listTest, 3, 20, 40)]


        public void TestMenuCreator1(int posX, int posY, List<string> myList, int size, int posXExpected, int posYExpected)
        {

            Assert.That(posX, Is.EqualTo(posXExpected));
        }

    }
}