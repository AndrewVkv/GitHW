using UnityEngine;

public class Truck : MonoBehaviour
{
    private WheelFront wheelFront;
    private WheelRear wheelRear;

    private float speed = -200f;

    private void Awake()
    {
        wheelFront = GetComponentInChildren<WheelFront>();
        wheelRear = GetComponentInChildren<WheelRear>();
    }

    public void GoTruck() 
    {
        wheelFront.SeFrontWheelSpeed(speed);
        wheelRear.SetRearWheelSpeed(speed);
    }
    public void StopTruck() 
    {
        wheelFront.SeFrontWheelSpeed(0f);
        wheelRear.SetRearWheelSpeed(0f);
    }

}
