using UnityEngine.Events;

public class GlobalEventManager 
{
    public static UnityEvent eDeadHero = new UnityEvent();
    public static UnityEvent eWin = new UnityEvent();

    public static void RiseEvDeadHero() => eDeadHero.Invoke();
    public static void RiseEvWin() => eWin.Invoke();
}
