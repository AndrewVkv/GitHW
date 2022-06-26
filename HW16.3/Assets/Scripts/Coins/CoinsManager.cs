using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    // constants
    private readonly float radiusSpereCheckGround = 0.2f;
    private readonly float delayCheckCoinPosition = 1f;

    private List<GameObject> coinList = new List<GameObject>();
    private Vector3 coinPosition;
    private float[] arryX;
    [SerializeField]
    private int spawnFrom = 20;
    [SerializeField]
    private int spawnTill = 90;
    [SerializeField]
    private int coinsCount = 10;

    [Header("Ground Layer")]
    public LayerMask groundMask;
    [Header("Coin Layer")]
    public LayerMask coinMask;
    [Header("Coin Prefab")]
    public GameObject coin;

    public static CoinsManager instance;

    private void Start()
    {
        instance = this;
        FillArryXPosition();
        StartCoroutine(InitCoins());
        StartCoroutine(CheckPositionTryDestroy(delayCheckCoinPosition));
    }
    /// <summary>
    /// Random position XYZ
    /// </summary>
    /// <returns></returns>
    public Vector3 GetRandomPosition() 
    {
        coinPosition = Vector3.zero;
        int valueX = Random.Range(0, arryX.Length);
        coinPosition.x = arryX[valueX];
        coinPosition.z = Random.Range(spawnFrom, spawnTill);
        return coinPosition;
    }
    /// <summary>
    /// X position
    /// </summary>
    private void FillArryXPosition() 
    {
        float value = PlayerMover.Instance.lineOffset;
        arryX = new float[] { -value, 0, value };
    }
    /// <summary>
    /// Install Coin
    /// </summary>
    private void SetCoin() 
    {
        Vector3 position = Vector3.zero;
        bool groundOnPosition = false;
        bool secondCoin = false;
        bool result = false;
        while (!result)
        {
            position = GetRandomPosition();

            // Check ground present & no coin
            groundOnPosition = Physics.CheckSphere(position, radiusSpereCheckGround, groundMask);
            secondCoin = Physics.CheckSphere(position, radiusSpereCheckGround, coinMask);

            result = groundOnPosition && !secondCoin;
        }
        GameObject coinToInstall = Instantiate(coin, position, Quaternion.identity, transform.transform);
        coinToInstall.GetComponent<CoinIndex>().coinIndex = coinList.Count;
        coinList.Add(coinToInstall);
    }
    /// <summary>
    /// Initialise coins on start
    /// </summary>
    /// <returns></returns>
    private IEnumerator InitCoins() 
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < coinsCount; i++)
        {
            SetCoin();
        }
    }
    public void MoveCoins(float speed) 
    {
        foreach (GameObject coin in coinList)
            coin.transform.position -= Vector3.forward * speed * Time.deltaTime;
    }
    /// <summary>
    /// Check position to destroy
    /// </summary>
    private void CheckCoinPosition() 
    {
        for (int i = 0; i < coinList.Count; i++)
        {
            if (coinList[i].transform.position.z < RoadController.Instance.destroyPositionZ)
                RemoveCoinAtList(i);
        }
    }
    private void RemoveCoinAtList(int index) 
    {
        GameObject cionToDestroy = coinList[index];
        coinList.RemoveAt(index);
        Destroy(cionToDestroy);

        for (int i = 0; i < coinList.Count; i++)
        {
            coinList[i].GetComponent<CoinIndex>().coinIndex = i;
        }
    }
    private IEnumerator CheckPositionTryDestroy(float delay) 
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            CheckCoinPosition();
            if (Stage.instance.stage != STAGE.Six)
                AddCoin();
        }
    }
    /// <summary>
    /// Add coins after destroy
    /// </summary>
    private void AddCoin() 
    {
        if (coinList.Count < coinsCount)
        {
            for (int i = coinList.Count; i < coinsCount; i++)
            {
                SetCoin();
            }
        }
    }
    /// <summary>
    /// Remove & add coin after player collision
    /// </summary>
    /// <param name="listNumber"></param>
    public void RemoveAddCoinPlayerCollision(int listNumber) 
    {
        RemoveCoinAtList(listNumber);
        if(Stage.instance.stage != STAGE.Six)
            AddCoin();
    }
}
