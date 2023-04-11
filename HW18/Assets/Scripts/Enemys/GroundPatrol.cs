using UnityEngine;

public class GroundPatrol : MonoBehaviour
{
    private readonly float speed = 1.5f;
    private const float rayLength = 1f;

    private Vector2 direction = Vector2.left;
    private Transform groundDetect;
    private int damage = 1;

    private void Awake() => groundDetect = gameObject.transform.GetChild(0);

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        RaycastHit2D ray = Physics2D.Raycast(groundDetect.position, Vector2.down, rayLength);

        if (ray.collider == null)
            ReflectObject();
    }

    private void ReflectObject() 
    {
        Vector2 reflect = new Vector2(-1,1);

        direction *= reflect;
        transform.localScale *= reflect;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
            inventory.ReceiveDamage(damage);
    }
}
