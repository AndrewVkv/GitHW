using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private readonly float angle = 0.5f;
    private readonly float delay = 0.75f;
    private DeathFactory deathFactory;
    private KickFactory kickFactory;

    private void Start()
    {
        if (TryGetComponent(out DeathFactory _deathFactory))
            deathFactory = _deathFactory;

        if (TryGetComponent(out KickFactory _kickFactory))
            kickFactory = _kickFactory;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Hero hero))
        {
            GlobalEventManager.RiseEvDeathHero();

            kickFactory.CreatePS(hero.transform.position, hero.transform.GetChild(1));
            StartCoroutine(Delay2CreatePS(hero, delay));
        }
    }

    private IEnumerator Delay2CreatePS(Hero hero, float delay) 
    {
        yield return new WaitForSeconds(delay);
        deathFactory.CreatePS(hero.transform.position, hero.transform.GetChild(1));
    }

    private void Update()
    {
        Quaternion RotationY = Quaternion.AngleAxis(angle, Vector3.up);
        transform.localRotation *= RotationY;
    }
}
