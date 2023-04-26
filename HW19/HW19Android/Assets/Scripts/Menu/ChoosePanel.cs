using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ChoosePanel : MonoBehaviour
{
    private const float delay2UpdateUI = 0.25f;

    [SerializeField] private Button[] levelButtons;

    [SerializeField] private TextMeshProUGUI textMeshTotalHearts;
    [SerializeField] private TextMeshProUGUI textMeshTotalCoins;

    private void Awake() 
    {
        UpdateCoinsKeys();
        UpdateLevelsKeys();
        UpdateHeartsKeys();
    }

    public void LoadScene(int index) => SceneManager.LoadScene(index);

    public void DeletePlayerPrefsKeys()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(Const.LEVELS, 0);
        PlayerPrefs.SetInt(Const.COINS, 0);
        PlayerPrefs.SetInt(Const.HEARTS, Const.STARTHEARTSVALUE);
    }

    private void UpdateCoinsKeys()
    {
        if (PlayerPrefs.HasKey(Const.COINS))
            textMeshTotalCoins.text = PlayerPrefs.GetInt(Const.COINS).ToString();
    }

    private void UpdateHeartsKeys()
    {
        if (!PlayerPrefs.HasKey(Const.HEARTS)) 
        {
            PlayerPrefs.SetInt(Const.HEARTS, Const.STARTHEARTSVALUE);
            textMeshTotalHearts.text = PlayerPrefs.GetInt(Const.HEARTS).ToString();
        }

        if (PlayerPrefs.HasKey(Const.HEARTS))
            textMeshTotalHearts.text = PlayerPrefs.GetInt(Const.HEARTS).ToString();
    }

    private void UpdateLevelsKeys()
    {
        if (PlayerPrefs.HasKey(Const.LEVELS))
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (i <= PlayerPrefs.GetInt(Const.LEVELS))
                    levelButtons[i].interactable = true;
                else
                    levelButtons[i].interactable = false;
            }
        }
        else
            PlayerPrefs.SetInt(Const.LEVELS, 0);
    }

    private IEnumerator UpdateKeysUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay2UpdateUI);
            UpdateCoinsKeys();
            UpdateLevelsKeys();
            UpdateHeartsKeys();
        }
    }

    private void OnEnable() => StartCoroutine(UpdateKeysUI());
    private void OnDisable() => StopCoroutine(UpdateKeysUI());
}
