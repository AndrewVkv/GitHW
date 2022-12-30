using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBlast : MonoBehaviour
{
    private readonly string message = "ExplosionContainer reference does not exist";
    private readonly float dealy2Destroy = 5f;
    [SerializeField]
    private int index;

    //public int get() => index;
    public int Set(int value) => index = value;

    private void Start()
    {
        if (ExplosionContainer.instance == null)
            print(message);

        index = ExplosionContainer.instance.ListCount();
        ExplosionContainer.instance.AddAtList(gameObject);

        StartCoroutine(Delay2Remove());
    }
    private IEnumerator Delay2Remove() 
    {
        yield return new WaitForSeconds(dealy2Destroy);
        ExplosionContainer.instance.RemoveAtList(index);
        ExplosionContainer.instance.SortList();
        Destroy(gameObject);
    }
}
