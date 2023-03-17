using UnityEngine;

public class WheelRear : MonoBehaviour
{
    public WheelJoint2D wheelRear;

    private void Awake()
    {
        if (TryGetComponent(out WheelJoint2D wheel))
            wheelRear = wheel;
    }

    private void SetSpeed(float speed) 
    {
        var motor = wheelRear.motor;
        motor.motorSpeed = speed;
        wheelRear.motor = motor;
    }

    public void SetRearWheelSpeed(float speed) => SetSpeed(speed);
}
