using UnityEngine;

public class TremorPoints : MonoBehaviour
{
    public Transform[] tremorPoints { get; private set; }

    private void Awake()
    {
        int count = transform.childCount;

        tremorPoints = new Transform[count];
        for (int i = 0; i < count; i++)
            tremorPoints[i] = transform.GetChild(i).transform;
    }
}
