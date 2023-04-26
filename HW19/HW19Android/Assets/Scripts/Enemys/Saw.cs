using UnityEngine;

public class Saw : MonoBehaviour
{
    private int sawDamage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
            inventory.ReceiveDamage(sawDamage);
    }
}
