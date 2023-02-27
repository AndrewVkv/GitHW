using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform door;
    private bool dooreLock = false;
    private Vector3 startPosition;
    private Vector3 upPosition;
    private float speed = 2f;

    private void Start()
    {
        door = transform.GetChild(0);
        startPosition = door.localPosition;

       upPosition = new Vector3(startPosition.x, 4.5f, startPosition.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Hero hero))
        {
            GlobalEventManager.RiseEvDoorClue(true);

            if (hero.TryGetComponent(out HeroInput heroInput))
                heroInput.SubscribeDoorInput();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Hero hero))
        {
            if (hero.Key)
                Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Hero hero))
        {
            GlobalEventManager.RiseEvDoorClue(false);

            dooreLock = false;
            hero.Key = false;

            if (hero.TryGetComponent(out HeroInput heroInput))
                heroInput.UnsubscribeDoorInput();
        }
    }

    public void Open() => dooreLock = true;

    private void Update()
    {
        if (dooreLock)
        {
            door.localPosition = Vector3.MoveTowards(door.localPosition, upPosition, speed * Time.deltaTime);
        }
        else
            door.localPosition = Vector3.MoveTowards(door.localPosition, startPosition, speed * Time.deltaTime);
    }

}
