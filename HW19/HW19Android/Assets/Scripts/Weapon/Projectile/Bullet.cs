using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviour
{
    private readonly int currentDamage = 1;
    private readonly float delay2Deastroy = 5f;
    public int damage { get; private set; }

    private void Awake()
    {
        damage = currentDamage;
        Destroy(gameObject, delay2Deastroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory)) 
        {
            inventory.ReceiveDamage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.TryGetComponent(out BossHealth bossHealth))
        {
            bossHealth.ReceiveDamage(damage);
            Destroy(gameObject);
        }


        if (collision.gameObject.TryGetComponent(out Collider2D col))
            Destroy(gameObject);
    }
}
