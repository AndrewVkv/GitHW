using UnityEngine;

public class EnemyBossMovement : MonoBehaviour, IMovement
{
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private bool faceRight = true;
    private readonly float jumpForce = 13f;

    // Physics
    private Vector2 xDirection = Vector2.zero;
    private Rigidbody2D rb2D;
    private float speed = 1f;
    private float turnSmoothTime = 0.15f;
    private float turnSmoothVelocity;

    // Anim
    private BossAnim bossAnim;

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody2D rb))
            rb2D = rb;

        if (TryGetComponent(out CapsuleCollider2D capsule))
            capsuleCollider = capsule;

        bossAnim = GetComponentInChildren<BossAnim>();
    }

    public void HorizontalMovement(Vector2 direction)
    {
        // Physics
        float smoothSpeed = Mathf.SmoothDamp(Mathf.Abs(rb2D.velocity.x), speed, ref turnSmoothVelocity, turnSmoothTime);
        rb2D.velocity = new Vector2(direction.x * speed, rb2D.velocity.y);

        // Animation
        bossAnim.WalkAnim(Mathf.Abs(direction.x));

        ReflectCharacter(direction);
    }

    public void ReflectCharacter(Vector2 direction)
    {
        if (direction.x > 0 && !faceRight || direction.x < 0 && faceRight)
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    public bool GetRightFace() => faceRight;

    public void Jump() => rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);

    public void DisableCollider()=> capsuleCollider.enabled = false;
}
