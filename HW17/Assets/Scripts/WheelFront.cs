using UnityEngine;

public class WheelFront : MonoBehaviour
{
    public WheelJoint2D wheelFront;

    private void Awake()
    {
        if (TryGetComponent(out WheelJoint2D wheel))
            wheelFront = wheel;
    }

    private void SetSpeed(float speed)
    {
        var motor = wheelFront.motor;
        motor.motorSpeed = speed;
        wheelFront.motor = motor;
    }

    public void SeFrontWheelSpeed(float speed) => SetSpeed(speed);
}
