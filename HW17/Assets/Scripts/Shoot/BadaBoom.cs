using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadaBoom : MonoBehaviour
{
    public float radius;
    public float force;

    public bool acive;

    private void Start()
    {
        Explode();
    }
    private void Update()
    {
        if (acive)
            Explode();
    }
    private void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(gameObject);
    }
}
