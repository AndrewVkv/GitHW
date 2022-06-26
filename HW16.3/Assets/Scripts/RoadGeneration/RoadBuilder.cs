using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBuilder : MonoBehaviour
{
    // contants
    private readonly int freePlatforms = 5;
    private readonly int constLengthZero = 2;
    private readonly int constLengthOne = 10;
    private readonly int constLengthTwo = 20;
    private readonly int constLengthThree = 30;
    private readonly int constLengthFour = 40;

    // create event for remove & creation platforms
    UnityEvent eventPlatform = new UnityEvent();

    private List<GameObject> ReadyRoad = new List<GameObject>();
    private Transform lastPlatform;
    private RoadController roadController;
    private Stage stage;
    [SerializeField]
    private int platformsRemovedCount;

    public GameObject[] platforms;
    public GameObject startPlatform;


    private void Awake()
    {
        stage = GetComponent<Stage>();
        roadController = GetComponent<RoadController>();
        InitialiseRoad();
    }
    private void Start()
    {
        eventPlatform.AddListener(RemovePlatform);
        eventPlatform.AddListener(CreatePlatform);
    }
    private void CreatePlatform()
    {
        // check last platform
        Vector3 platformPosition = (lastPlatform == null) ?
            transform.transform.position :
            lastPlatform.GetComponent<PlatformEndPosition>().endPoint.position;

        if (lastPlatform == null)
        {
            GameObject startPlatformInstall = Instantiate(startPlatform, platformPosition, Quaternion.identity, transform.transform);
            lastPlatform = startPlatformInstall.transform;
            ReadyRoad.Add(startPlatformInstall);
        }
        else
        {
            int index;
            if (ReadyRoad.Count < freePlatforms)
                index = 0;
            else
                index = ChoosePlatform();

            GameObject platformInstall = Instantiate(platforms[index], platformPosition, Quaternion.identity, transform.transform);
            lastPlatform = platformInstall.transform;
            ReadyRoad.Add(platformInstall);

            if (stage.stage == STAGE.Six) 
            {
                eventPlatform.RemoveListener(CreatePlatform);
            }
        }
    }
    /// <summary>
    /// Choose platform from arry prefabs
    /// </summary>
    /// <returns></returns>
    private int ChoosePlatform()
    {
        // choose platform from range till index arry position
        int range = 0;
        int index = 0;
        switch (stage.stage)
        {
            case STAGE.Zero:
                // simple platforms
                range = constLengthZero;
                index = Random.Range(0, range);
                break;
            case STAGE.One:
                range = constLengthOne;
                index = Random.Range(0, range);
                ObstacleManager.Instance.ResetSpawnFrom();
                break;
            case STAGE.Two:
                range = constLengthTwo;
                index = Random.Range(constLengthOne, range);
                ObstacleManager.Instance.ObstaclesCountLvl2();
                break;
            case STAGE.Three:
                range = constLengthThree;
                index = Random.Range(constLengthTwo, range);
                ObstacleManager.Instance.ObstaclesCountLvl3();
                break;
            case STAGE.Four:
                range = constLengthFour;
                index = Random.Range(constLengthThree, range);
                ObstacleManager.Instance.ZeroObstaclesCount();
                break;
            case STAGE.Five:
                range = platforms.Length - 1;
                index = Random.Range(constLengthFour, range);
                break;
            case STAGE.Six:
                index = platforms.Length - 1;
                break;
            default:
                break;
        }

        return index;
    }
    /// <summary>
    /// Check position to destroy
    /// </summary>
    public void CheckPlatformPosition()
    {
        if (ReadyRoad[0].transform.localPosition.z < roadController.destroyPositionZ)
        {
            eventPlatform.Invoke();
        }
    }
    private void RemovePlatform()
    {
        GameObject platformToDestroy = ReadyRoad[0];
        ReadyRoad.RemoveAt(0);
        Destroy(platformToDestroy);
        platformsRemovedCount++;
        stage.CheckStage(platformsRemovedCount);
    }
    /// <summary>
    /// Initialise platforms on start
    /// </summary>
    private void InitialiseRoad()
    {
        for (int i = 0; i < roadController.roadLength; i++)
        {
            CreatePlatform();
        }
    }
    public void MovePlatforms(float speed)
    {
        foreach (GameObject platform in ReadyRoad)
            platform.transform.localPosition -= Vector3.forward * speed * Time.deltaTime;
    }
}
