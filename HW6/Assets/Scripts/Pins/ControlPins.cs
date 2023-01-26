using UnityEngine;
using System;

public class ControlPins : MonoBehaviour
{
    private Pin1 pin1;
    private Pin2 pin2;
    private Pin3 pin3;

    public Pin1 Pin1 => pin1;
    public Pin2 Pin2 => pin2;
    public Pin3 Pin3 => pin3;

    private void Start() => GetComponents();
    public void ResetPins() 
    {
        pin1.ResetPin();
        pin2.ResetPin();    
        pin3.ResetPin();
    }

    private void GetComponents() 
    {
        pin1 = GetComponentInChildren<Pin1>();
        if (pin1 == null)
            throw new Exception("There is no Pin1 component in children");

        pin2 = GetComponentInChildren<Pin2>();
        if (pin2 == null)
            throw new Exception("There is no Pin2 component in children");

        pin3 = GetComponentInChildren<Pin3>();
        if (pin3 == null)
            throw new Exception("There is no Pin3 component in children");
    }
}
