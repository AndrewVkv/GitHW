using UnityEngine;

public class JumpButton : MonoBehaviour
{
    private IMovement movement;
    private bool allow;

    private void Awake()
    {
        movement = FindObjectOfType<Movement>();
        allow = true;

        GlobalEventManager.eOpenSceneStarted.AddListener(NoJump);
        GlobalEventManager.eOpenSceneFinished.AddListener(CanJump);
    }
    public void JumpB()
    {
        if (allow)
            movement.Jump();
    }

    private void NoJump()=> allow = false;
    private void CanJump() => allow = true;
}
