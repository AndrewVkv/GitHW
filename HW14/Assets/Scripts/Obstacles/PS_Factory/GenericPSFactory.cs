using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPSFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T psPrefab;

    public T CreatePS(Vector3 psPosition, Transform parent)
    {
        return Instantiate(psPrefab, psPosition, new Quaternion(0f, 0f, 0f, 0f), parent);
    }

}
