using UnityEngine;

public class BulletDestroyable : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathPS;
    private ContainerPS contanerPS;


    private void Awake() => contanerPS = FindObjectOfType<ContainerPS>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet b)) 
        {
            InstallDeathPS();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet b)) 
        {
            InstallDeathPS();
            gameObject.SetActive(false);
        }
    }

    private void InstallDeathPS()
    {
        Vector3 position = gameObject.transform.position;
        ParticleSystem ps = Instantiate(deathPS, position, Quaternion.identity, contanerPS.transform);
    }
}
