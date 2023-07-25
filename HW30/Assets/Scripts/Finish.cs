using UnityEngine;

public class Finish : MonoBehaviour
{
    private void Start()
    {
        EventBus.eLose.AddListener(removeFinish);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ball>(out Ball ball))
            EventBus.RiseEvWin();
    }

    private void removeFinish(bool k)=> gameObject.SetActive(false);
}
