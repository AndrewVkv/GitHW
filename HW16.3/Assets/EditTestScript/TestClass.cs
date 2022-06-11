using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass 
{
    // Unit Test Edit Mode only needed
    public class Wallet 
    {
        public int coins;
        public int bills;
        public int btc;

        // constructor
        public Wallet(int coins, int bills, int btc) 
        {
            this.coins = coins;
            this.bills = bills; 
            this.btc = btc;
        }

    }
    public Wallet myWallet = new Wallet(1,2,3);
}
