using UnityEngine;
using System.Collections;

public enum playerMoveConditions { running, transitionSide, jumping, rolling}
public enum playerStatus { alive, dead, falling }
public class PLayerMove : MonoBehaviour
{
    public playerMoveConditions pCondition = playerMoveConditions.running;
    public playerStatus pStatus = playerStatus.alive;
    private readonly float distanceInPercentes = 0.1f;
    private readonly float groundCheckRadius = 0.1f;
    private readonly float rollAnimDuration = 0.75f;

    private CharacterController cController;
    private readonly float heightMultiplyer = 1.5f;
    private float gravity = -50f;
    private Vector3 velocity;
    private float distanceToMoveLR = 2f;
    [SerializeField] private float transitionLRTime = 0.5f;
    private float currentDistance = 0f;
    private float direction = 0;
    private float speedSmoothTime = 0.01f;
    private float speedSmoothVelocity;
    private float currentSpeed;

    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpHeigh = 3f;
    [SerializeField] private bool isRolling = false;

    private SidePlayer sidePlayer;
    private InputAcces inputAcces;

    private void Awake()
    {
        cController = GetComponent<CharacterController>();
        sidePlayer = GetComponent<SidePlayer>();
        inputAcces = GetComponent<InputAcces>();
    }
    private void Start()
    {
        StartCoroutine(CheckPlayerFalling(1f));
        EventBus.eObstacleCollision.AddListener(PlayerDeadStatus);
        EventBus.eFalling.AddListener(PlayerFallingStatus);
    }
    private void FixedUpdate()
    {
        UseGravity();
        PlayerMove();
    }
    private void UseGravity()
    {
        if (pStatus != playerStatus.dead)
        {
            isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);

            // use velocity on the ground only
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0;
            }
            else
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }
            cController.Move(velocity * Time.fixedDeltaTime);
        }
    }
    private void PlayerMove()
    {
        bool dead = pStatus.Equals(playerStatus.dead);
        bool falling = pStatus.Equals(playerStatus.falling);
        if (!dead && !falling)
        {
            float speed;
            if (currentDistance <= 0)
            {
                if (isRolling)
                    pCondition = playerMoveConditions.rolling;
                if (isGrounded && ! isRolling)
                    pCondition = playerMoveConditions.running;
                if (!isGrounded && ! isRolling)
                    pCondition = playerMoveConditions.jumping;
                inputAcces.OnEnableOnFoot();
                return;
            }
            else
            {
                pCondition = playerMoveConditions.transitionSide;
                inputAcces.OnDisableOnFoot();
            }


            // speed equal total distance divide totlat time transition
            speed = distanceToMoveLR / transitionLRTime;
            currentSpeed = speed;

            // smooth speed at the end transition
            if (currentDistance < distanceInPercentes * distanceToMoveLR)
            {
                currentSpeed = Mathf.SmoothDamp(currentSpeed, 0, ref speedSmoothVelocity, speedSmoothTime);
                sidePlayer.SideCheck(distanceToMoveLR);
            }

            // one frame distance
            float tempDistance = currentSpeed * Time.fixedDeltaTime;

            // total player move LR
            cController.Move(Vector3.right * direction * tempDistance);
            currentDistance -= tempDistance;
        }
    }
    public void MoveLeft()
    {
        // condition to move left 
        if (sidePlayer.side != SIDE.left)
        {
            sidePlayer.SideCheck(distanceToMoveLR);
            direction = Vector3.left.x;
            currentDistance = distanceToMoveLR;
            if (PlayerAnim.animInstance != null && isGrounded && !isRolling)
                PlayerAnim.animInstance.LeftShift();
        }
    }
    public void MoveRight()
    {
        // condition to move right 
        if (sidePlayer.side != SIDE.right)
        {
            sidePlayer.SideCheck(distanceToMoveLR);
            direction = Vector3.right.x;
            currentDistance = distanceToMoveLR;
            if (PlayerAnim.animInstance != null && isGrounded && !isRolling)
                PlayerAnim.animInstance.RightShift();
        }
    }
    public void Jump()
    {
        if (isGrounded && pCondition == playerMoveConditions.running)
        {
            velocity.y += Mathf.Sqrt(jumpHeigh * -2 * gravity);
            PlayerAnim.animInstance.Jump();
        }
    }
    public void Roll()
    {
        // Roll physics ...

        if (PlayerAnim.animInstance != null && isGrounded)
        {
            StartCoroutine(RollPerfomance(rollAnimDuration));
            PlayerAnim.animInstance.Roll();
        }
    }
    private IEnumerator RollPerfomance(float duration)
    {
        float cControllerHeigh = cController.height;
        Vector3 cControllerCenter = cController.center;

        cController.height = cControllerHeigh / heightMultiplyer;
        cController.center = cControllerCenter / heightMultiplyer;
        isRolling = true;

        yield return new WaitForSeconds(duration);
        cController.height = cControllerHeigh;
        cController.center = cControllerCenter;
        isRolling = false;
    }
    private void isPlayerFalling()
    {
        if (transform.position.y < -1)
        {
            EventBus.eFalling.Invoke();
        }
    }
    private IEnumerator CheckPlayerFalling(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            isPlayerFalling();
        }
    }
    private void PlayerDeadStatus()
    {
        pStatus = playerStatus.dead;
    }
    private void PlayerFallingStatus()
    {
        pStatus = playerStatus.falling;
    }
}

