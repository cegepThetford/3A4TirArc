using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TirArc_Affaires;

namespace TirArc_Tests
{
    /// <summary>
    /// Description résumée pour CibleTests
    /// </summary>
    [TestClass]
    public class CibleTests
    {
        private Cible _cible;
        private Tir _tirCoeur1, _tirCoeur2;
        private Tir _tirInterieur1, _tirInterieur2, _tirInterieur3;
        private Tir _tirExterieur1, _tirExterieur2;
        private Tir _tirManque1, _tirManque2;

        [TestInitialize]
        public void initialisation()
        {
            _cible = new Cible();
            _tirCoeur1 = new Tir(new Position()); // 0.0
            _tirCoeur2 = new Tir(new Position(6, 6)); // 8.4853
            _tirInterieur1 = new Tir(new Position(-12, 1)); // 12.0416
            _tirInterieur2 = new Tir(new Position(15, 0)); // 15.0
            _tirInterieur3 = new Tir(new Position(20, -14)); // 24.4131
            _tirExterieur1 = new Tir(new Position(20, 16)); // 25.6125
            _tirExterieur2 = new Tir(new Position(28, 28)); // 39.598
            _tirManque1 = new Tir(new Position(29, 29)); // 41.0122
            _tirManque2 = new Tir(new Position(80, 0)); // 80
        }
        
        [TestMethod]
        public void CibleCreationTests()
        {
            Assert.AreEqual(0, _cible.NbCoeur);
            Assert.AreEqual(0, _cible.NbInterieur);
            Assert.AreEqual(0, _cible.NbExterieur);
            Assert.AreEqual(0, _cible.NbManque);
        }

        [TestMethod]
        public void TirsTests()
        {
            _cible.inscrireTir(_tirManque1);
            Assert.AreEqual(0, _cible.NbCoeur);
            Assert.AreEqual(0, _cible.NbInterieur);
            Assert.AreEqual(0, _cible.NbExterieur);
            Assert.AreEqual(1, _cible.NbManque);
            Assert.AreEqual(1, _cible.denombrerTirs());
            Assert.AreEqual(0, _cible.calculerPointage());

            _cible.inscrireTir(_tirInterieur1);
            _cible.inscrireTir(_tirInterieur2);
            Assert.AreEqual(0, _cible.NbCoeur);
            Assert.AreEqual(2, _cible.NbInterieur);
            Assert.AreEqual(0, _cible.NbExterieur);
            Assert.AreEqual(1, _cible.NbManque);
            Assert.AreEqual(3, _cible.denombrerTirs());
            Assert.AreEqual(4, _cible.calculerPointage());

            _cible.inscrireTir(_tirCoeur1);
            Assert.AreEqual(1, _cible.NbCoeur);
            Assert.AreEqual(2, _cible.NbInterieur);
            Assert.AreEqual(0, _cible.NbExterieur);
            Assert.AreEqual(1, _cible.NbManque);
            Assert.AreEqual(4, _cible.denombrerTirs());
            Assert.AreEqual(9, _cible.calculerPointage());

            _cible.inscrireTir(_tirCoeur2);
            Assert.AreEqual(2, _cible.NbCoeur);
            Assert.AreEqual(2, _cible.NbInterieur);
            Assert.AreEqual(0, _cible.NbExterieur);
            Assert.AreEqual(1, _cible.NbManque);
            Assert.AreEqual(5, _cible.denombrerTirs());
            Assert.AreEqual(14, _cible.calculerPointage());

            _cible.inscrireTir(_tirInterieur3);
            _cible.inscrireTir(_tirExterieur1);
            _cible.inscrireTir(_tirExterieur2);
            _cible.inscrireTir(_tirManque2);

            Assert.AreEqual(2, _cible.NbCoeur);
            Assert.AreEqual(3, _cible.NbInterieur);
            Assert.AreEqual(2, _cible.NbExterieur);
            Assert.AreEqual(2, _cible.NbManque);
            Assert.AreEqual(9, _cible.denombrerTirs());
            Assert.AreEqual(18, _cible.calculerPointage());
        }
    }
}
