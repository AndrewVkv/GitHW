using UnityEngine;

public class HeroAnim : MonoBehaviour
{
    private readonly string MOVE_X = "moveX";
    private readonly string GROUNDED = "grounded";

    [SerializeField] private Animator animator;


    private void Awake()
    {
        if(TryGetComponent(out Animator anim))
            animator = anim;
    }
    
    public void WalkAnim(float value) => animator.SetFloat(MOVE_X, value);

    public void JumpAnim(bool value) => animator.SetBool(GROUNDED, value);
}
