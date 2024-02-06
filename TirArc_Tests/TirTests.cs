using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TirArc_Affaires;

namespace TirArc_Tests
{
    [TestClass]
    public class TirTests
    {
        private Tir _tirCoeur1, _tirCoeur2;
        private Tir _tirInterieur1, _tirInterieur2, _tirInterieur3;
        private Tir _tirExterieur1, _tirExterieur2;
        private Tir _tirManque1, _tirManque2;

        [TestInitialize]
        public void initialisation()
        {
            _tirCoeur1 = new Tir(new Position()); // 0.0
            _tirCoeur2 = new Tir(new Position(6, 6)); // 8.4853
            _tirInterieur1 = new Tir(new Position(-12, 1)); // 12.0416
            _tirInterieur2 = new Tir(new Position(15, 0)); // 15.0
            _tirInterieur3 = new Tir(new Position(20, -14)); // 24.4131
            _tirExterieur1 = new Tir(new Position(20, 16)); // 25.6125
            _tirExterieur2 = new Tir(new Position(28, 28)); // 39.598
            _tirManque1 = new Tir(new Position(29, 29)); // 41.0122
            _tirManque2 = new Tir(new Position(80,0)); // 80
        }
        [TestMethod]
        public void CreationTirTests()
        {
            Assert.IsNotNull(_tirCoeur1.Position);
            Assert.AreEqual(0, _tirCoeur1.Position.X);
            Assert.AreEqual(0, _tirCoeur1.Position.Y);
            Assert.IsNotNull(_tirInterieur3.Position);
            Assert.AreEqual(20, _tirInterieur3.Position.X);
            Assert.AreEqual(-14, _tirInterieur3.Position.Y);
        }
        [TestMethod]
        public void CalculsDistanceCentre()
        {
            Assert.AreEqual(0.0, _tirCoeur1.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(8.48, _tirCoeur2.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(12.04, _tirInterieur1.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(15.0, _tirInterieur2.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(24.41, _tirInterieur3.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(25.61, _tirExterieur1.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(39.59, _tirExterieur2.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(41.01, _tirManque1.calculerDistanceCentre(), 0.01);
            Assert.AreEqual(80.0, _tirManque2.calculerDistanceCentre(), 0.01);
        }
        [TestMethod]
        public void ZoneTirTests()
        {
            Assert.IsTrue(_tirCoeur1.aToucheCoeur());
            Assert.IsFalse(_tirCoeur1.aToucheInterieur());
            Assert.IsFalse(_tirCoeur1.aToucheExterieur());
            Assert.IsFalse(_tirCoeur1.aManque());

            Assert.IsFalse(_tirInterieur3.aToucheCoeur());
            Assert.IsTrue(_tirInterieur3.aToucheInterieur());
            Assert.IsFalse(_tirInterieur3.aToucheExterieur());
            Assert.IsFalse(_tirInterieur3.aManque());

            Assert.IsFalse(_tirExterieur2.aToucheCoeur());
            Assert.IsFalse(_tirExterieur2.aToucheInterieur());
            Assert.IsTrue(_tirExterieur2.aToucheExterieur());
            Assert.IsFalse(_tirExterieur2.aManque());

            Assert.IsFalse(_tirManque1.aToucheCoeur());
            Assert.IsFalse(_tirManque1.aToucheInterieur());
            Assert.IsFalse(_tirManque1.aToucheExterieur());
            Assert.IsTrue(_tirManque1.aManque());
        }
    }
}
