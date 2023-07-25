using UnityEngine.Events;

public static class EventBus 
{
    public static UnityEvent<bool> eLose = new UnityEvent<bool>();
    public static UnityEvent<bool> eWin = new UnityEvent<bool>();

    public static void RiseEvLose() => eLose.Invoke(true);
    public static void RiseEvWin() => eWin.Invoke(true);
}
