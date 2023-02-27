using UnityEngine;

public class HeroInput : MonoBehaviour
{
    private GameInput gameInput;
    private IMove iMove;
    private Hero hero;
    private bool readMovement;

    private void Awake()
    {
        readMovement = true;

        if(TryGetComponent(out IMove move))
            iMove = move;

        if (TryGetComponent(out Hero h))
            hero = h;

        gameInput = new GameInput();
        gameInput.Enable();

        GlobalEventManager.OnHeroDeath.AddListener(OnDisable);
        GlobalEventManager.OnHeroFalling.AddListener(OnDisable);
        GlobalEventManager.OnHeroFinish.AddListener(OnDisable);
    }

    private void Update() => ReadInput();

    private void OnEnable() 
    {
        gameInput.GamePlay.Jump.performed += JumpPerformed;
        readMovement = true;
    }

    private void DoorePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        hero.Key = true;
    }

    private void OnDisable()
    {
        gameInput.GamePlay.Jump.performed -= JumpPerformed;
        readMovement =false;
    }

    private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => iMove.Jump();


    private void ReadInput() 
    {
        if (readMovement)
        {
            var input = gameInput.GamePlay.Movement.ReadValue<Vector2>();
            var direction = new Vector3(input.x, 0f, input.y).normalized;

            iMove.Move(direction);
        }
    }

    public void SubscribeDoorInput() 
    {
        gameInput.GamePlay.Doore.performed += DoorePerformed;
    }
    public void UnsubscribeDoorInput()
    {
        gameInput.GamePlay.Doore.performed -= DoorePerformed;
    }
}
