using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform firePosition;
    public Transform bulletContainer;
    public float bulletSpeed = 500f;

    [SerializeField]
    private bool permissionToShoot = false;


    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    public void CheckAndShoot()
    {
        if (inventory.GetBullets() > 0 && permissionToShoot)
        {
            Shot();
            inventory.SubtractBullet();
            DisplayInventory.Instance.UpdateBulletText();
            print("shoot");
        }

    }
    private void Shot()
    {
        Rigidbody newBullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation, bulletContainer);
        newBullet.AddForce(firePosition.forward * bulletSpeed);
    }
}
