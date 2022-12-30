using UnityEngine;


// side enumeration
public enum SIDE { left, mid, right, outOfRange }
public class SidePlayer : MonoBehaviour
{
    public SIDE side = SIDE.mid;

    public void SideCheck(float distance)
    {
        // -1 < transform.position.x < 1
        bool conditionMid = transform.position.x > -distance / 2 && transform.position.x < distance / 2;

        // -3 < transform.position.x < -1
        bool conditionLeft = transform.position.x > -distance - distance / 2 && transform.position.x < -distance / 2;

        // 1 < transform.position.x < 3
        bool conditionRight = transform.position.x > distance / 2 && transform.position.x < distance + distance / 2;

        // transform.position.x < -3 && transform.position.x > 3
        bool outOfRangePlayerPosition = transform.position.x < - distance - distance / 2 || transform.position.x > distance + distance / 2;

        if (conditionMid)
            side = SIDE.mid;
        if (conditionLeft)
            side = SIDE.left;
        if (conditionRight)
            side = SIDE.right;
        if (outOfRangePlayerPosition)
            side = SIDE.outOfRange;
    }
}

