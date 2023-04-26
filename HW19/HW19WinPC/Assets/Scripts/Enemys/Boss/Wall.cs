using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void Awake() 
    {
        gameObject.SetActive(true);
        GlobalEventManager.eBossDied.AddListener(BreakWall);
    }

    private void BreakWall() => gameObject.SetActive(false);
}
