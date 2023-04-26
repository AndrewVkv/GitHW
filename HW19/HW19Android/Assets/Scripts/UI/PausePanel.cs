using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    private float pauseTimeScale = 0.00001f;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void PauseOn() 
    {
        gameObject.SetActive(true);
        Time.timeScale = pauseTimeScale;
    }

    public void PauseOff() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;

        PlayerPrefs.DeleteKey(Const.XPOSITION);
        PlayerPrefs.DeleteKey(Const.YPOSITION);

        SceneManager.LoadScene(0);
    }
}
