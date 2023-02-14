using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem coinPS;

    private void OnTriggerEnter(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();

        if (hero != null)
            OnPicked();
    }
    private void OnPicked()
    {
        var pickupAnimInstamce = Instantiate(coinPS, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
