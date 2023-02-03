using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Obstacle3 : MonoBehaviour
{
    private readonly string[] Animations = { "O3LRStrike", "O3RotationStrike", "O3CrossStrike" };
    private readonly float animDelay = 0.05f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            throw new Exception($"There is no Animator component at {gameObject.name}");
    }
    public void SwitchAnim() 
    {
        int index = UnityEngine.Random.Range(0, Animations.Length);
        animator.SetTrigger(Animations[index]);

        StartCoroutine(RstTrigger(Animations[index]));
    }
    private IEnumerator RstTrigger(string NameAnim)
    {
        yield return new WaitForSeconds(animDelay);
        animator.ResetTrigger(NameAnim);

        StopCoroutine(RstTrigger(NameAnim));
    }
}
