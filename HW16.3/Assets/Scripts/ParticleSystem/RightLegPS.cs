using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLegPS : MonoBehaviour, IParticleSystem
{
    private ParticleSystem psR;

    private void Start()
    {
        // get reference
        psR = GetComponent<ParticleSystem>();
        psR.Stop();
    }
    public void Play()
    {
        psR.Play();
    }
    public void Stop()
    {
        psR.Stop();
    }
}
