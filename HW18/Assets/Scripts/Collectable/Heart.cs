using UnityEngine;

public class Heart : MonoBehaviour
{
    private int heartValue = 1;
    public int HeartValue { get; private set; }

    private void Awake() => HeartValue = heartValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
        {
            inventory.ReceiveHeart(heartValue);
            Destroy(gameObject);
        }
    }
}
