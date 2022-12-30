using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private readonly float radiusCoinsCheckGround = 0.1f;
    private readonly float backOffset = 0.75f;

    private List<GameObject> coinsList = new List<GameObject>();
    [SerializeField] private Transform coinsConatiner;
    private Vector3 coinPosition;
    private int[] roadLines = { -2, 0, 2 };
    private float radiusCheckAnotherCoin = 2f;
    [SerializeField] private float positionToDestroy = -5f;
    [SerializeField][Range(0, 100)] private int spawnCoinsFromZ = 10;
    [SerializeField][Range(0, 100)] private int spawnCoinsTillZ = 90;
    [SerializeField][Range(0, 10)] private int coinsCountOnRoad = 8;

    [Header("Coin Prefabs")]
    [SerializeField] private GameObject coinPrefab;
    [Header("Ground layer")]
    [SerializeField] private LayerMask groundMask;
    [Header("Coin layer")]
    [SerializeField] private LayerMask coinMask;
    [Header("Obstacle layer")]
    [SerializeField] private LayerMask obstacleMask;

    public static CoinManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        // add listeners 4 events
        RegisterEventToMoveCoins();
        RegisterEventDestroyAddCoins();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetCoin(true);
        }
    }
    /// <summary>
    /// Install coin
    /// </summary>
    /// <param name="offsetCoinX">X offset coin position</param>
    private void SetCoin(bool offsetCoinX)
    {

        bool result = false;

        while (!result)
        {
            bool groundPresent = false;
            bool groundPresentBack = false;
            bool anotherCoinPresent = true;
            bool obstaclePresenr = true;

            coinPosition = GetRandomPosition(spawnCoinsFromZ, spawnCoinsTillZ, offsetCoinX);
            groundPresent = Physics.CheckSphere(coinPosition, radiusCoinsCheckGround, groundMask);

            Vector3 backPosition = new Vector3(coinPosition.x, coinPosition.y, coinPosition.z + backOffset);
            groundPresentBack = Physics.CheckSphere(backPosition, radiusCoinsCheckGround, groundMask);

            anotherCoinPresent = Physics.CheckSphere(coinPosition, radiusCheckAnotherCoin, coinMask);
            obstaclePresenr = Physics.CheckSphere(coinPosition, radiusCheckAnotherCoin, obstacleMask);

            result = groundPresent && groundPresentBack && !anotherCoinPresent && !obstaclePresenr;
        }

        GameObject coinToInstall = Instantiate(coinPrefab, coinPosition, Quaternion.identity, coinsConatiner);
        coinToInstall.GetComponent<CoinIndex>().coinIndex = coinsList.Count;
        coinsList.Add(coinToInstall);

    }
    /// <summary>
    /// Coin random position
    /// </summary>
    /// <param name="spawnFrom">positionZ spawn from</param>
    /// <param name="spawnTill">positionZ spawn till</param>
    /// <param name="zeroPositionX">X position offset</param>
    /// <returns></returns>
    private Vector3 GetRandomPosition(int spawnFrom, int spawnTill, bool zeroPositionX)
    {
        coinPosition = Vector3.zero;

        if (!zeroPositionX)
        {
            int posX = Random.Range(0, roadLines.Length);
            coinPosition.x = roadLines[posX];
        }

        int posZ = Random.Range(spawnFrom, spawnTill);
        coinPosition.z = posZ;

        return coinPosition;
    }
    private void MoveCoins()
    {
        float speed = RoadBuilder.Instance.GetRoadSpeed();
        if (coinsList.Count > 0)
        {
            foreach (GameObject coin in coinsList)
            {
                coin.transform.position -= Vector3.forward * speed * Time.fixedDeltaTime;
            }
        }
    }
    private void RegisterEventToMoveCoins()
    {
        //RoadBuilder.Instance.eMove.AddListener(MoveCoins);
        EventBus.eMove.AddListener(MoveCoins);
    }
    private void CheckCoinPosition()
    {
        for (int i = 0; i < coinsList.Count; i++)
        {
            if (coinsList[i].transform.position.z < positionToDestroy)
            {
                RemoveCoinAtList(i);
            }
        }
    }
    public void RemoveCoinAtList(int listIndex)
    {
        //print(listIndex);
        GameObject coinToDestroy = coinsList[listIndex];
        coinsList.RemoveAt(listIndex);
        Destroy(coinToDestroy);

        for (int i = 0; i < coinsList.Count; i++)
        {
            coinsList[i].GetComponent<CoinIndex>().coinIndex = i;
        }
    }
    private void RegisterEventDestroyAddCoins()
    {
        RoadBuilder.Instance.eDestroyAddObjects.AddListener(CheckCoinPosition);
    }
    public void InitCoinsOnStart()
    {
        for (int i = 0; i < coinsCountOnRoad; i++)
        {
            SetCoin(true);
        }
        StartCoroutine(CheckCoinsCountRemoveAndAdd(false));
    }
    private IEnumerator CheckCoinsCountRemoveAndAdd(bool xOffsetCoinPosition) 
    {
        while (Stage.gameStage != STAGE.three)
        {
            yield return new WaitForSeconds(1);
            if (coinsCountOnRoad > coinsList.Count)
            {
                for (int i = coinsList.Count; i < coinsCountOnRoad; i++)
                {
                    SetCoin(xOffsetCoinPosition);
                }
            }
        }
    }
}
