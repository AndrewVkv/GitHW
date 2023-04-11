using UnityEngine;

public class Timer 
{
    private float tick = 0f;
    public bool StartT(float delay) 
    {
        if (tick < delay)
        {
            tick += Time.deltaTime;
            return false;
        }
        else 
        {
            tick = 0f;
            return true;
        }
    }

}
