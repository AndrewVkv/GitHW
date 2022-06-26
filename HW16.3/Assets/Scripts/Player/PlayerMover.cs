using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // constants
    private readonly float transitionLRDeklay = 0.2f;
    private readonly float startDelay = 4f;
    private readonly float deathPositionY = - 0.2f;
    private readonly float heightMultiplyer = 1.5f;
    private readonly float cycleTime = 1f;

    [SerializeField]
    private AnimationCurve curve;
    private float animDurationRoll = 0.8f;
    private CharacterController cController;
    private SideManager sideManager;
    private AnimationManager animationManager;

    private Vector3 playerVelocity;
    public bool isGrounded;
    public bool inMovementLR;
    public bool inSlide;

    public float gravity = -30f;
    public float jumpHeigh = 2f;
    public float lineOffset = 2f;

    public static PlayerMover Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        // get reference
        cController = GetComponent<CharacterController>();
        sideManager = GetComponent<SideManager>();
        animationManager = GetComponent<AnimationManager>();
        StartCoroutine(NoInputOnStartDelay(startDelay));
        StartCoroutine(FallingCkech(cycleTime));
    }

    void FixedUpdate()
    {
        UseGravuty();

    }
    /// <summary>
    /// Apply gravity
    /// </summary>
    public void UseGravuty()
    {
        isGrounded = cController.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        playerVelocity.y += gravity * Time.fixedDeltaTime;
        cController.Move(playerVelocity * Time.fixedDeltaTime);
    }
    /// <summary>
    /// Jump routine
    /// </summary>
    public void Jump()
    {
        if (isGrounded && !inMovementLR && !inSlide)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeigh * -3 * gravity);
            animationManager.FlyJump(true);
            RoadController.Instance.StartChangeSpeed4Jump();
        }
    }
    /// <summary>
    /// Player left transition
    /// </summary>
    public void MoveLeft()
    {
        if (!inMovementLR && sideManager.side != SIDE.Left)
            StartCoroutine(MoveToSide(Vector3.left, "Left"));
    }
    /// <summary>
    /// Player Right transition
    /// </summary>
    public void MoveRight()
    {
        if (!inMovementLR && sideManager.side != SIDE.Right)
            StartCoroutine(MoveToSide(Vector3.right, "Right"));
    }
    /// <summary>
    /// Player slide transition
    /// </summary>
    public void StartSlide()
    {
        if (isGrounded && !inMovementLR && !inSlide)
        {
            StartCoroutine(Slide());
            RoadController.Instance.StartChangeSpeed4Slide();
        }
    }
    IEnumerator MoveToSide(Vector3 transitionToSide, string sideAnim)
    {
        animationManager.TransitLR(true, sideAnim);
        float animDuration = animationManager.GetAnimTransitLRDuration();
        float elapsedTime = 0;
        inMovementLR = true;
        sideManager.CheckSide();

        // use lerp for non lineary move
        while (elapsedTime < animDuration )
        {
            elapsedTime += Time.fixedDeltaTime;
            float percentageComplete = elapsedTime / animDuration;
            float speed = curve.Evaluate(percentageComplete);
            // lineOffset - множитель, transitionToSide - вектор перемещения, speed - скорость
            cController.Move(lineOffset * transitionToSide * speed  * Time.fixedDeltaTime);
            yield return null;
        }
        animationManager.TransitLR(false, sideAnim);
        sideManager.CheckSide();
        yield return new WaitForSeconds(transitionLRDeklay);
        inMovementLR = false;
    }

    IEnumerator Slide()
    {
        inSlide = true;
        float rollAnimDuration = animDurationRoll;
        float cControllerHeigh = cController.height;
        Vector3 cControllerCenter = cController.center;

        cController.height = cControllerHeigh / heightMultiplyer;
        cController.center = cControllerCenter / heightMultiplyer;
        animationManager.Slide(true);
        //Debug.Log("Sliding");

        yield return new WaitForSeconds(rollAnimDuration);
        animationManager.Slide(false);
        cController.height = cControllerHeigh;
        cController.center = cControllerCenter;
        inSlide = false;
    }
    private IEnumerator NoInputOnStartDelay(float delay) 
    {
        inMovementLR = true;
        yield return new WaitForSeconds(delay);
        inMovementLR = false ;
    }
    private IEnumerator FallingCkech(float delay) 
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            CheckFalling();
        }
    }
    /// <summary>
    /// Check falling by player Y value
    /// </summary>
    private void CheckFalling() 
    {
        if (transform.position.y < deathPositionY)
        {
            animationManager.StartFallingAnim();
            DisplayInventory.Instance.FallingRoutine();
            Debug.Log("Falling");
        }
    }
}
