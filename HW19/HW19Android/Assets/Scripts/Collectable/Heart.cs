using UnityEngine;

public class Heart : MonoBehaviour
{
    private int heartValue = 1;
    public int HeartValue { get; private set; }

    [SerializeField] private ParticleSystem heartPS;
    private ContainerPS contanerPS;

    private void Awake() 
    {
        HeartValue = heartValue;
        contanerPS = FindObjectOfType<ContainerPS>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
        {
            inventory.ReceiveHeart(heartValue);
            InstallHeartPS();
            Destroy(gameObject);
        }
    }

    private void InstallHeartPS()
    {
        Vector3 position = gameObject.transform.position;
        ParticleSystem ps = Instantiate(heartPS, position, Quaternion.identity, contanerPS.transform);
    }
}
