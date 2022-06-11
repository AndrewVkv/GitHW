using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // constants
    private readonly int distanceDestroy = 10;
    private readonly float checkDelay = 0.25f;
    private void Start()
    {
        StartCoroutine(CheckDestroy(checkDelay));
    }
    private IEnumerator CheckDestroy(float delay) 
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
