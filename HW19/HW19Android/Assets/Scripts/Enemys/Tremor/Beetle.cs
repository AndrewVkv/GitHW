using UnityEngine;

public class Beetle : MonoBehaviour
{
    private readonly int damage = 1;
    public void SetStartPosition(Vector3 startPosition)
    {
        gameObject.transform.localPosition = startPosition;
    }
    public void Move(Transform point_1, float speed)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, point_1.localPosition, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
            inventory.ReceiveDamage(damage);
    }
}
