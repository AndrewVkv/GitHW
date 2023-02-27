using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPannel : PannelsUI
{    
    private void Start()
    {
        OnDisable();
        GlobalEventManager.OnHeroFinish.AddListener(OnEnable);
    }



}
