using UnityEngine;

public class WinPannel : MonoBehaviour, IPlayerPannels
{
    public void SetActivePannel(bool acive) => gameObject.SetActive(acive);
}
