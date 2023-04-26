using UnityEngine;

public class Coin : MonoBehaviour
{
    private int coinValue = 1;
    public int CoinValue { get; private set; }

    [SerializeField] private ParticleSystem coinPS;
    private ContainerPS contanerPS;

    private void Awake() 
    {
        CoinValue = coinValue;
        contanerPS = FindObjectOfType<ContainerPS>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
        {
            inventory.ReceiveCoin(coinValue);
            InstallCoinPS();
            Destroy(gameObject);
        }
    }

    private void InstallCoinPS() 
    {
        Vector3 position = gameObject.transform.position;
        ParticleSystem ps =  Instantiate(coinPS, position, Quaternion.identity, contanerPS.transform);
    }
}
