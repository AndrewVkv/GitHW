using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    private readonly float timerValue = 60f;
    private Text timerField;
    private float deadLineTime;

    private void Start()
    {
        deadLineTime = timerValue;

        timerField = GetComponentInChildren<Text>();
        if (timerField == null)
            throw new Exception($"There is no Text component in child:  { gameObject.name }");
    }
    public void StartTimer(LockManager lockState) 
    {
        if (deadLineTime > 0)
            deadLineTime -= Time.deltaTime;
        else
        {
            deadLineTime = 0;
            lockState.TimeIsOver();
        }    

        double roundTimerField = Math.Round(deadLineTime, 0);
        timerField.text = roundTimerField.ToString();
    }

    public void ResetTimer() => deadLineTime = timerValue;
}
