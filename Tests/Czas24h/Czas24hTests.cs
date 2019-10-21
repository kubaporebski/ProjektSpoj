using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSpoj.Tests
{
    [TestClass]
    public class Czas24hTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsNotNull(Instance(0, 0, 0));
            Assert.ThrowsException<ArgumentException>(CreateInstance(-1, 0, 0));
            Assert.ThrowsException<ArgumentException>(CreateInstance(0, -1, 0));
            Assert.ThrowsException<ArgumentException>(CreateInstance(0, 0, -1));
            Assert.ThrowsException<ArgumentException>(CreateInstance(0, 99, 0));
            Assert.ThrowsException<ArgumentException>(CreateInstance(99, 0, 0));
            Assert.ThrowsException<ArgumentException>(CreateInstance(0, 0, 99));
        }


        [TestMethod]
        public void SetGodzinaTest()
        {
            var czas = Instance(0, 49, 32);
            Assert.AreEqual(0, czas.Godzina);
            Assert.AreEqual(49, czas.Minuta);
            Assert.AreEqual(32, czas.Sekunda);

            czas.Godzina = 23;
            Assert.AreEqual(23, czas.Godzina);
            Assert.AreEqual(49, czas.Minuta);
            Assert.AreEqual(32, czas.Sekunda);

            Assert.ThrowsException<ArgumentException>(() => czas.Godzina = 25);
        }

        [TestMethod]
        public void SetMinutaTest()
        {
            var czas = Instance(17, 0, 56);
            Assert.AreEqual(17, czas.Godzina);
            Assert.AreEqual(0, czas.Minuta);
            Assert.AreEqual(56, czas.Sekunda);
            
            czas.Minuta = 45;
            Assert.AreEqual(17, czas.Godzina);
            Assert.AreEqual(45, czas.Minuta);
            Assert.AreEqual(56, czas.Sekunda);

            Assert.ThrowsException<ArgumentException>(() => czas.Minuta = 61);
        }

        [TestMethod]
        public void SetSekundaTest()
        {
            var czas = Instance(16, 21, 0);
            Assert.AreEqual(16, czas.Godzina);
            Assert.AreEqual(21, czas.Minuta);
            Assert.AreEqual(0, czas.Sekunda);

            czas.Sekunda = 33;
            Assert.AreEqual(16, czas.Godzina);
            Assert.AreEqual(21, czas.Minuta);
            Assert.AreEqual(33, czas.Sekunda);

            Assert.ThrowsException<ArgumentException>(() => czas.Sekunda = 61);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("0:00:00", Instance(0, 0, 0).ToString());
            Assert.AreEqual("0:00:01", Instance(0, 0, 1).ToString());
            Assert.AreEqual("0:01:00", Instance(0, 1, 0).ToString());
            Assert.AreEqual("1:00:00", Instance(1, 0, 0).ToString());
            Assert.AreEqual("23:00:00", Instance(23, 0, 0).ToString());
        }

        private static Czas24h Instance(int h, int m, int s)
        {
            return new Czas24h(h, m, s);
        }

        private static Action CreateInstance(int h, int m, int s)
        {
            return () => Instance(h, m, s);
        }
    }
}