using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // constants
    private readonly string obstacleTransformError = "No obstacle attached";
    private readonly float radiusObstaclesCheckGround = 0.1f;
    private readonly float delayCheckObstaclePosition = 1f;
    private readonly int spawnFrom = 50;
    private readonly int zero = 0;

    private List<GameObject> obstaclesList = new List<GameObject>();
    private Vector3 obstaclePosition;
    [Header("Prefab obstacle")]
    public GameObject obstacle;
    [Header("Ground layer")]
    public LayerMask groundMask;
    [Header("Obstacle layer")]
    public LayerMask obstacleMask;


    private float[] arryX;
    private int spawnFromOnStart = 10;
    private int spawnTill = 100;
    public int obstaclesCount = 5;
    private int[] obstaclesCountOnRoad =  {5,7,9 };

    public static ObstacleManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        // check for present object
        if (obstacle == null)
            Debug.Log(obstacleTransformError);

        // set obstacles count on road
        obstaclesCount = obstaclesCountOnRoad[0];
    }
    private void Start()
    {
        FillArryPosition();
        StartCoroutine(InitObstacles());
        StartCoroutine(CheckPositionTryDestroy(delayCheckObstaclePosition));

    }

    /// <summary>
    /// Install obstacle
    /// </summary>
    private void SetObstacle()
    {
        Vector3 position = Vector3.zero;
        bool groundOnPosition = false;
        bool backGroundOnPosition = false;
        bool secondOstacle = false;
        bool result = false;
        Vector3 backPosition = Vector3.zero;

        // check for present ground & no obstacle
        while (!result)
        {
            groundOnPosition = false;
            backGroundOnPosition = false;
            position = GetRandomPosition();
            groundOnPosition = Physics.CheckSphere(position, radiusObstaclesCheckGround, groundMask);
            secondOstacle = Physics.CheckSphere(position, radiusObstaclesCheckGround, obstacleMask);
            backPosition = new Vector3(position.x, position.y, position.z + 1);
            backGroundOnPosition = Physics.CheckSphere(backPosition, radiusObstaclesCheckGround, groundMask);
            result = groundOnPosition && backGroundOnPosition && !secondOstacle;
        }

        GameObject obstacleObject = Instantiate(obstacle, position, Quaternion.identity, transform.transform);
        obstacleObject.GetComponent<ObstacleListIndex>().index = obstaclesList.Count;
        obstaclesList.Add(obstacleObject);
    }

    /// <summary>
    /// X position obstacle
    /// </summary>
    private void FillArryPosition()
    {
        float value = PlayerMover.Instance.lineOffset;
        arryX = new float[3] { -value, 0, value };
    }
    /// <summary>
    /// Obstacle random position
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPosition()
    {
        obstaclePosition = Vector3.zero;
        int value = Random.Range(0, arryX.Length);
        obstaclePosition.x = arryX[value];
        obstaclePosition.z = Random.Range(spawnFromOnStart, spawnTill);
        return obstaclePosition;
    }

    public void MoveObstacles(float speed)
    {
        foreach (GameObject obstacle in obstaclesList)
            obstacle.transform.position -= Vector3.forward * speed * Time.deltaTime;
    }
    private IEnumerator InitObstacles()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < obstaclesCount; i++)
        {
            SetObstacle();
        }
    }
    public void RemoveObstacleAtList(int index)
    {
        GameObject objectToDestroy = obstaclesList[index];
        obstaclesList.RemoveAt(index);
        Destroy(objectToDestroy);

        for (int i = 0; i < obstaclesList.Count; i++)
        {
            obstaclesList[i].GetComponent<ObstacleListIndex>().index = i;
        }
    }
    /// <summary>
    /// Check obstacle position to destroy
    /// </summary>
    private void CheckObstaclePosition()
    {
        for (int i = 0; i < obstaclesList.Count; i++)
        {
            if (obstaclesList[i].transform.position.z < RoadController.Instance.destroyPositionZ)
            {
                RemoveObstacleAtList(i);
            }
        }
    }
    private void AddObstacle() 
    {
        if (obstaclesList.Count < obstaclesCount)
        {
            for (int i = obstaclesList.Count; i < obstaclesCount; i++)
            {
                SetObstacle();
            }
        }
    }
    private IEnumerator CheckPositionTryDestroy(float delay) 
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            CheckObstaclePosition();
            AddObstacle();
        }
    }
    /// <summary>
    /// Bullet collision routine
    /// </summary>
    /// <param name="listNumber"></param>
    public void RemoveAddObstacleBulletCollision(int listNumber) 
    {
        RemoveObstacleAtList(listNumber);
        AddObstacle();
    }
    public void ResetSpawnFrom() 
    {
        spawnFromOnStart = spawnFrom;
    }
    /// <summary>
    /// Obstacles count level 2
    /// </summary>
    public void ObstaclesCountLvl2() 
    {
        obstaclesCount = obstaclesCountOnRoad[1];
    }
    /// <summary>
    /// Obstacles count level 3
    /// </summary>
    public void ObstaclesCountLvl3()
    {
        obstaclesCount = obstaclesCountOnRoad[2];
    }
    /// <summary>
    /// No spawn obstacles
    /// </summary>
    public void ZeroObstaclesCount() 
    {
        obstaclesCount = zero;
    }
}
