using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class GamePannels : MonoBehaviour
{
    // contants
    private readonly float timeScalePauseOn = 0.001f;
    private readonly float timeScalePauseOff = 1f;
    private readonly int MenuSceneIndex = 0;
    private readonly float startDelay = 3f;

    public static GamePannels instance;

    public GameObject pausePannel;
    public GameObject winPannel;
    public GameObject loosePannel;
    public GameObject goPannel;

    // use unity event system for buttons
    UnityEvent pauseOn = new UnityEvent();
    UnityEvent pauseOff = new UnityEvent();
    UnityEvent reloadLevel = new UnityEvent();
    UnityEvent goMenu = new UnityEvent();

    private void Start()
    {
        instance = this;

        HidePannels();
        pauseOn.AddListener(PauseOn);
        pauseOff.AddListener(PauseOff);
        reloadLevel.AddListener(ReloadLevel);
        goMenu.AddListener(GoMenu);
        goPannel.SetActive(false);

        StartCoroutine(CheckDeadStatus());
        StartCoroutine(ShowGoPannel(startDelay));
    }
    private void HidePannels() 
    {
        Time.timeScale = timeScalePauseOff;
        pausePannel.SetActive(false);
        winPannel.SetActive(false);
        loosePannel.SetActive(false);
    }
    private void PauseOn() 
    {
        pausePannel.SetActive(true);
        Time.timeScale = timeScalePauseOn;
    }
    private void PauseOff()
    {
        pausePannel.SetActive(false);
        Time.timeScale = timeScalePauseOff;
        InputManager.Instance.EscOff();
    }
    private void ReloadLevel() 
    {
        Time.timeScale = timeScalePauseOff;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void GoMenu() 
    {
        Time.timeScale = timeScalePauseOff;
        SceneManager.LoadScene(MenuSceneIndex);
    }
    private void OpenLoosePannel() 
    {
        loosePannel.SetActive(true);
        InputManager.Instance.WinLoosePannelsOn();
    }

    public void PauseOnClick() 
    {
        pauseOn.Invoke();
    }
    public void PauseOffClick()
    {
        pauseOff.Invoke();
    }
    public void ReloadLvl() 
    {
        reloadLevel.Invoke();
    }
    public void GoToMenu() 
    {
        goMenu.Invoke();
    }
    private IEnumerator CheckDeadStatus() 
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (PLayerCollision.Instance.state == playerSTATE.dead)
                OpenLoosePannel();
        }
    }
    private IEnumerator AciveWinPannel() 
    {
        yield return new WaitForSeconds(1);
        winPannel.SetActive(true);
    }
    public void OpenWinPannel() 
    {
        StartCoroutine(AciveWinPannel());
        InputManager.Instance.WinLoosePannelsOn();
    }
    public void FallingPannel() 
    {
        StartCoroutine(DelayLoosePannelFalling());
    }
    private IEnumerator DelayLoosePannelFalling() 
    {
        yield return new WaitForSeconds(1);
        OpenLoosePannel();
    }
    private IEnumerator ShowGoPannel(float delay) 
    {
        yield return new WaitForSeconds(delay);
        goPannel.SetActive(true);
        yield return new WaitForSeconds(1);
        goPannel.SetActive(false);
    }

}
