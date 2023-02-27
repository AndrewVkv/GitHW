using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private ParticleSystem ps;

    private void Start() => ps = GetComponentInChildren<ParticleSystem>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Hero hero)) 
        {
            GlobalEventManager.RiseEvHeroFinish();
            ps.Play();
        }
    }

}
