using UnityEngine;

public class JumpNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IMovement heroMove))
            heroMove.Jump();
    }
}
