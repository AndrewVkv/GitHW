using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonCamFly : MonoBehaviour
{
    // cam position constants
    private readonly Vector2 startCamPos = new Vector2(180, 0.1f);
    private readonly Vector2 deadCamPos = new Vector2(90, 1f);
    private readonly Vector2 finishCamPos = new Vector2(0, 0.1f);
    private readonly int camDownDuration = 3;
    private readonly float delayCamFlayFinish = 1;

    private CinemachineFreeLook cMachine;
    [SerializeField]
    AnimationCurve curve;
 
    private Vector2 normalCamPos;

    public static ThirdPersonCamFly Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;

        // get reference CMachine & set values
        cMachine = GetComponent<CinemachineFreeLook>();
        normalCamPos.y = cMachine.m_YAxis.Value;
        normalCamPos.x = cMachine.m_XAxis.Value;

        cMachine.m_YAxis.Value = startCamPos.y;
        cMachine.m_XAxis.Value = startCamPos.x;
        StartCoroutine(FlyCamOnStart());
    }
    private IEnumerator FlyCamOnStart() 
    {
        float time = 0;
        float percentageComplete = 0;

        // use lerp for non lineary move
        while (time < camDownDuration)
        {
            percentageComplete = time / camDownDuration;
            cMachine.m_YAxis.Value = Mathf.Lerp(startCamPos.y, normalCamPos.y, curve.Evaluate(percentageComplete));
            cMachine.m_XAxis.Value = Mathf.Lerp(startCamPos.x, normalCamPos.x, curve.Evaluate(percentageComplete));
            time += Time.deltaTime;
            yield return null;
        }
        cMachine.m_YAxis.Value = normalCamPos.y;
        cMachine.m_XAxis.Value = normalCamPos.x;
    }
    private IEnumerator FlyCamDeath() 
    {
        float time = 0;
        float percentageComplete = 0;

        // use lerp for non lineary move
        while (time < camDownDuration)
        {
            percentageComplete = time / camDownDuration;
            cMachine.m_YAxis.Value = Mathf.Lerp(normalCamPos.y, deadCamPos.y, curve.Evaluate(percentageComplete));
            cMachine.m_XAxis.Value = Mathf.Lerp(normalCamPos.x, deadCamPos.x, curve.Evaluate(percentageComplete));
            time += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator FinishCamFly() 
    {
        yield return new WaitForSeconds(delayCamFlayFinish);
        float time = 0;
        float percentageComplete = 0;

        // use lerp for non lineary move
        while (time < camDownDuration)
        {
            percentageComplete = time / camDownDuration;
            cMachine.m_YAxis.Value = Mathf.Lerp(normalCamPos.y, finishCamPos.y, curve.Evaluate(percentageComplete));
            cMachine.m_XAxis.Value = Mathf.Lerp(normalCamPos.x, finishCamPos.x, curve.Evaluate(percentageComplete));
            time += Time.deltaTime;
            yield return null;
        }
    }
    public void StartFlyCamDeath() 
    {
        StartCoroutine(FlyCamDeath());
    }
    public void StartFinishCamFly() 
    {
        StartCoroutine (FinishCamFly());
    }
}
