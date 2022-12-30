using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    private readonly float delay2Destroy = 5f;
    [SerializeField]
    private GameObject implodePlayer;

    [SerializeField]
    private Transform implodePlaerTransform;

    private Animator animator;
    public Rigidbody[] allRigidbodies;

    private void Awake()
    {
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = true;
        }
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        EventBus.eObstacleCollision.AddListener(EnableRagdoll);
        EventBus.eObstacleCollision.AddListener(EnableBackDash);
        //EnableRagdoll();
    }
    private void EnableRagdoll() 
    {
        animator.enabled = false;
        gameObject.SetActive(true);
        for (int i = 0; i < allRigidbodies.Length; i++)
        {
            allRigidbodies[i].isKinematic = false;
        }
    }
    private void EnableBackDash() 
    {
        GameObject implode = Instantiate(implodePlayer, implodePlaerTransform.position, Quaternion.identity);
        Destroy(implode, delay2Destroy);
    }
}
