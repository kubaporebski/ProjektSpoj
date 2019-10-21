using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektSpoj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSpoj.Tests
{
    [TestClass]
    public class FreqTextTests
    {
        [TestMethod]
        public void FreqTextTest()
        {
            Assert.IsNotNull(Instance("qwerty"));
        }

        [TestMethod]
        public void FrequencyTest()
        {
            var ft1 = Instance("qwerty");
            Assert.IsNotNull(ft1.Frequency);
            Assert.IsTrue(ft1.Frequency.Count > 0);
            Assert.AreEqual(1, ft1.Frequency['q']);
            Assert.AreEqual(1, ft1.Frequency['w']);
            Assert.AreEqual(1, ft1.Frequency['e']);
            Assert.AreEqual(1, ft1.Frequency['r']);
            Assert.AreEqual(1, ft1.Frequency['t']);
            Assert.AreEqual(1, ft1.Frequency['y']);
            Assert.IsFalse(ft1.Frequency.ContainsKey('z'));

            var ft2 = Instance("alamakotka");
            Assert.IsNotNull(ft2.Frequency);
            Assert.IsTrue(ft2.Frequency.Count > 0);
            Assert.AreEqual(4, ft2.Frequency['a']);
            Assert.AreEqual(1, ft2.Frequency['l']);
            Assert.AreEqual(1, ft2.Frequency['m']);
            Assert.AreEqual(2, ft2.Frequency['k']);
            Assert.AreEqual(1, ft2.Frequency['t']);
            Assert.AreEqual(1, ft2.Frequency['o']);
            Assert.IsFalse(ft2.Frequency.ContainsKey('w'));
        }

        [TestMethod]
        public void PrintingTest()
        {
            var ft3 = Instance("kobyła ma mały bok tak");
            Console.WriteLine(ft3.PrintAlphabetically);
            Console.WriteLine();
            Console.WriteLine(ft3.PrintSorted);
            Console.WriteLine();
        }

        private static FreqText Instance(string text)
        {
            return new FreqText(text);
        }

    }
}