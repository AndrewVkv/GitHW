using UnityEngine;

public class Coin : MonoBehaviour
{
    private int coinValue = 1;
    public int CoinValue { get; private set; }

    private void Awake() => CoinValue = coinValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Inventory inventory))
        {
            inventory.ReceiveCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
