using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFreeze : MonoBehaviour
{
    private readonly string bulletTag = "Bullet";

    public Rigidbody[] rb;

    private void Start()
    {
        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].isKinematic = true;
            rb[i].useGravity = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(bulletTag))
        {
            //print("Collision with bullet");
            UnfreezeWall();
            DisableWallTriggerCollider();
            other.GetComponent<BulletCollision>().ExternalImplode(gameObject);
            Destroy(other.gameObject);
        }

    }
    private void UnfreezeWall() 
    {
        for (int i = 0; i < rb.Length; i++)
        {
            rb[i].isKinematic = false;
            rb[i].useGravity = true;
        }
    }
    private void DisableWallTriggerCollider() 
    {
        Collider boxWall = GetComponent<Collider>();
        boxWall.enabled = false;
    }
}
