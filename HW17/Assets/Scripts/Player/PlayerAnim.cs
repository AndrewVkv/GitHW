using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private readonly string ready = "Ready";
    private readonly string run = "Run";
    private readonly string roll = "Roll";
    private readonly string leftShift = "LeftShift";
    private readonly string rightShift = "RightShift";
    private readonly string jump = "Jump";
    private readonly string falling = "Falling";
    private readonly string finish = "Finish";

    private Animator animator;
    public static PlayerAnim animInstance { get; private set; }

    private void Awake()
    {
        if (animInstance == null)
            animInstance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        EventBus.ready.AddListener(AnimReady2Go);
        EventBus.go.AddListener(AnimRun);
        EventBus.eFalling.AddListener(AnimFalling);
        EventBus.eObstacleCollision.AddListener(DisablePLayer);
        EventBus.eWin.AddListener(Finish);
    }
    private void AnimReady2Go()
    {
        animator.SetTrigger(ready);
    }
    private void AnimRun()
    {
        animator.SetTrigger(run);
    }
    private void AnimRoll()
    {
        animator.SetTrigger(roll);
    }
    private void AnimJump()
    {
        animator.SetTrigger(jump);
    }
    private void AnimLeftShift()
    {
        animator.SetTrigger(leftShift);
    }
    private void AnimRightShift()
    {
        animator.SetTrigger(rightShift);
    }
    private void AnimFalling()
    {
        animator.SetTrigger(falling);
    }
    private void AnimFinish() 
    {
        animator.SetTrigger(finish);
    }
    public void LeftShift() => AnimLeftShift();
    public void RightShift() => AnimRightShift();
    public void Roll() => AnimRoll();
    public void Jump() => AnimJump();
    public void Finish() => AnimFinish();
    //public void Falling() => AnimFalling();

    private void DisablePLayer() 
    {
        gameObject.SetActive(false);
    }
}
