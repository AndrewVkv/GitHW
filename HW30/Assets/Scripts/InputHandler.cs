using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Vector2 GetTouchDeltaPosition()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).deltaPosition;
        }

        return Vector2.zero;
    }

    public bool isThereTouchOnScreen()
    {
        if (Input.touchCount > 0)
            return true;

        return false;
    }

    private void Update()
    {
        //Debug.Log(GetTouchDeltaPos() + "Delta pos");
        //Debug.Log(isThereTouchOnScreen() + "Touch");
    }
}
