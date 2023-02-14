using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private readonly float delay = 0.75f;

    public ParticleSystem blastPS;
    public ParticleSystem scullPS;

    private void OnTriggerEnter(Collider other)
    {
        Hero hero = other.GetComponent<Hero>();
        if (hero != null)
        {
            var collidePlayerBlastAnim = Instantiate(blastPS, hero.transform.position, Quaternion.identity);

            hero.CollideObstacle();

            StartCoroutine(PSStartDelay(hero));
        }
    }

    private IEnumerator PSStartDelay(Hero hero) 
    {
        yield return new WaitForSeconds(delay);
        var psPosirion = hero.GetGFX().GetCapTransform();
        var collideHeroScullAnim = Instantiate(scullPS, hero.transform.position, Quaternion.identity, psPosirion);
    }
}
