using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private DisplayInventory displayInventory;
    public class Stuff 
    {
        public int health;
        public int bullets;
        public int coins;

        // constructor
        public Stuff(int health, int bullets, int coins) 
        {
            this.health = health;
            this.bullets = bullets;
            this.coins = coins;
        }
    }

    public Stuff playerStuff = new Stuff(3, 5, 0);

    private void Start()
    {
        // create singletone object & get reference
        Instance = this;
        displayInventory = GetComponent<DisplayInventory>();

    }
    public void CollisionSpikeObstacle() 
    {
        if(playerStuff.health > 0)
            playerStuff.health--;
        if (playerStuff.health <= 0)
            PLayerCollision.Instance.DeathRoutine();
        
        displayInventory.UpdateHP();
        Debug.Log(playerStuff.health);
    }

    public int GetCoins() 
    {
        return playerStuff.coins;
    }
    public int GetBullets() 
    {
        return playerStuff.bullets;
    }
    public int GetHP() 
    {
        return playerStuff.health;
    }
    public void PlusCoin() 
    {
        playerStuff.coins++;
    }
    public void MinusBullet() 
    {
        playerStuff.bullets--;
    }
    public void CollideAmmunition() 
    {
        playerStuff.bullets = 5;
        displayInventory.UpdateBullets();
    }

}
