using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLegPS : MonoBehaviour, IParticleSystem
{
    private ParticleSystem psL;

    private void Start()
    {
        // get reference
        psL = GetComponent<ParticleSystem>();
        psL.Stop();
    }
    public void Play()
    {
        psL.Play();
    }
    public void Stop()
    {
        psL.Stop();
    }
}
