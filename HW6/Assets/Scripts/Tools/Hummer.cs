using UnityEngine;

public class Hummer : MonoBehaviour, ITool
{
    private int pinA = -1;
    private int pinB = 2;
    private int pinC = -1;

    public void Use(IPin pin1, IPin pin2, IPin pin3)
    {
        pin1.SetPin(pinA);
        pin2.SetPin(pinB);
        pin3.SetPin(pinC);
    }
}
