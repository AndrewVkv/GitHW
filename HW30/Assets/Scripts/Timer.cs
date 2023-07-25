using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private const string ENDTIME = "Time is up";
    [SerializeField] private float timerValue = 10f;

    [SerializeField] private TextMeshProUGUI timerValueOut;


    private delegate void TimerDelegate();
    private TimerDelegate UseTimer;

    private void Start()
    {
        UseTimer += CalculateTime;
        EventBus.eWin.AddListener(UnsubscribeTimer);
        EventBus.eLose.AddListener(UnsubscribeTimer);
    }

    private void Update()
    {
        if(UseTimer != null)
            UseTimer();
    }

    private void CalculateTime() 
    {
        if (timerValue >= 0)
        {
            timerValue -= Time.deltaTime;
            string outValue = string.Format("{0:f1}", timerValue);
            timerValueOut.text = outValue;
        }
        else
        {
            timerValueOut.text = ENDTIME;
            EventBus.RiseEvLose();
        }
    }

    private void UnsubscribeTimer(bool k) => UseTimer -= CalculateTime;
}
