using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EditModeTestScript
    {
        private TestClass testClass;
        private int setCoins = 1;
        private int setBills = 2;
        private int setBtc = 3;

        [SetUp]
        public void SetUp()
        {
            testClass = new TestClass();
        } 

        [Test]
        public void EditUnitTestCheckCoins()
        {
            int coins = testClass.myWallet.coins;
            Assert.AreEqual(coins, setCoins);
        }
        [Test]
        public void EditUnitTestCheckBills()
        {
            int bills = testClass.myWallet.bills;
            Assert.AreEqual(bills, setBills);
        }
        [Test]
        public void EditUnitTestCheckBTC()
        {
            int btc = testClass.myWallet.btc;
            Assert.AreEqual(btc, setBtc);
        }
        [TearDown]
        public void EndNull() 
        {
            testClass = null;
        }
    }
}
