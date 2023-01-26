using UnityEngine;
using System;

public class PlayerPannels : MonoBehaviour
{
    private WinPannel winPannel;
    private LoosePannel loosePannel;

    public WinPannel WinPannel => winPannel;
    public LoosePannel LoosePannel => loosePannel;

    private void Start()
    {
        winPannel = GetComponentInChildren<WinPannel>();
        if (winPannel == null)
            throw new Exception($"There is no WinPannel component in child:  { gameObject.name }");

        loosePannel = GetComponentInChildren<LoosePannel>();
        if (loosePannel == null)
            throw new Exception($"There is no LoosePannel component in child:  { gameObject.name }");

        winPannel.SetActivePannel(false);
        loosePannel.SetActivePannel(false);
    }
    public void ResetPlayerPannels() 
    {
        winPannel.SetActivePannel(false);
        loosePannel.SetActivePannel(false);
    }
}
