using UnityEngine;

public class HeroInput : MonoBehaviour
{
    private GameInput gameInput;
    private IMove iMove;
    private bool inputKey;

    private void Awake()
    {
        inputKey = true;
        gameInput = new GameInput();
        iMove = GetComponent<IMove>();

        gameInput.Enable();
    }
    private void Update() => ReadInput();

    private void OnEnable() => gameInput.GamePlay.Jump.performed += JumpPerformed;

    private void OnDisable() => gameInput.GamePlay.Jump.performed -= JumpPerformed;

    private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => iMove.Jump();
    private void ReadInput()
    {
        if (inputKey) 
        {
            var input = gameInput.GamePlay.Movement.ReadValue<Vector2>();
            var direction = new Vector3(input.x, 0f, input.y).normalized;

            iMove.Move(direction);
        }
    }
    public void DisableReadInput()=> inputKey = false;
}
