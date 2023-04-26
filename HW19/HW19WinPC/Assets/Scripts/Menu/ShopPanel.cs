using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    private const float delay2UpdateUI = 0.25f;

    [SerializeField] private Button[] levelButtons;

    [SerializeField] private TextMeshProUGUI textMeshTotalHearts;
    [SerializeField] private TextMeshProUGUI textMeshTotalCoins;


    private void Awake()
    {
        gameObject.SetActive(false);
        UpdateCoinsKeys();
        UpdateHeartsKeys();
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

    private IEnumerator UpdateKeysUI()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay2UpdateUI);
            UpdateCoinsKeys();
            UpdateHeartsKeys();
        }
    }

    private void OnEnable() => StartCoroutine(UpdateKeysUI());
    private void OnDisable() => StopCoroutine(UpdateKeysUI());

    public void BuyHearts(int value)
    {
        int currentValue = PlayerPrefs.GetInt(Const.HEARTS);
        if (currentValue + value <= Const.MAXHEARTSVALUE)
            PlayerPrefs.SetInt(Const.HEARTS, currentValue + value);
        else
            PlayerPrefs.SetInt(Const.HEARTS, Const.MAXHEARTSVALUE);
    }

    public void DeletePlayerPrefsKeys()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(Const.LEVELS, 0);
        PlayerPrefs.SetInt(Const.COINS, 0);
        PlayerPrefs.SetInt(Const.HEARTS, Const.STARTHEARTSVALUE);
    }
}
