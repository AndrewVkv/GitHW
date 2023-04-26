using UnityEngine;

public class BossAnim : MonoBehaviour
{
    private readonly string MOVE_X = "moveX";

    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (TryGetComponent(out Animator anim))
            animator = anim;
    }

    public void WalkAnim(float value) => animator.SetFloat(MOVE_X, value);
}
