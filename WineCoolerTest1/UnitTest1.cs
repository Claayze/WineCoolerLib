using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WineCoolerLib;

namespace WineCoolerTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CoolerIsFull()
        {
            Cooler cooler = new Cooler(1, 100, 4, 100);
            Assert.AreEqual(true, cooler.CoolerIsFull());
        }
        [TestMethod]
        public void CoolerIsAlmostFull()
        {
            Cooler cooler = new Cooler(7, 100, 4, 99);
            Assert.AreEqual(false, cooler.CoolerIsFull());
        }
        [TestMethod]
        public void CapacityOutOfRange()
        {
            Cooler cooler = new Cooler(6, 100, 4, 101);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cooler.CoolerIsFull());
        }

        [TestMethod]
        public void AddWineTest()
        {
            Cooler cooler = new Cooler(2, 100, 5, 3);
            cooler.AddWine();
            Assert.AreEqual(4, cooler.BottlesInStorage);
            
        }
        [TestMethod]
        public void AddWineMaxCapTest()
        {
            Cooler cooler = new Cooler(3, 100, 5, 99);
            cooler.AddWine();
            Assert.AreEqual(100, cooler.BottlesInStorage);


        }
        [TestMethod]
        public void AddWineTooManyTest()
        {
            Cooler cooler = new Cooler(2, 100, 5, 100);
            cooler.AddWine();
            Assert.AreEqual(100, cooler.BottlesInStorage);

        }

    }
}
