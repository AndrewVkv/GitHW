using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform firePosition;
    public Transform container;
    public float bulletSpeed = 500f;

    private Inventory inventory;
    private DisplayInventory inventoryDisplay;
    
    // use event system for shot
    UnityEvent eventShot = new UnityEvent();


    private void Start()
    {
        // get references
        inventory = GetComponent<Inventory>();
        inventoryDisplay = GetComponent<DisplayInventory>();

        eventShot.AddListener(Shot);
        eventShot.AddListener(UpdateBullets);
    }
    public void CheckShoot() 
    {
        if (inventory.playerStuff.bullets > 0)
            eventShot.Invoke();
    }
    private void Shot()
    {
        Rigidbody bulletInstance = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation, container);
        bulletInstance.AddForce(firePosition.forward * bulletSpeed);
    }
    private void UpdateBullets() 
    {
        inventory.MinusBullet();
        inventoryDisplay.UpdateBullets();
    }
}
