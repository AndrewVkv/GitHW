using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionContainer : MonoBehaviour
{
    public static Transform explosionContainerTransform;

    private void Start()
    {
        explosionContainerTransform = transform;
    }
}
