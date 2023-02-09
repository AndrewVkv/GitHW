using UnityEngine;
using System;

public class HeroInput : MonoBehaviour,IWin
{
    private GameInput gameInput;
    private Movement movement;
    private HeroCollision heroCollision;
    public GameHandler gameHandler;

    private void Awake()
    {
        gameInput = new GameInput();
        gameInput.Enable();
    }
    private void Start()
    {
        movement = GetComponentInParent<GameHandler>().GetMovement();

        if (movement == null)
            throw new Exception($"There is no GameHandler component in {gameObject.name}");

        heroCollision = GetComponentInParent<GameHandler>().GetHeroCollision();
        gameHandler = GetComponentInParent<GameHandler>();
        gameHandler.GetWinEv().AddWinEv(this);
    }

    private void Update() => ReadInput();

    private void OnEnable()
    {
        gameInput.GamePlay.Jump.performed += JumpPerformed;
        gameInput.GamePlay.OpenDoor.performed += OpenDoorPerformed;
        gameInput.GamePlay.OpenDridge.performed += OpenDridgePerformed;
    }

    private void OnDisable()
    {
        gameInput.GamePlay.Jump.performed -= JumpPerformed;
        gameInput.GamePlay.OpenDoor.performed -= OpenDoorPerformed;
        gameInput.GamePlay.OpenDridge.performed -= OpenDridgePerformed;
    }

    private void OpenDridgePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => heroCollision.OpenBridge();

    private void OpenDoorPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => heroCollision.OpenDoor();

    private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => movement.Jump();

    private void ReadInput()
    {
        var inputDirection = gameInput.GamePlay.Movement.ReadValue<Vector2>();
        var direction = new Vector3(inputDirection.x, 0f, inputDirection.y);

        movement.Move(direction);
    }

    private void DisableGameInput() => gameInput.Disable();
    public void OnWinNotify()=> DisableGameInput();
}


