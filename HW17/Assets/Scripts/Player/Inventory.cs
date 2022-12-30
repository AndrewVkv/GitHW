using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private class Stuff
    {
        private int hearts;
        private int bullets;
        private int coins;

        public int ReturnHP() => hearts;
        public int ReturnBullets() => bullets;
        public int ReturnCoins() => coins;
        public void PlusCoin()
        {
            coins++;
        }
        public void LooseHP()
        {
            hearts--;
        }
        public void MinusBullet()
        {
            if (bullets > 0)
                bullets--;
            else
                print("No bullets");
        }
        public void DeathDamage()
        {
            hearts = 0;
            print("Death");
        }
        // constructor
        public Stuff(int hearts, int bullets, int coins)
        {
            this.hearts = hearts;
            this.bullets = bullets;
            this.coins = coins;
        }
    }
    private Stuff playerStuff = new Stuff(3, 12, 0);
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        EventBus.eCoinCollision.AddListener(AddCoin);
        EventBus.eObstacleCollision.AddListener(playerStuff.DeathDamage);
        EventBus.eFalling.AddListener(playerStuff.DeathDamage);
    }
    public int GetCoins() => playerStuff.ReturnCoins();
    public int GetBullets() => playerStuff.ReturnBullets();
    public int GetHP() => playerStuff.ReturnHP();
    public void AddCoin() => playerStuff.PlusCoin();
    public void SubtractBullet() => playerStuff.MinusBullet();

}
