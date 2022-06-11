using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// side enumeration
public enum SIDE {Left, Mid, Right }
public class SideManager : MonoBehaviour
{
    public SIDE side = SIDE.Mid;
    private PlayerMover pMover;
    private Vector3 startPos;
    private void Start()
    {
        // get reference
        pMover = GetComponent<PlayerMover>();
        startPos = transform.position;
    }

    /// <summary>
    /// Choose enum depends on player X position
    /// </summary>
    public void CheckSide() 
    {
        if (transform.position.x < startPos.x + pMover.lineOffset / 2 && transform.position.x > startPos.x - pMover.lineOffset / 2)
            side = SIDE.Mid;
        if (transform.position.x < startPos.x - pMover.lineOffset / 2 && transform.position.x > startPos.x - pMover.lineOffset - pMover.lineOffset / 2)
            side = SIDE.Left;
        if (transform.position.x > startPos.x + pMover.lineOffset / 2 && transform.position.x < startPos.x + pMover.lineOffset + pMover.lineOffset / 2)
            side = SIDE.Right;
    }

}
