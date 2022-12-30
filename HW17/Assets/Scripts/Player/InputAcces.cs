using UnityEngine;
//using UnityEngine.InputSystem;

public class InputAcces : MonoBehaviour
{
    // references to PlayerInput.cs & Actions
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerInput.JumpRollActions onJumpRoll;

    // references to PlayerMove.cs 
    private PLayerMove pMove;
    private Shoot pShoot;
    private void Awake()
    {
        // get acces
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onJumpRoll = playerInput.JumpRoll;
        pMove = GetComponent<PLayerMove>();
        pShoot = GetComponent<Shoot>();

        // subscribe events
        onFoot.MoveLeft.performed += ctx => pMove.MoveLeft();
        onFoot.MoveRight.performed += ctx => pMove.MoveRight();
        onFoot.Shoot.performed += ctx => pShoot.CheckAndShoot();
        onJumpRoll.Jump.performed += ctx => pMove.Jump();
        onJumpRoll.Roll.performed += ctx => pMove.Roll();
    }
    private void Start()
    {
        EventBus.eObstacleCollision.AddListener(OnDisable);
        EventBus.eFalling.AddListener(OnDisable);
    }
    private void OnEnable()
    {
        onFoot.Enable();
        onJumpRoll.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
        onJumpRoll.Disable();
    }
    public void OnEnableOnFoot() => onFoot.Enable();
    public void OnDisableOnFoot() => onFoot.Disable();

}
