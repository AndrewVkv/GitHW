using UnityEngine;

[RequireComponent(typeof(IMovement))]
public class PlayerGameInput : MonoBehaviour
{
    private GameInput gameInput;
    private Vector2 direction;
    private float blindZoneJoyStick = 0.3f;
    [SerializeField] private bool joystickMoveAllow;
    [SerializeField] private Vector2 finishDirection = Vector2.right;

    public Vector2 Direction
    {
        get { return direction; }
    }

    private IWeapon weapon;
    private IMovement iMovement;

    [SerializeField] private Joystick joystick;

    private void Awake()
    {
        if (TryGetComponent(out IMovement iMove))
            iMovement = iMove;

        if (TryGetComponent(out Gun gun))
            weapon = gun;

        gameInput = new GameInput();
        gameInput.Enable();

        joystickMoveAllow = true;
        joystick = FindObjectOfType<Joystick>();


        GlobalEventManager.eFinish.AddListener(DisableAllInput);

        GlobalEventManager.eOpenSceneStarted.AddListener(DisableAllInput);
        GlobalEventManager.eOpenSceneFinished.AddListener(EnableAllInput);
    }

    private void ReadInput()
    {
        // PC Input
        //direction = gameInput.Gameplay.Movement.ReadValue<Vector2>();
        //iMovement.HorizontalMovement(direction);


        // Android JoyStick Input
        if (joystickMoveAllow) 
        {
            direction = joystick.Direction;

            if (direction.magnitude >= blindZoneJoyStick)
                direction = joystick.Direction;
            else
                direction = Vector2.zero;
        }

        iMovement.HorizontalMovement(direction);
    }
    private void Update() => ReadInput();

    private void OnEnable()
    {
        gameInput.Gameplay.Jump.performed += JumpPerformed;
        gameInput.Gameplay.Shoot.performed += Shoot_performed;
    }

    private void OnDisable()
    {
        gameInput.Gameplay.Jump.performed -= JumpPerformed;
        gameInput.Gameplay.Shoot.performed -= Shoot_performed;
    }

    private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => iMovement.Jump();

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => weapon.Shoot();

    private void DisableAllInput() 
    {
        direction = Vector2.zero;
        joystickMoveAllow = false;
        gameInput.Disable();
    }

    private void EnableAllInput() 
    {
        joystickMoveAllow = true;
        gameInput.Enable();
    }

    public void FinishMove() 
    {
        direction = finishDirection;
    }
}
