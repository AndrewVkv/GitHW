using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;
    private float angle = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IMove move))
            Picked();
    }
    private void Picked()
    {
        var pickupAnim = Instantiate(ps, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        Quaternion rotationY = Quaternion.AngleAxis(angle, Vector3.right);
        transform.GetChild(0).rotation *= rotationY;
    }
}
