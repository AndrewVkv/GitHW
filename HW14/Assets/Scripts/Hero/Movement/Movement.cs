using UnityEngine;

public class Movement : MonoBehaviour, IMove
{
    private readonly float blindVector3Magnitude = 0.1f;

    private CharacterController cController;
    private Transform cam;

    private float speed = 6f;
    private float jumpHeigh = 3f;
    private float gravity = -30f;
    private Vector3 velocity;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        if(TryGetComponent(out CharacterController cc))
            cController = cc;

        cam = Camera.main.transform;
    }
    private void Start() => GlobalEventManager.OnHeroDeath.AddListener(DisableCC);
    private void Update() => FallingCheck();

    public void Jump() 
    {
        if (cController.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeigh * -2 * gravity);
    }

    public void Move(Vector3 direction) 
    {
        if (direction.magnitude >= blindVector3Magnitude)
        { 
            // Rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);

            // Move
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            cController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Use Gravity
        velocity.y += gravity * Time.deltaTime;
        cController.Move(velocity * Time.deltaTime);

        if (cController.isGrounded && velocity.y < 0)
            velocity.y = -2f;

    }

    private void FallingCheck() 
    {
        if (velocity.y < gravity)
            GlobalEventManager.RiseEvFallingHero();
    }

    private void DisableCC()=> cController.enabled = false;
}
