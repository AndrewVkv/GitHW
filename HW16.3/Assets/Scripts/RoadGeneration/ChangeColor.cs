using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // constants
    private readonly float changeColorDuration = 2f;
    private readonly float checkStageDelay = 1f;
    private readonly string gridColorName = "GridColor";

    public Color[] gridColor = new Color[5];

    private new Renderer renderer;
    private Color baseColor;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        baseColor = renderer.material.GetColor(gridColorName);
        renderer.material.SetColor(gridColorName, baseColor);
        StartCoroutine(CheckStage(checkStageDelay));
    }

    private IEnumerator ChangeGridColor(Color newColor) 
    {
        float elapsedTime = 0;
        float percentageComplete = 0;
        while (elapsedTime < changeColorDuration)
        {
            // use lerp to chenge color
            percentageComplete = elapsedTime / changeColorDuration;
            baseColor = Color.Lerp(baseColor, newColor, percentageComplete);
            renderer.material.SetColor(gridColorName, baseColor);

            elapsedTime += Time.deltaTime;
            yield return null;            
        }
        baseColor = newColor;
        renderer.material.SetColor(gridColorName, baseColor);
    }
    private IEnumerator CheckStage(float waitingTime) 
    {
        while (true)
        {
            yield return new WaitForSeconds(waitingTime);
            CheckStage();
        }
    }
    private void CheckStage() 
    {
        switch (Stage.instance.stage)
        {
            case STAGE.Zero:
                break;
            case STAGE.One:
                break;
            case STAGE.Two:
                // set color for stage 2
                StartCoroutine(ChangeGridColor(gridColor[0]));
                DisplayInventory.Instance.UpdateLevelText(2);
                break;
            case STAGE.Three:
                // set color for stage 3
                StartCoroutine(ChangeGridColor(gridColor[1]));
                DisplayInventory.Instance.UpdateLevelText(3);
                break;
            case STAGE.Four:
                // set color for stage 4
                StartCoroutine(ChangeGridColor(gridColor[2]));
                DisplayInventory.Instance.UpdateLevelText(4);
                break;
            case STAGE.Five:
                // set color for stage 5
                StartCoroutine(ChangeGridColor(gridColor[3]));
                DisplayInventory.Instance.UpdateLevelText(5);
                break;
            case STAGE.Six:
                // set color for stage 6
                StartCoroutine(ChangeGridColor(gridColor[4]));
                DisplayInventory.Instance.UpdateLevelText(6);
                break;
            default:
                break;
        }
    }

}
