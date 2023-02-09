using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class UIPannel : MonoBehaviour, IObserver,IWin
{
    private WASD_Image WASD_Image;
    private Jump_Image Jump_Image;
    private UILoose loosePannel;
    private UIWin winPannel;
    private GameHandler gameHandler;
    private UIDoor door;
    private UIBridgeButton bridgeButton;

    public WASD_Image GetWASD_Image() => WASD_Image;
    public Jump_Image GetJump_Image() => Jump_Image;
    public UILoose GetLoosePannel() => loosePannel;
    public UIWin GetWinPannel() => winPannel;
    public UIDoor GetDoor_Image() => door;
    public UIBridgeButton GetUIBridgeButton_Image() => bridgeButton;

    private void Awake()
    {
        GetAllComponents();
        SetActiveComponents();

        gameHandler.GetLooseEv().AddEv(this);
        gameHandler.GetWinEv().AddWinEv(this);
    }

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void LoadNextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void GoHomePage()=> SceneManager.LoadScene(0);
    private void SetActiveLoosePannel() => loosePannel.SetActiveLoosePannel(true);
    private void SetActiveWinannel() => winPannel.SetActiveWinPannel(true);

    public void OnLooseNotify() => SetActiveLoosePannel();

    public void OnWinNotify() => SetActiveWinannel();

    public void GetAllComponents() 
    {

        gameHandler = GetComponentInParent<GameHandler>();
        if (gameHandler == null)
            throw new Exception($"There is no GameHandler component in child");

        WASD_Image = GetComponentInChildren<WASD_Image>();
        if (WASD_Image == null)
            throw new Exception($"There is no WASD_Image component in child");

        Jump_Image = GetComponentInChildren<Jump_Image>();
        if (Jump_Image == null)
            throw new Exception($"There is no Jump_Image component in child");

        loosePannel = GetComponentInChildren<UILoose>();
        if (loosePannel == null)
            throw new Exception($"There is no LoosePannel component in child");

        winPannel = GetComponentInChildren<UIWin>();
        if (winPannel == null)
            throw new Exception($"There is no WinPannel component in child");

        door = GetComponentInChildren<UIDoor>();
        if (door == null)
            throw new Exception($"There is no UIDoor component in child");

        bridgeButton = GetComponentInChildren<UIBridgeButton>();
        if (bridgeButton == null)
            throw new Exception($"There is no UIBridgeButton component in child");
    }

    private void SetActiveComponents() 
    {
        Jump_Image.SetActiveImage(false);
        loosePannel.SetActiveLoosePannel(false);
        winPannel.SetActiveWinPannel(false);
        WASD_Image.SetActiveImage(false);
        door.SetActiveImage(false);
        bridgeButton.SetActiveImage(false);
    }
}


