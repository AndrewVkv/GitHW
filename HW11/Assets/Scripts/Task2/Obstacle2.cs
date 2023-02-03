using UnityEngine;
using System;
using System.Collections;

public class Obstacle2 : MonoBehaviour
{
    private readonly string[] Animations = { "O2RotationUp", "O2RotationUpDown", "O2RotationDown" };
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
