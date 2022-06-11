using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    // constants
    private readonly string destroyableobstacleTag = "DestroyableObstacle";
    private readonly float delayToDestroy = 2f;

    private Vector3 obstaclePosition;
    private GameObject explosionObject;

    public GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(destroyableobstacleTag)) 
        {
            obstaclePosition = other.gameObject.transform.position;
            Destroy(gameObject);
            int index = other.gameObject.GetComponent<ObstacleListIndex>().index;
            ObstacleManager.Instance.RemoveAddObstacleBulletCollision(index);
            ExplosionObstacle();
        }
    }
    /// <summary>
    /// Install explosion particle system object
    /// </summary>
    private void ExplosionObstacle() 
    {
        explosionObject = Instantiate(explosion, obstaclePosition, Quaternion.identity, ExplosionContainer.explosionContainerTransform);
        Destroy(explosionObject, delayToDestroy);
    }


}
