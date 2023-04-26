using UnityEngine.Events;

public class GlobalEventManager 
{
    public static UnityEvent eDeadHero = new UnityEvent();
    public static UnityEvent eWin = new UnityEvent();
    public static UnityEvent eFinish = new UnityEvent();
    public static UnityEvent eSavePointOnLevel = new UnityEvent();

    public static UnityEvent eOpenSceneStarted = new UnityEvent();
    public static UnityEvent eOpenSceneFinished = new UnityEvent();


    public static UnityEvent eGunCollected = new UnityEvent();

    public static UnityEvent eBossDied = new UnityEvent();
    public static UnityEvent eGemCollected = new UnityEvent();

    public static void RiseEvDeadHero() => eDeadHero.Invoke();
    public static void RiseEvWin() => eWin.Invoke();
    public static void RiseEvFinsh() => eFinish.Invoke();

    public static void RiseEvSavePoint() => eSavePointOnLevel.Invoke();

    public static void RiseEvOpenSceneStarted() => eOpenSceneStarted.Invoke();
    public static void RiseEvOpenSceneFinished() => eOpenSceneFinished.Invoke();

    public static void RiseEvGunCollected() => eGunCollected.Invoke();

    public static void RiseEvBossDied() => eBossDied.Invoke();

    public static void RiseEvGemCollected() => eGemCollected.Invoke();
}
