using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class WinPannel : MonoBehaviour
{
    private PlayerGameInput gameInput;

    [SerializeField] private TextMeshProUGUI coinsValue;

    private void Awake()
    {
        gameInput = FindObjectOfType<PlayerGameInput>();

        GlobalEventManager.eFinish.AddListener(WinScreen);
        GlobalEventManager.eWin.AddListener(WinScreen);
        gameObject.SetActive(false);
    }
    private void WinScreen() 
    {
        gameObject.SetActive(true);
        StartCoroutine(UpdateTotalCoins());
    }

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void NextLevel() 
    {
        gameInput.FinishMove();
        gameObject.SetActive(false);
    }

    public void MainMenu() => SceneManager.LoadScene(0);

    private IEnumerator UpdateTotalCoins() 
    {
        yield return new WaitForEndOfFrame();
        if (PlayerPrefs.HasKey(Const.COINS))
            coinsValue.text = PlayerPrefs.GetInt(Const.COINS).ToString();
    }

    private void OnDisable() => StopCoroutine(UpdateTotalCoins());
}


