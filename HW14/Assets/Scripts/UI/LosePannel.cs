using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePannel : PannelsUI
{
    private void Start()
    {
        OnDisable();
        GlobalEventManager.OnHeroFalling.AddListener(OnEnable);
        GlobalEventManager.OnHeroDeath.AddListener(OnEnable);
    }

}
