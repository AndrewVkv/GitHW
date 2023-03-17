using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField]
    private SliderJoint2D sliderJoint2D;
    private float speed = -2f;

    private void Awake()
    {
        if(TryGetComponent(out SliderJoint2D sliderJoint))
            sliderJoint2D = sliderJoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            var motor = sliderJoint2D.motor;
            motor.motorSpeed = speed;
            sliderJoint2D.motor = motor;
        }
    }
}
