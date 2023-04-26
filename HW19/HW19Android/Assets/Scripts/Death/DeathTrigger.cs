using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private const int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
        {
            inventory.ReceiveDamage(damage);
        }
    }
}
