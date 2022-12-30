using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public static class EventBus 
{
    public static UnityEvent eCoinCollision = new UnityEvent();
    public static UnityEvent eObstacleCollision = new UnityEvent();
    public static UnityEvent eFalling = new UnityEvent();
    public static UnityEvent eMove = new UnityEvent();
    public static UnityEvent eWin = new UnityEvent();

    public static UnityEvent ready = new UnityEvent();
    public static UnityEvent go = new UnityEvent();
    public static UnityEvent shoot = new UnityEvent();
}
