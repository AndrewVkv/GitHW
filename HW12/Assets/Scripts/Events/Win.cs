using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private List<IWin> winList = new List<IWin>();

    public void AddWinEv(IWin entity) => winList.Add(entity);
    public void RemoveWinEv(IWin entity) => winList.Remove(entity);
    public void WinNotify()
    {
        foreach (var entity in winList)
            entity.OnWinNotify();
    }
}
