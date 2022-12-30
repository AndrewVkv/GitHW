using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float Amplitude = 75f;

    public bool randomStart = false;
    private float startPhase = 0;
    private float angle;

    private void Awake()
    {
        if (randomStart)
            startPhase = Random.Range(0f, 1f);
    }

    private void Update()
    {
        angle = Amplitude * Mathf.Sin(speed * (Time.time + startPhase));
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
