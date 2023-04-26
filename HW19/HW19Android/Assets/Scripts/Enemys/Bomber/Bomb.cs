using UnityEngine;

public class Bomb : MonoBehaviour
{
    private readonly int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory)) 
        {
            inventory.ReceiveDamage(damage);
            this.gameObject.SetActive(false);
        }
    }
}
