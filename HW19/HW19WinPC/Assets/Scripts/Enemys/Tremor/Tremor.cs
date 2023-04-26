using UnityEngine;

public class Tremor : MonoBehaviour
{
    private const float maxwaitingTime = 3f;
    private const float minwaitingTime = 0f;
    private float waitingTime;

    [SerializeField] private Transform[] points;
    [SerializeField] private TremorPoints tremorPoints;
    [SerializeField] private Beetle beetle;

    [SerializeField] private bool go;

    private float speed = 1;
    private int index = 0;

    private Timer timer = new Timer();

    private void Start()
    {
        tremorPoints = GetComponentInChildren<TremorPoints>();
        beetle = GetComponentInChildren<Beetle>();

        points = tremorPoints.points;
        go = true;
        waitingTime = Random.Range(minwaitingTime, maxwaitingTime);
    }

    private void Update()
    {
        if (go)
            beetle.Move(points[index], speed);

        CheckBeetlePosition();
    }

    private void CheckBeetlePosition()
    {
        if (beetle.transform.localPosition == points[index].transform.localPosition)
        {
            go = timer.StartT(waitingTime);

            if (go)
                index = (index < points.Length - 1) ? +1 : 0;
        }
    }
}
