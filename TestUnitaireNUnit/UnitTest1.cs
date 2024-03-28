using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestUnitaireNUnit
{
    public class Tests
    {

        [Test]
        [TestCase(1, 2)]
        [TestCase(10, 11)]
        [TestCase(41, 42)]
        [TestCase(123, 124)]

        public void TestIncrementLevel(int lvl, int nextlvl)
        {
            Level oLevel = new Level();
            oLevel.CurrentLevel = lvl;

            oLevel.IncrementLevel();

            Assert.That(oLevel.CurrentLevel, Is.EqualTo(nextlvl));

        }

        [Test]
        [TestCase(-1)]
        [TestCase(-20)]
        public void BreakIncrementLevel(int lvl)
        {
            Level oLevel = new Level();
            oLevel.CurrentLevel = lvl;
            Assert.Throws<Exception>(() =>
            {
                oLevel.IncrementLevel();
            });
        }


        [Test]
        [TestCase(20, 10, 100, 15)]
        [TestCase(40, 10, 80, 15)]
        [TestCase(5, 15, 115, 20)]

        public void TestMenuCreatorPositions(int posX, int posY, int posXExpected, int posYExpected)
        {
            // Méthode utilisée dans le Menu Creator pour trouver la position des cases
            List<string> listTest = new List<string> { "test1", "test2", "test3" };
            int windowWidth = 120;
            int nbCase = listTest.Count;
            int nb3 = nbCase / 3 + (nbCase % 3);
            int Size = windowWidth - posX * 2;


            int POSx = posX + (1 + 1) * (Size / (nb3 + 1));
            int POSy = posY + 5;

            Assert.That(POSx, Is.EqualTo(posXExpected));
            Assert.That(POSy, Is.EqualTo(posYExpected));
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(-1)]
        [TestCase(6)]

        public void BreakMenuCreator(int size)
        {
            List<string> listTest = new List<string> { "test1", "test2", "test3" };

            Assert.Throws<Exception>(() =>
            {
                MenuCreator.CreateMenu(20, 20, "test", size, listTest);
            });
        }
        

        [Test]
        [TestCase(10)]
        [TestCase(100)]
        public void TestAttackPokemon(int pV)
        {
            float[] resPlant = { 1, 2, 0.5f, 1, 0.8f };
            Pokemon bulbizarre = new Pokemon("Bulbizarre", PokemonType.Plant, pV, 49, 49, 65, 100, 0, resPlant);

            float[] resFire = { 1, 2, 0.5f, 1, 0.8f };
            Pokemon salameche = new Pokemon("Salamèche", PokemonType.Fire, 45, 49, 49, 65, 100, 0, resFire);

            PhysicalAttack testAttack = new PhysicalAttack("test", 30);

            testAttack.Use(salameche, bulbizarre);

            Assert.That(pV, Is.AtLeast(bulbizarre.CurrentLifePoints));
        }
    }
}