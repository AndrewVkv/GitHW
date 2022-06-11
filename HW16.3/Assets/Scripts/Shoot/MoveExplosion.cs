using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveExplosion : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        speed = RoadController.Instance.speed;
    }
    private void Update()
    {
        MoveExplosionObject();
    }
    private void MoveExplosionObject() 
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
    }
}
