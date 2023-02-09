using System.Collections.Generic;
using UnityEngine;

public class Loose : MonoBehaviour
{
    private List<IObserver> LooseList = new List<IObserver>();

    public void AddEv(IObserver objct) => LooseList.Add(objct);
    public void RemoveEv(IObserver objct) => LooseList.Remove(objct);
    public void Notify()
    {
        foreach (var obj in LooseList)
            obj.OnLooseNotify();
    }
}
