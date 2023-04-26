using UnityEngine;

public class AirPoints : MonoBehaviour
{
    public Transform[] flyPoints { get; private set; }

    private void Awake()
    {
        int count = transform.childCount;

        flyPoints = new Transform[count];
        for (int i = 0; i < count; i++)
            flyPoints[i] = transform.GetChild(i).transform;
    }
}
