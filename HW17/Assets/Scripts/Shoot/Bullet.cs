using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // constants
    private readonly int distanceDestroy = 15;
    private readonly float checkDelay = 0.25f;
    private void Start()
    {
        StartCoroutine(DestroyBullet(checkDelay));
    }
    private IEnumerator DestroyBullet(float delay)
    {
        while (true)
        {
            // destroy bullet depends Z position
            yield return new WaitForSeconds(delay);
            if (transform.position.z > distanceDestroy)
                Destroy(gameObject);
        }
    }
}
