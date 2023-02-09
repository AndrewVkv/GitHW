using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public GameObject[] platforms;

    private void Start()
    {
        foreach (var plafrms in platforms)
            plafrms.SetActive(false);
    }
    public void OpenBridge() 
    {
        foreach (var plafrms in platforms)
            plafrms.SetActive(true);
    }
}
