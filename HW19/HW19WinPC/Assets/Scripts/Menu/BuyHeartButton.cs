using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHeartButton : MonoBehaviour
{
    protected class HeatButton 
    {
        private int hearts;
        private int price;

        public int Hearts 
        {
            get { return hearts; }
            set { hearts = value; }
        }
        public int Price 
        {
            get { return price; }
            set { price = value; }
        }

        public HeatButton(int hearts, int price) 
        {
            this.hearts = hearts;
            this.price = price;
        }
    }
    protected  HeatButton heatButton;

}
