using UnityEngine;

public class CollectablePS : MonoBehaviour
{
    private const float delay2Deastroy = 3f;
    private void Awake()
    {
        Destroy(gameObject,delay2Deastroy);
    }
}
