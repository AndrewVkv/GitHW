using UnityEngine;

public class TremorPoints : MonoBehaviour
{
    public Transform[] points { get; private set; }

    private void Awake()
    {
        int count = transform.childCount;

        points = new Transform[count];
        for (int i = 0; i < count; i++)
            points[i] = transform.GetChild(i).transform;
    }
}
