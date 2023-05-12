using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] private List<GameObject> weaponsList = new List<GameObject>();
    private int currentIndex;

    private void Start()
    {
        foreach (GameObject item in weaponsList)
            item.SetActive(false);

        currentIndex = 0;
        weaponsList[currentIndex].SetActive(true);
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0)
        {
            weaponsList[currentIndex].SetActive(false);
            currentIndex++;

            if (currentIndex >= weaponsList.Count)
                currentIndex = 0;

            weaponsList[currentIndex].SetActive(true);
        }
        else if (scroll < 0) 
        {
            weaponsList[currentIndex].SetActive(false);
            currentIndex--;

            if (currentIndex < 0)
                currentIndex = weaponsList.Count - 1;

            weaponsList[currentIndex].SetActive(true);
        }
    }
}
