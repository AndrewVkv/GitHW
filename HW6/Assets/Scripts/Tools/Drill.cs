using UnityEngine;

public class Drill : MonoBehaviour, ITool
{
    private int pinA = 1;
    private int pinB = -1;
    private int pinC = 0;

    public void Use(IPin pin1, IPin pin2, IPin pin3)
    {
        pin1.SetPin(pinA);
        pin2.SetPin(pinB);
        pin3.SetPin(pinC);
    }
}
