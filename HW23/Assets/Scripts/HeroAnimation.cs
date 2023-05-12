using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<AnimationClip> clips = new List<AnimationClip>();

    private void Awake()
    {
        if(TryGetComponent(out Animator an))        
            animator = an;

        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
            clips.Add(clip);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            animator.Play(clips[0].name);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            animator.Play(clips[1].name);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            animator.Play(clips[2].name);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            animator.Play(clips[3].name);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            animator.Play(clips[4].name);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            animator.Play(clips[5].name);
    }
}
