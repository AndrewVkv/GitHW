using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    // animation clips names
    private readonly string errorAnimator = "Animator have not found";
    private readonly string jeftJump = "Left Jump";
    private readonly string idleToSprint = "Idle To Sprint";
    private readonly string rightTransition = "TransitionRight";
    private readonly string leftTransition = "TransitionLeft";
    private readonly string rightSide = "Right";
    private readonly string leftSide = "Left";
    private readonly string flyBool = "Fly";
    private readonly string slideBool = "Slide";
    private readonly string goBool = "Go";
    private readonly string deathBool = "Death";
    private readonly string fallingBool = "Falling";
    private readonly string stopBool = "Stop";
    private readonly float flyingTime = 0.7f;

    private Animator animator;
    private float durationTransitionLR;
    private float accelerationStartAnimDuration;
    private PSManager psManager;

    public static AnimationManager Instance;


    private void Start()
    {
        // create singletone object
        if (Instance == null)
            Instance = this;

        // get reference
        psManager = GetComponent<PSManager>();
        animator = GetComponent<Animator>();

        // check animator present
        if (animator == null)
            Debug.Log(errorAnimator);

        // get acces variables
        durationTransitionLR = GetAnimClipLength(jeftJump);
        accelerationStartAnimDuration = GetAnimClipLength(idleToSprint);
        StartCoroutine(ReadySetGo(true, RoadController.Instance.startDelay));
        RoadController.Instance.LerpSpeed(accelerationStartAnimDuration);


    }
    /// <summary>
    /// Get animation clip length
    /// </summary>
    /// <param name="clipName"></param>
    /// <returns></returns>
    private float GetAnimClipLength(string clipName)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (var item in clips)
            if (item.name == clipName)
                return item.length;
        return 0;
    }
    /// <summary>
    /// Get animation clip transition duration
    /// </summary>
    /// <returns></returns>
    public float GetAnimTransitLRDuration() => durationTransitionLR;
    /// <summary>
    /// Switch Anim depends on side
    /// </summary>
    /// <param name="animParam"></param>
    /// <param name="side"></param>
    public void TransitLR(bool animParam, string side)
    {
        if (side == rightSide)
            animator.SetBool(rightTransition, animParam);
        if (side == leftSide)
            animator.SetBool(leftTransition, animParam);
    }
    /// <summary>
    /// Acivate fly anim
    /// </summary>
    /// <param name="permissionToFly"></param>
    public void FlyJump(bool permissionToFly)
    {
        animator.SetBool(flyBool, permissionToFly);
        StartCoroutine(CheckLanding());
        psManager.PlayJetPS();
    }
    /// <summary>
    /// Check landing after fly
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckLanding()
    {
        yield return new WaitForSeconds(flyingTime);

        psManager.StopJetPS();
        animator.SetBool(flyBool, false);
    }
    /// <summary>
    /// Start slide anim
    /// </summary>
    /// <param name="permissionToSlide"></param>
    public void Slide(bool permissionToSlide)
    {
        animator.SetBool(slideBool, permissionToSlide);
    }
    /// <summary>
    /// Delay at start
    /// </summary>
    /// <param name="go"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator ReadySetGo(bool go, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool(goBool, go);
    }
    /// <summary>
    /// Obstacle collision routine
    /// </summary>
    public void ObstacleDeath()
    {
        animator.SetBool(goBool, false);
        animator.SetBool(flyBool, false);
        animator.SetBool(slideBool, false);
        animator.SetBool(rightTransition, false);
        animator.SetBool(leftTransition, false);
        animator.SetBool(deathBool, true);
    }
    /// <summary>
    /// Falling anim
    /// </summary>
    public void StartFallingAnim() 
    {
        animator.SetBool(fallingBool, true);
    }
    /// <summary>
    /// Finish anim
    /// </summary>
    public void FinishAnim() 
    {
        animator.SetBool(stopBool, true);
    }
}
