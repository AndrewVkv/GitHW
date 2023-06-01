using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private CharacterController cc;
    [SerializeField] private float speed = 6f;
    [SerializeField] private Transform cam;
    [SerializeField] private bool canMove;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        animator = GetComponent<Animator>();
        canMove = false;
        StartCoroutine(NoMoveOnStart());
    }

    private void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0, angle, 0);

                Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                cc.Move(moveDirection.normalized * speed * Time.deltaTime);

                animator.SetFloat("Speed", 1);
            }
        }
        else
            animator.SetFloat("Speed", 0.1f);
    }

    private IEnumerator NoMoveOnStart() 
    {
        yield return new WaitForSeconds(5f);
        canMove = true;
    }
}
