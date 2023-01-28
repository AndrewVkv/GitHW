using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private bool move;

    private float speed = 5f;
    private Transform target;
    private int indexArray = 1;
    private int increment = 1;

    [SerializeField]
    private bool forward = true;

    private void Start()
    {
        transform.position = GetComponentInParent<Transform>().position;
        target = points[indexArray];
        move = true;

        transform.LookAt(target);
    }

    private void FixedUpdate()
    {
        if (move)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);


        if (transform.position == target.position)
        {
            if (forward)
                increment = 1;
            else
                increment = -1;

            if (indexArray == points.Length - 1)
            {
                forward = false;
                increment = -1;
            }


            if (indexArray == 0)
            {
                forward = true;
                increment = 1;
            }

            indexArray += increment;

            target = points[indexArray];
            transform.LookAt(target);
        }
    }
}
