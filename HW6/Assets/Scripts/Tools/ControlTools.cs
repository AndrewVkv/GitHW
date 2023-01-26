using UnityEngine;
using System;

public class ControlTools : MonoBehaviour
{
    private Drill drill;
    private Hummer hummer;
    private MasterKey masterKey;

    public Drill Drill => drill;
    public Hummer Hummer => hummer;
    public MasterKey MasterKey => masterKey;

    private void Start() => GetComponents();
    public bool WinPinsChecker(IPin pin1, IPin pin2, IPin pin3)
    {
        bool lockOpen = (pin1.GetPinValue() == pin2.GetPinValue() && pin2.GetPinValue() == pin3.GetPinValue());
        return lockOpen;
    }
    public bool LoosePinsChecker(IPin pin1, IPin pin2, IPin pin3)
    {
        bool lockAlarm = (pin1.GetPinValue() < 0 || pin2.GetPinValue() < 0 || pin3.GetPinValue() < 0);
        return lockAlarm;
    }

    private void GetComponents() 
    {
        drill = GetComponentInChildren<Drill>();
        if (drill == null)
            throw new Exception("There is no Pin1 component in children");

        hummer = GetComponentInChildren<Hummer>();
        if (hummer == null)
            throw new Exception("There is no Pin1 component in children");

        masterKey = GetComponentInChildren<MasterKey>();
        if (masterKey == null)
            throw new Exception("There is no Pin1 component in children");
    }
}
