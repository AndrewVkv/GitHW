using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBox : MonoBehaviour
{
    // constants
    private readonly float durationUp = 0.2f;
    private readonly float durationDown = 1f;
    private readonly float delay = 2f;

    private Vector3 downPosition = Vector3.down;
    private Vector3 upPosition = Vector3.zero;

    [SerializeField]
    AnimationCurve curveUp;
    [SerializeField]
    AnimationCurve curveDown;


    private void Start()
    {
        transform.localPosition = downPosition;
        StartCoroutine(WaitAndGo());
    }
    private IEnumerator WaitAndGo() 
    {
        yield return new WaitForSeconds(delay);
        float elapcedTime = 0;
        while (true)
        {
            // move to up position
            elapcedTime = 0;
            while (elapcedTime < durationUp)
            {
                // use lerp to non lineary move
                elapcedTime += Time.deltaTime;
                float percentageComplete = (elapcedTime / durationUp);
                transform.localPosition = Vector3.Lerp(downPosition, upPosition, curveUp.Evaluate(percentageComplete));
                yield return null;
            }
            yield return new WaitForSeconds(delay);

            // move to down position
            elapcedTime = 0;
            while (elapcedTime < durationDown)
            {
                // use lerp to non lineary move
                elapcedTime += Time.deltaTime;
                float percentageComplete = (elapcedTime / durationDown);
                transform.localPosition = Vector3.Lerp(upPosition, downPosition, curveDown.Evaluate(percentageComplete));
                yield return null;
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
