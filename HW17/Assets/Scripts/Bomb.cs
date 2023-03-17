using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameObject PhysicsExplosion;

    [SerializeField]
    private GameObject gfxExplosion;

    private float delay = 0.25f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            SetBombExplosion(delay);
            Destroy(gameObject);
        }
    }

    private void SetBombExplosion(float delay) 
    {
        GameObject PhysicsBomb = Instantiate(PhysicsExplosion, transform.position, Quaternion.identity);
        GameObject gfxBomb = Instantiate(gfxExplosion, transform.position, Quaternion.identity);

        Destroy(PhysicsBomb, delay);
        Destroy(gfxBomb, delay);
    }
}
