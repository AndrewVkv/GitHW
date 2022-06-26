using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoatingObstacle : MonoBehaviour
{
    private Quaternion originalRotation;
    private float angle;
    private int speed = 50;

    private void Start()
    {
        originalRotation = transform.rotation;
        float delay = Random.Range(0f, 1f);
        StartCoroutine(Rotation(delay));
    }
    private IEnumerator Rotation(float delay) 
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            angle += Time.deltaTime;
            Quaternion rotationY = Quaternion.AngleAxis(angle * speed, Vector3.up);
            transform.rotation = originalRotation * rotationY;
            yield return null;
        }
    }
}
