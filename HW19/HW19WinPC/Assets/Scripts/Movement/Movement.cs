using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour, IMovement, IObserver
{
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private CapsuleCollider2D capsuleCollider;

    public bool faceRight { get; private set; }
    private IObservable observableHero;

    private readonly float radiusGroundCheck = 0.1f;
    private readonly float jumpForce = 13f;
    private readonly float speed = 6f;
    private bool grounded = false;

    private HeroAnim heroAnim;
    private Rigidbody2D rb2D;
    private GroundCheck groundCheck;
    private float turnSmoothTime = 0.15f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        // Hero Start Position
        HeroStartAndSavePosition();


        if (TryGetComponent(out Rigidbody2D rb))
            rb2D = rb;

        if (TryGetComponent(out IObservable ob))
            observableHero = ob;

        if (TryGetComponent(out CapsuleCollider2D capsule))
            capsuleCollider = capsule;

        groundCheck = GetComponentInChildren<GroundCheck>();
        heroAnim = GetComponentInChildren<HeroAnim>();

        faceRight = true;
        observableHero.AddObserver(this);

        GlobalEventManager.eDeadHero.AddListener(DisableCollider);
    }

    public void HorizontalMovement(Vector2 direction)
    {
        // Physics
        if (Mathf.Abs(direction.x) >= 0)
        {
            float smoothSpeed = Mathf.SmoothDamp(Mathf.Abs(rb2D.velocity.x), speed, ref turnSmoothVelocity, turnSmoothTime);
            rb2D.velocity = new Vector2(direction.x * smoothSpeed, rb2D.velocity.y);

            ReflectCharacter(direction);

            // Animation
            heroAnim.WalkAnim(Mathf.Abs(direction.x));
        }
    }

    private void FixedUpdate() => GroundCheck();

    private void GroundCheck()
    {
        var groundCheckPosition = groundCheck.transform.position;
        grounded = Physics2D.OverlapCircle(groundCheckPosition, radiusGroundCheck, groundLayerMask);

        //Animation
        heroAnim.JumpAnim(grounded);
    }

    public void Jump()
    {
        if (grounded)
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
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

    private void GetDamageMovement() => rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);

    public void OnNotify() => GetDamageMovement();

    public void DisableCollider() => capsuleCollider.enabled = false;

    private void HeroStartAndSavePosition()
    {
        if (!PlayerPrefs.HasKey(Const.XPOSITION)) 
        {
            PlayerPrefs.SetFloat(Const.XPOSITION, 0f);
            PlayerPrefs.SetFloat(Const.YPOSITION, 1f);
            transform.position = Vector3.up;
        }
        else
        {
            float xPos = PlayerPrefs.GetFloat(Const.XPOSITION);
            float yPos = PlayerPrefs.GetFloat(Const.YPOSITION);
            transform.position = new Vector3(xPos, yPos, transform.position.z);
        }
    }
}
