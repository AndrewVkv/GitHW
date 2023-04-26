using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class WinPannel : MonoBehaviour
{
    //[SerializeField] private Finish finish;

    private PlayerGameInput gameInput;

    [SerializeField] private TextMeshProUGUI coinsValue;

    private void Awake()
    {
        //finish = FindObjectOfType<Finish>();
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
        //finish.moveNextLevel = true;
        gameInput.finishMove = true;
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


