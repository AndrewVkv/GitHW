using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private bool dooreKey = false;

    public bool Key { get { return dooreKey; } set { dooreKey = value; } }

}
