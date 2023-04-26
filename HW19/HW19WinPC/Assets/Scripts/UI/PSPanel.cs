using UnityEngine;

public class PSPanel : MonoBehaviour
{
    [SerializeField] private ParticleSystem winPS;

    private void Awake()
    {
        winPS = GetComponentInChildren<ParticleSystem>();
        GlobalEventManager.eGemCollected.AddListener(PlayWinPS);
    }

    private void PlayWinPS() 
    {
        winPS.Play();
        print("PS");
    }
}
