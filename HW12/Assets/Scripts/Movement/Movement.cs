using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour, IMovement, IWin
{
    private Rigidbody heroRB;
    private readonly float speed = 1.25f;
    private readonly float jumpHeigh = 6.5f;
    private GameHandler gameHandler;

    private bool grounded = false;
    public LayerMask layerMask;

    public GameHandler GetGameHandler() => gameHandler;

    private void Start()
    {
        heroRB = GetComponent<Rigidbody>();
        gameHandler = GetComponentInParent<GameHandler>();
        gameHandler.GetWinEv().AddWinEv(this);
        StartCoroutine(CheckYPosition());
    }
    private void Update()
    {
        grounded = Physics.CheckSphere(transform.position, Consts.RADIUS, layerMask);
    }
    public void Jump()
    {
        if (grounded)
            heroRB.AddForce(Vector3.up * jumpHeigh, ForceMode.Impulse);
    }

    public void Move(Vector3 direction) => heroRB.AddForce(direction * speed);

    private IEnumerator CheckYPosition()
    {
        bool condition = true;
        while (condition)
        {
            yield return new WaitForSeconds(1f);
            if (transform.position.y < 0f)
            {
                gameHandler.GetLooseEv().Notify();
                condition = false;
            }
        }
    }

    private void RBKinematic() => heroRB.isKinematic = true;
    public void OnWinNotify() => RBKinematic();
}


