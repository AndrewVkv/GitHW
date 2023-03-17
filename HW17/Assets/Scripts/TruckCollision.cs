using UnityEngine;

public class TruckCollision : MonoBehaviour
{
    private Truck truck;

    private void Awake() => truck = GetComponentInParent<Truck>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            truck.GoTruck();
        }

        if (collision.TryGetComponent(out Weight weight))
        {
            truck.StopTruck();
        }
    }
}
