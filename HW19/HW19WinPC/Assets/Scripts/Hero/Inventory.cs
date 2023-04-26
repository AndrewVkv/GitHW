using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IObservable
{
    private class Stuff
    {
        private int hearts;
        private int coins;

        public int Coins
        {
            get { return coins; }
            set { coins = value; }
        }
        public int Hearts
        {
            get { return hearts; }
            set { hearts = value; }
        }

        public Stuff(int hearts, int coins) 
        {
            this.hearts = hearts;
            this.coins = coins;
        }
    }

    //private const int startHearts = 3;
    //private const int maxHearts = 5;
    [SerializeField] private HeroUI heroUI;

    private Stuff heroStuff;

    private List<IObserver> reseiveDamageObservers = new List<IObserver>();


    private void Awake() 
    {
        if (!PlayerPrefs.HasKey(Const.HEARTS))
            heroStuff = new Stuff(Const.STARTHEARTSVALUE, 0);
        else 
        {
            int heartValue = PlayerPrefs.GetInt(Const.HEARTS);
            int coinsValue = PlayerPrefs.GetInt(Const.COINS);
            heroStuff = new Stuff(heartValue, coinsValue);
        }

        heroUI = FindObjectOfType<HeroUI>();
    }

    private void Start() => UpdateInventory();

    private void UpdateHeartsUI() => heroUI.UpdateHealth(heroStuff.Hearts);

    private void UpdateCoinsUI() => heroUI.UpdateCoins(heroStuff.Coins);

    private void UpdateInventory() 
    {
        UpdateHeartsUI();
        UpdateCoinsUI();
    }
    private void CheckAlive()
    {
        if (heroStuff.Hearts <= 0)
            GlobalEventManager.RiseEvDeadHero();
    }

    public void ReceiveDamage(int value)
    {
        heroStuff.Hearts -= value;
        UpdateHeartsUI();
        CheckAlive();

        NotifyObservers();
    }

    public void ReceiveCoin(int value)
    {
        heroStuff.Coins += value;
        UpdateCoinsUI();
    }

    public void ReceiveHeart(int value)
    {
        if(heroStuff.Hearts < Const.MAXHEARTSVALUE)
            heroStuff.Hearts += value;

        UpdateHeartsUI();
    }

    public void AddObserver(IObserver observer) => reseiveDamageObservers.Add(observer);

    public void RemoveObserver(IObserver observer) => reseiveDamageObservers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in reseiveDamageObservers)
            observer.OnNotify();
    }

    public int GetCoisnValue() => heroStuff.Coins;
    public int GetHeartsValue() => heroStuff.Hearts;
}
