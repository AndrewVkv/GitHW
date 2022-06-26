using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    // references to PlayerInput.cs & Actions
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMover pMover;
    private Shoot pShoot;

    void Awake()
    {
        Instance = this;

        // new instance of PlayerInput class
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        pMover = GetComponent<PlayerMover>();
        pShoot = GetComponent<Shoot>();

        // subscribe events
        onFoot.LeftMove.performed += ctx => pMover.MoveLeft();
        onFoot.RightMove.performed += ctx => pMover.MoveRight();
        onFoot.Jump.performed += ctx => pMover.Jump();
        onFoot.Roll.performed += ctx => pMover.StartSlide();
        onFoot.Fire.performed += ctx => pShoot.CheckShoot();
        onFoot.Esc.performed += ctx => EscOn();

    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
    /// <summary>
    /// Pause on Esc
    /// </summary>
    private void EscOn() 
    {
        GamePannels.instance.PauseOnClick();
        onFoot.Disable();
    }
    public void EscOff()
    {
        onFoot.Enable();
    }
    public void WinLoosePannelsOn()
    {
        onFoot.Disable();
    }
}
