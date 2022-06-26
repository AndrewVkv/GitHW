using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinArrows : MonoBehaviour
{
    [Header("Частота")]
    public float frequency = 1f;

    [Header("Амплитуда")]
    public Vector3 amplitudeVector = new Vector3(0f, 1f, 0f);
    private Vector3 originalPosition;

    private void Start()
    {
        // remember start position
        originalPosition = transform.localPosition;
    }
    private void Update()
    {
        // move Sin
        float sinFunction = Mathf.Sin(frequency * 2f * Mathf.PI * Time.time);
        Vector3 offset = amplitudeVector * sinFunction;
        transform.localPosition = originalPosition + offset;
    }
}
