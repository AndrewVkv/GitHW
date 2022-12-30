using UnityEngine;
using UnityEngine.UI;

public class StageDisplay : MonoBehaviour
{
    [SerializeField]
    private Text stageText;
    [SerializeField]
    GameObject stageObject;
    public static StageDisplay Instance;

    private void Start()
    {
        Instance = this;
        Stage.CheckStage();
        SetStagePannel(false);
    }
    public void UpdateStageText() 
    {
        stageText.text = ((int)Stage.gameStage).ToString();
    }
    public void SetStagePannel(bool flag)
    {
        stageObject.SetActive(flag);
    }
}
