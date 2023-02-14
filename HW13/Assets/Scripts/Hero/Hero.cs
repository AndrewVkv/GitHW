using UnityEngine;

public class Hero : MonoBehaviour
{
    private HeroInput heroInput;
    private Movement movement;
    private Animator animator;
    public GFX gFX;

    public GFX GetGFX() => gFX;

    private void Start()
    {
        heroInput = GetComponent<HeroInput>();
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        gFX = GetComponentInChildren<GFX>();

        animator.enabled = false;
    }

    public void CollideObstacle()
    {
        heroInput.DisableReadInput();
        movement.OnDeath();

        animator.enabled = true;
    }
}
