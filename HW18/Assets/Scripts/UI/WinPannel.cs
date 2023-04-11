using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPannel : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventManager.eWin.AddListener(WinScreen);
        gameObject.SetActive(false);
    }
    private void WinScreen() => gameObject.SetActive(true);

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
