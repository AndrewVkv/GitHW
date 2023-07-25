using UnityEngine;

public class LoseZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
            EventBus.RiseEvLose();
    }
}
