using System;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent OnHeroDeath = new UnityEvent();
    public static UnityEvent OnHeroFalling = new UnityEvent();
    public static UnityEvent OnHeroFinish = new UnityEvent();
    public static UnityEvent<bool> OnDoorClue = new UnityEvent<bool>();

    public static void RiseEvDeathHero() => OnHeroDeath.Invoke();
    public static void RiseEvFallingHero() => OnHeroFalling.Invoke();
    public static void RiseEvHeroFinish() => OnHeroFinish.Invoke();

    public static void RiseEvDoorClue(bool key) => OnDoorClue.Invoke(key);
}
