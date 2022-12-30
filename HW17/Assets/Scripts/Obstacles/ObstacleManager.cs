using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private readonly float radiusObstaclesCheckGround = 0.1f;
    private readonly float delay2AddObstacle = 2f;

    private List<GameObject> obstaclesList = new List<GameObject>();
    [SerializeField] private Transform obstaclesConatiner;
    private Vector3 obstaclePosition;
    private int[] roadLines = { -2, 0, 2 };
    private float radiusCheckAnotherObstacle = 2f;
    [SerializeField] private float positionToDestroy = -5f;
    [SerializeField] [Range(0, 100)]private int spawnObstacleFromZ = 10;
    [SerializeField][Range(0, 100)] private int spawnObstacleTillZ = 90;
    [SerializeField][Range(0, 10)] private int obstaclesCountOnRoad = 5;

    [Header("Obstacle layer")]
    [SerializeField] private LayerMask obstacleMask;
    [Header("Coin layer")]
    [SerializeField] private LayerMask coinMask;

    [Header("Prefab obstacle")]
    [SerializeField] private GameObject obstaclePrefab;
    [Header("Ground layer")]
    [SerializeField] private LayerMask groundMask;

    public static ObstacleManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        // add listeners 4 events
        RegisterEventToMove();
        RegisterEventDestroyAdd();
    }
    private void SetObstacle(bool offsetObstacleX) 
    {
        bool result = false;

        while (!result)
        {
            bool groundPresent = false;
            bool groundPresentBack = false;
            bool anotherObstaclePresent = true;
            bool coinPresent = true;

            obstaclePosition = GetRandomPosition(spawnObstacleFromZ, spawnObstacleTillZ, offsetObstacleX);
            groundPresent = Physics.CheckSphere(obstaclePosition, radiusObstaclesCheckGround, groundMask);

            Vector3 backPosition = new Vector3(obstaclePosition.x, obstaclePosition.y, obstaclePosition.z + 1);
            groundPresentBack = Physics.CheckSphere(backPosition, radiusObstaclesCheckGround, groundMask);
            anotherObstaclePresent = Physics.CheckSphere(obstaclePosition, radiusCheckAnotherObstacle, obstacleMask);
            coinPresent = Physics.CheckSphere(obstaclePosition, radiusCheckAnotherObstacle, coinMask);

            result = groundPresent && groundPresentBack && !anotherObstaclePresent && !coinPresent;
        }

        GameObject obstacle = Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity, obstaclesConatiner);
        obstacle.GetComponent<ObstacleIndex>().index = obstaclesList.Count;
        obstaclesList.Add(obstacle);
    }
    private Vector3 GetRandomPosition(int spawnFrom, int spawnTill, bool zeroPositionObstacleX) 
    {
        obstaclePosition = Vector3.zero;
        if (!zeroPositionObstacleX)
        {
            int posX = Random.Range(0, roadLines.Length);
            obstaclePosition.x = roadLines[posX];
        }

        int posZ = Random.Range(spawnFrom, spawnTill);
        obstaclePosition.z = posZ;

        return obstaclePosition;
    }
    private void MoveObstacles() 
    {
        float speed = RoadBuilder.Instance.GetRoadSpeed();
        foreach (GameObject obstacle in obstaclesList)
        {
            obstacle.transform.position -= Vector3.forward * speed * Time.fixedDeltaTime;
        }
    }
    private void RegisterEventToMove() 
    {
        //RoadBuilder.Instance.eMove.AddListener(MoveObstacles);
        EventBus.eMove.AddListener(MoveObstacles);
    }
    private void CheckObstaclePosition() 
    {
        for (int i = 0; i < obstaclesList.Count; i++)
        {
            if (obstaclesList[i].transform.position.z < positionToDestroy) 
            {
                RemoveObstacleAtList(i);
            }
        }
    }
    private void RemoveObstacleAtList(int listIndex) 
    {
        GameObject objectToDeastroy = obstaclesList[listIndex];
        obstaclesList.RemoveAt(listIndex);
        Destroy(objectToDeastroy);
        for (int i = 0; i < obstaclesList.Count; i++)
        {
            obstaclesList[i].GetComponent<ObstacleIndex>().index = i;
        }
    }
    private void RegisterEventDestroyAdd() 
    {
        RoadBuilder.Instance.eDestroyAddObjects.AddListener(CheckObstaclePosition);
    }
    public void InitObstaclesOnStart() 
    {
        for (int i = 0; i < obstaclesCountOnRoad; i++)
        {
            SetObstacle(true);
            StartCoroutine(CheckObstaclesCountRemoveAndAdd(false));
        }
    }
    private IEnumerator CheckObstaclesCountRemoveAndAdd(bool xOffsetObstaclePosition)
    {
        while (Stage.gameStage != STAGE.three)
        {
            yield return new WaitForSeconds(delay2AddObstacle);
            if (obstaclesCountOnRoad > obstaclesList.Count)
            {
                for (int i = obstaclesList.Count; i < obstaclesCountOnRoad; i++)
                {
                    SetObstacle(xOffsetObstaclePosition);
                }
            }
        }
    }
    public void ExternalRemoveObstacleAtList(int listIndex) => RemoveObstacleAtList(listIndex);
}
