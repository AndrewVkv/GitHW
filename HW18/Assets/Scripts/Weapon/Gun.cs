using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private bool canShoot = true;
    private float speed = 10;
    private int xDirection;
    private float delay2Shoot = 0.25f;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootTransform;
    private BulletContainer bulletContainer;

    private void Awake()
    {
        bulletContainer = FindObjectOfType<BulletContainer>();
    }
    public void Shoot()
    {
        if (canShoot && bulletContainer != null)
        {
            xDirection = GetDirection2Shoot();

            GameObject bullet = Instantiate(projectile, shootTransform.position, Quaternion.identity, bulletContainer.transform);
            Rigidbody2D projectileRB = bullet.GetComponent<Rigidbody2D>();

            projectileRB.velocity = new Vector2(speed * xDirection, projectileRB.velocity.y);

            StartCoroutine(Reload(delay2Shoot));
        }
    }

    public int GetDirection2Shoot() 
    {
        int direction = 1;
        bool rightDirection = true;

        if (TryGetComponent(out IMovement iMovement))
            rightDirection = iMovement.GetRightFace();

        direction = rightDirection ? 1 : -1;

        return direction;
    }

    private IEnumerator Reload(float delay) 
    {
        canShoot = !canShoot;
        yield return new WaitForSeconds(delay);
        canShoot = !canShoot;
    }
}
