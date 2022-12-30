using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // constants
    private readonly string obstacleTag = "Obstacle";
    private readonly float delayToDestroy = 2f;
    private readonly float implodeOffset = 0.5f;

    private GameObject explosionRB;
    private GameObject explosionEffect;

    [Header("Implode Wall Effect Prefab")]
    public GameObject explosionWallEffect;

    [Header("Implode Wall Physics Prefab")]
    public GameObject explosionWallPhysics;

    [Header("Implode obstacle Prefab")]
    public GameObject explosionObstacle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag)) 
        {
            if (other.GetComponentInParent<ObstacleIndex>() != null)
            {
                int obstacleIndex = other.GetComponentInParent<ObstacleIndex>().index;
                ObstacleManager.Instance.ExternalRemoveObstacleAtList(obstacleIndex);

                Vector3 obstaclePosition = gameObject.transform.position;
                GameObject explosion2Destroy = Instantiate(explosionObstacle, obstaclePosition, Quaternion.identity, ExplosionContainer.explosionContainerTransform);
                Destroy(gameObject);
            }

        }
    }
    private void ImplodeWall(float delay, GameObject parentTransform)
    {
        Vector3 implodePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - implodeOffset);
        explosionRB = Instantiate(explosionWallPhysics, implodePosition, Quaternion.identity, parentTransform.transform);
        explosionEffect = Instantiate(explosionWallEffect, implodePosition, Quaternion.identity, parentTransform.transform);

        Destroy(gameObject);
        Destroy(explosionRB, delay);
        Destroy(explosionEffect, delay);
    }
    public void ExternalImplode(GameObject parent) 
    {
        ImplodeWall(delayToDestroy, parent);
    }
}
