using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSManager : MonoBehaviour
{
    // for left & right Jet leg
    private LeftLegPS psLeftLeg;
    private RightLegPS psRightLeg;

    private void Awake()
    {
        // get reference
        psLeftLeg = GetComponentInChildren<LeftLegPS>();
        psRightLeg = GetComponentInChildren<RightLegPS>();
    }
    public void PlayJetPS() 
    {
        psLeftLeg.Play();
        psRightLeg.Play();
    }
    public void StopJetPS() 
    {
        psLeftLeg.Stop();
        psRightLeg.Stop();
    }


}
