using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGem : MonoBehaviour
{
    [SerializeField] private ParticleSystem gemPS;
    private ContainerPS contanerPS;

    private void Awake() => contanerPS = FindObjectOfType<ContainerPS>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Inventory inv)) 
        {
            GlobalEventManager.RiseEvWin();
            InstallGemPS();
            GlobalEventManager.RiseEvGemCollected();
            Destroy(gameObject);
        }
    }

    private void InstallGemPS()
    {
        Vector3 position = gameObject.transform.position;
        ParticleSystem ps = Instantiate(gemPS, position, Quaternion.identity, contanerPS.transform);
    }
}
