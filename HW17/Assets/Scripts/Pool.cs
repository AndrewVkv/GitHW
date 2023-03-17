using System.Collections;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] water;

    private Vector3 originalScale;
    private readonly Vector3 newlScale = new Vector3(-1f, 1f, 1f);
    private readonly float delay = 0.75f;

    private void Start()
    {
        originalScale = transform.GetChild(0).localScale;
        StartCoroutine(Timer(delay));
    }

    private IEnumerator Timer(float delay)
    {
        while (true)
        {
            ChangeSpritesScale(originalScale);
            yield return new WaitForSeconds(delay);
            ChangeSpritesScale(newlScale);
            yield return new WaitForSeconds(delay);
        }
    }
    private void ChangeSpritesScale(Vector3 scale)
    {
        foreach (var sprite in water)
            sprite.transform.localScale = scale;
    }
}
