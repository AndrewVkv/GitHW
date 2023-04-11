using UnityEngine;

[RequireComponent(typeof(IMovement))]
public class PlayerGameInput : MonoBehaviour
{
    private GameInput gameInput;
    private Vector2 direction;

    private IWeapon weapon;
    private IMovement iMovement;

    private void Awake()
    {
        if(TryGetComponent(out IMovement iMove))
            iMovement = iMove;

        if (TryGetComponent(out Gun gun))
            weapon = gun;

        gameInput = new GameInput();
        gameInput.Enable();

        GlobalEventManager.eWin.AddListener(DisableAllInput);
    }

    private void ReadInput() 
    {
        direction = gameInput.Gameplay.Movement.ReadValue<Vector2>();

        iMovement.HorizontalMovement(direction);
    }
    private void Update()=> ReadInput();

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

    private void DisableAllInput() => gameInput.Disable();
}
