using UnityEngine;

public class LoosePannel : MonoBehaviour, IPlayerPannels
{
    public void SetActivePannel(bool active) => gameObject.SetActive(active);
}
