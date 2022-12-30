using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    private readonly float zero = 0.0001f;
    private readonly float one = 1;
    private readonly int MenuScene = 0;
    private readonly int MainScene = 1;

    public GameObject pausePannel;
    public GameObject loosePannel;
    public GameObject winPannel;
    private void Start()
    {
        pausePannel.SetActive(false);
        loosePannel.SetActive(false);
        winPannel.SetActive(false);
        EventBus.eObstacleCollision.AddListener(OpenLoosePannel);
        EventBus.eFalling.AddListener(OpenLoosePannel);
        EventBus.eWin.AddListener(OpenWinPannel);
    }
    public void PauseOn()
    {
        print("PauseOn");
        pausePannel.SetActive(true);
        Time.timeScale = zero;
    }
    public void Resume()
    {
        print("PauseOf");
        pausePannel.SetActive(false);
        Time.timeScale = one;
    }
    public void GoHome() 
    {
        Time.timeScale = one;
        SceneManager.LoadScene(MenuScene);
    }
    public void RestartLvl() 
    {
        SceneManager.LoadScene(MainScene);
    }
    private void OpenWinPannel() 
    {
        winPannel.SetActive(true);
    }
    private void OpenLoosePannel() 
    {
        loosePannel.SetActive(true);
    }
}
