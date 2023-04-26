using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private ChoosePanel chosePanel;

    private void OnEnable()
    {
        chosePanel = FindObjectOfType<ChoosePanel>();

        if (PlayerPrefs.HasKey(Const.LEVELS))
        {
            if (PlayerPrefs.GetInt(Const.LEVELS) > 0)
                chosePanel.gameObject.SetActive(true);
            else
                chosePanel.gameObject.SetActive(false);
        }
        else
            chosePanel.gameObject.SetActive(false);
    }

    private void OnDisable() => chosePanel.gameObject.SetActive(true);

    public void CloseProgram()=> Application.Quit();
}
