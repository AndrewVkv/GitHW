using System.Collections;
using UnityEngine;

public class CharacterSprite : MonoBehaviour, IObserver
{
    private SpriteRenderer spriteRenderer;
    private float delay2ChangeColor = 0.2f;

    private IObservable heroHealth;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        heroHealth = GetComponentInParent<IObservable>();
        if(heroHealth != null)
            heroHealth.AddObserver(this);
    }

    private IEnumerator DamageColor() 
    {        
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(delay2ChangeColor);
        spriteRenderer.color = Color.white;
        StopCoroutine(DamageColor());
    }

    public void ChangeColorOnDamage() => StartCoroutine(DamageColor());

    public void OnNotify() => ChangeColorOnDamage();
}
