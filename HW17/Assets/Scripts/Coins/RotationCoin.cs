using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCoin : MonoBehaviour
{
    [SerializeField] private float angle = 2f;
    private void FixedUpdate()
    {
        Quaternion rotationY = Quaternion.AngleAxis(angle, Vector3.right);
        transform.localRotation *= rotationY;
    }
}
