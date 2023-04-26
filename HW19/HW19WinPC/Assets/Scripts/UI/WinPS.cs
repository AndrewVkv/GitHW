using UnityEngine;

public class WinPS : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        if(TryGetComponent(out ParticleSystem partsys))
            ps = partsys;

        GlobalEventManager.eGemCollected.AddListener(PlayPS);
    }

    private void PlayPS() => ps.Play();
}
