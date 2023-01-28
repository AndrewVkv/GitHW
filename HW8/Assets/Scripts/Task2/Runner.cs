using UnityEngine;

public class Runner : MonoBehaviour
{
    private float speed = 5f;

    public void Run(Transform target) 
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
    public void LookForward(Transform nextRunner) 
    {
        transform.LookAt(nextRunner);
    }
}
