using UnityEngine;


public class MovementHandler : MonoBehaviour
{
    private const string NOINPUTHANDLER = "Input Handler is null";
    private const string NOBALL = "Ball is null";

     private InputHandler inputHandler;
     private Ball ball;
    private float ballSpeed = 0.75f;

    private delegate void MoveDelegate();
    private MoveDelegate MoveD;


    private void Start()
    {
        ball = FindObjectOfType<Ball>();
        if (ball == null)
            Debug.LogError(NOBALL);

        inputHandler = FindObjectOfType<InputHandler>();
        if (inputHandler == null)
            Debug.LogError(NOINPUTHANDLER);

        MoveD += MoveBall;
        EventBus.eLose.AddListener(UnsubscribeMoveBall);
        EventBus.eWin.AddListener(UnsubscribeMoveBall);
    }

    private void MoveBall() 
    {
        if (inputHandler.isThereTouchOnScreen()) 
        {
            Vector2 currentDeltaPosition = inputHandler.GetTouchDeltaPosition().normalized;
            currentDeltaPosition *= ballSpeed;
            //Vector3 newGravity = new Vector3(currentDeltaPosition.x, Physics.gravity.y, currentDeltaPosition.y);
            //Physics.gravity = newGravity;

            Vector3 forceDirection = new Vector3(currentDeltaPosition.x, 0f, currentDeltaPosition.y);
            ball.GetComponent<Rigidbody>().AddForce(forceDirection, ForceMode.Impulse);

        }
    }

    private void Update() 
    {
        if (MoveD != null)
            MoveD();
    }

    private void UnsubscribeMoveBall(bool k) => MoveD -= MoveBall;
}
