using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsListAddIndex : MonoBehaviour
{
    public List<GameObject> coinsInParent = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(CheckList());
    }
    private void ListNullDestroyObject()
    {
        for (int i = 0; i < coinsInParent.Count; i++)
        {
            if (coinsInParent[i] == null)
                coinsInParent.RemoveAt(i);
        }
        if (coinsInParent.Count < 1)
            StartCoroutine(DestroyGameObject());

    }
    private IEnumerator CheckList()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ListNullDestroyObject();
        }
    }
    private IEnumerator DestroyGameObject() 
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject); ;
    }
}
