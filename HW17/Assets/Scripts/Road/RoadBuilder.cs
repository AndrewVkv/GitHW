using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBuilder : MonoBehaviour
{
    private readonly float delayCheckPlatformPosition = 1f;
    private readonly float delayToMoveRoad = 3f;

    private List<GameObject> ReadyRoad = new List<GameObject>();
    [SerializeField] private Transform platformConatiner;
    [SerializeField] private GameObject startPlatform;
    [SerializeField] private GameObject finishPlatform;
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private bool moveRoad;
    [SerializeField] private float roadSpeed = 3f;
    [SerializeField] private float destroyPlatformPositionZ = -25f;
    [SerializeField] private int platformsCount = 6;
    public int DelayedPlatformsCount = 0;

    private Transform lastPlatform;
    [SerializeField]private bool initPlatorms = true;

    public static RoadBuilder Instance;
    //public UnityEvent eMove = new UnityEvent();
    public UnityEvent eDestroyAddObjects = new UnityEvent();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        InitPlatformsOnStart();

        StartCoroutine(ChecckPlatformsPosition());
        EventBus.eMove.AddListener(MovePlatforms);
        EventBus.eWin.AddListener(StopMovingRoad);
        //eMove.AddListener(MovePlatforms);
        eDestroyAddObjects.AddListener(RemoveAddPlatforms);

        StartCoroutine(StartDelayToMoveRoad(delayToMoveRoad));
    }
    private void FixedUpdate()
    {
        if (moveRoad)
            EventBus.eMove?.Invoke();
    }
    private void SetPlatform(int index)
    {
        Vector3 platformPosition = (lastPlatform == null) ?
            platformConatiner.position :
            lastPlatform.GetComponent<EndPlatformPoint>().endPoint.position;

        if (lastPlatform == null)
        {
            GameObject startPlatformToInstall = Instantiate(startPlatform, platformPosition, Quaternion.identity, platformConatiner);
            lastPlatform = startPlatformToInstall.transform;
            ReadyRoad.Add(startPlatformToInstall);
        }
        else
        {
            GameObject platformToInstall = Instantiate(platforms[index], platformPosition, Quaternion.identity, platformConatiner);
            lastPlatform = platformToInstall.transform;
            ReadyRoad.Add(platformToInstall);
        }
    }
    private void MovePlatforms()
    {
        if (ReadyRoad.Count != 0)
        {
            foreach (GameObject platform in ReadyRoad)
                platform.transform.localPosition -= Vector3.forward * roadSpeed * Time.fixedDeltaTime;
        }

    }
    private IEnumerator ChecckPlatformsPosition()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayCheckPlatformPosition);
            if (ReadyRoad[0].transform.localPosition.z < destroyPlatformPositionZ)
            {
                eDestroyAddObjects?.Invoke();
            }
        }
    }
    private void RemovePlatform()
    {
        GameObject platformToRemove = ReadyRoad[0];
        ReadyRoad.RemoveAt(0);
        Destroy(platformToRemove);
        DelayedPlatformsCount++;
        Stage.CheckStage();
    }
    private int GetRandomPlatform(int indexFrom, int indexTill)
    {
        int platformsArrayIndex = Random.Range(indexFrom, indexTill);
        return platformsArrayIndex;
    }
    private void RemoveAddPlatforms()
    {
        RemovePlatform();
        if (initPlatorms)
        {
            if (DelayedPlatformsCount != 0 && DelayedPlatformsCount % 8 == 0)
                SetPlatform(platforms.Length - 1);
            else
                ChoosePlatformToInstall();
        }

    }
    public float GetRoadSpeed()
    {
        return roadSpeed;
    }
    public void StopMovingRoad()
    {
        moveRoad = false;
    }
    private void InitPlatformsOnStart()
    {
        for (int i = 0; i < platformsCount; i++)
        {
            if (i % 2 == 0)
                SetPlatform(1);

            if (i % (platformsCount - 1) == 0 && i != 0)
                SetPlatform(platformsCount - 1);

            else
                SetPlatform(0);
        }
        CoinManager.Instance.InitCoinsOnStart();
        ObstacleManager.Instance.InitObstaclesOnStart();
    }
    private IEnumerator StartDelayToMoveRoad(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveRoad = true;
    }
    private void ChoosePlatformToInstall()
    {
        switch (Stage.gameStage)
        {
            case STAGE.one:
                SetPlatform(GetRandomPlatform(0, platforms.Length - 3));
                break;
            case STAGE.two:
                SetPlatform(GetRandomPlatform(0, platforms.Length - 2));
                break;
            case STAGE.three:
                InitFinishPlatform();
                break;
            default:
                break;
        }
    }
    private void InitFinishPlatform()
    {
        Vector3 finishPlatformPosition = lastPlatform.GetComponent<EndPlatformPoint>().endPoint.position;

        GameObject finishPlatformToInstall = Instantiate(finishPlatform, finishPlatformPosition, Quaternion.identity, platformConatiner);
        lastPlatform = finishPlatformToInstall.transform;
        ReadyRoad.Add(finishPlatformToInstall);
        initPlatorms = false;
    }
}
