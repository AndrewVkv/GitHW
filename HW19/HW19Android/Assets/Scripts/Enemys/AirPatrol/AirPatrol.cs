using UnityEngine;

public class AirPatrol : MonoBehaviour
{
    private const float minWaitingTime = 0.5f;
    private const float maxWaitingTime = 3f;

    private Transform[] points;
    private AirPoints airPoints;
    private FlyEnemy flyEnemy;
    [SerializeField] private bool go;

    private float speed = 1;
    private int index = 0;
    private float waitingTime;


    private Timer timer = new Timer();
    private void Start()
    {
        airPoints = GetComponentInChildren<AirPoints>();
        points = airPoints.flyPoints;

        flyEnemy = GetComponentInChildren<FlyEnemy>();
        flyEnemy.SetStartPosition(points[0].transform.localPosition);

        if (points != null)
            index = 0;

        go = false;

        waitingTime = Random.Range(minWaitingTime, maxWaitingTime);
    }

    private void Update()
    {
        if (go)
            flyEnemy.Move(points[index], speed);

        CheckFlyPosition();
    }

    private void CheckFlyPosition()
    {
        if (flyEnemy.transform.localPosition == points[index].transform.localPosition)
        {

            go = timer.StartT(waitingTime);

            if (go) 
            {
                index = (index < points.Length - 1) ? +1 : 0;
                flyEnemy.Reflect();
            }
        }
    }
}
