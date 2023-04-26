using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private SliderJoint2D sliderJoint2D;
    [SerializeField] private float speed = -2f;

    private void Awake()
    {
        if(TryGetComponent(out SliderJoint2D slider))
            sliderJoint2D = slider;
    }

    public void MoveUpPlatform()
    {
        var motor = sliderJoint2D.motor;
        motor.motorSpeed = speed;
        sliderJoint2D.motor = motor;
    }
    public void MoveDownPlatform()
    {
        var motor = sliderJoint2D.motor;
        motor.motorSpeed = -speed;
        sliderJoint2D.motor = motor;
    }

    public void SetConnectedAnchor(Vector2 anchorPosition) => sliderJoint2D.connectedAnchor = anchorPosition;
}
