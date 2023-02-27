using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnim : MonoBehaviour
{
    private readonly string deathTrigger = "DeathTrigger";
    private Animator animator;


    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
        GlobalEventManager.OnHeroDeath.AddListener(HeroDeathAnim);
    }

    private void OnDisable() 
    {
        animator.enabled = false;
        GlobalEventManager.OnHeroDeath.RemoveListener(HeroDeathAnim);
    }

    private void HeroDeathAnim() => animator.SetTrigger(deathTrigger);
}
