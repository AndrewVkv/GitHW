using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeTest : MonoBehaviour 
{
    private float playModeDelay = 0.1f;
    private int setCoins = 0;
    private int setBullets = 5;
    private int setHealth = 3;

    private GameObject playerInventory;

    [SetUp]
    public void Setup() 
    {
        playerInventory = Instantiate(new GameObject());
        playerInventory.AddComponent<Inventory>();
    }

    [UnityTest]
    public IEnumerator InventoryNotNull()
    {
        yield return new WaitForSeconds(playModeDelay);
        Assert.IsNotNull(playerInventory);
    }
    [UnityTest]
    public IEnumerator CheckCoinsOnStart()
    {
        yield return new WaitForSeconds(playModeDelay);
        Assert.AreEqual(playerInventory.GetComponent<Inventory>().playerStuff.coins, setCoins);
    }
    [UnityTest]
    public IEnumerator CheckBulletsOnStart()
    {
        yield return new WaitForSeconds(playModeDelay);
        Assert.AreEqual(playerInventory.GetComponent<Inventory>().playerStuff.bullets, setBullets);
    }
    [UnityTest]
    public IEnumerator CheckHealthOnStart()
    {
        yield return new WaitForSeconds(playModeDelay);
        Assert.AreEqual(playerInventory.GetComponent<Inventory>().playerStuff.health, setHealth);
    }
    [TearDown]
    public void DestroyOnEnd() 
    {
        Destroy(playerInventory);
    }
}
