using UnityEngine;
using System;

public class LockManager : MonoBehaviour
{
    private LockState currentLockState;
    private PlayerState currentPlayerState;

    private OpenState openState = new OpenState();
    private BrokenState brokenState = new BrokenState();
    private CloseState closeState = new CloseState();

    private PlayState playState = new PlayState();
    private WinState winState = new WinState();
    private LooseState looseState = new LooseState();

    private ControlTools controlTools;
    private ControlPins controlPins;

    private Timer timer;

    private PlayerPannels playerPannels;

    private void Start()
    {
        GetGameComponents();

        currentLockState = closeState;
        currentPlayerState = playState;

        currentLockState.Enter(this);
        currentPlayerState.Enter(this);
    }

    private void Update() => currentLockState.Update(this);
    public void SwitchLockState(LockState nextState) 
    {
        currentLockState.Exit(this);
        currentLockState = nextState;
        currentLockState.Enter(this);
    }
    public void SwitchPlayerState(PlayerState nextState)
    {
        currentPlayerState.Exit(this);
        currentPlayerState = nextState;
        currentPlayerState.Enter(this);
    }


    public void UseTiner() => timer.StartTimer(this);

    public void UseDrill()
    {
        controlTools.Drill.Use(controlPins.Pin1, controlPins.Pin2, controlPins.Pin3);
        CheckPins();
    }
    public void UseHummer()
    {
        controlTools.Hummer.Use(controlPins.Pin1, controlPins.Pin2, controlPins.Pin3);
        CheckPins();
    }
    public void UseMasterKey()
    {
        controlTools.MasterKey.Use(controlPins.Pin1, controlPins.Pin2, controlPins.Pin3);
        CheckPins();
    }


    public PlayerPannels PlayerPannels() => playerPannels;
    public void ResetTimer() => timer.ResetTimer();
    public void DrillTool() => currentLockState.UseDrillTool(this);
    public void HummerTool() => currentLockState.UseDrillTool(this);
    public void MasterKeyTool() => currentLockState.UseMasterKetTool(this);


    public void TimeIsOver()
    {
        SwitchPlayerState(looseState);
        SwitchLockState(brokenState);
    }

    private void CheckPins()
    {
        bool lockIsOpen = controlTools.WinPinsChecker(controlPins.Pin1, controlPins.Pin2, controlPins.Pin3);
        bool lockIsBroken = controlTools.LoosePinsChecker(controlPins.Pin1, controlPins.Pin2, controlPins.Pin3);
        if (lockIsOpen)
        {
            SwitchPlayerState(winState);
            SwitchLockState(openState);
        }
        if (lockIsBroken)
        {
            SwitchPlayerState(looseState);
            SwitchLockState(brokenState);
        }
    }
    public void RestartLockPrigram() 
    {
        SwitchPlayerState(playState);
        SwitchLockState(closeState);
        playerPannels.ResetPlayerPannels();
        controlPins.ResetPins();
    }

    private void GetGameComponents() 
    {
        controlTools = GetComponentInChildren<ControlTools>();
        if (controlTools == null)
            throw new Exception($"There is no ControlTools component in child:  { gameObject.name }");

        controlPins = GetComponentInChildren<ControlPins>();
        if (controlPins == null)
            throw new Exception($"There is no ControlPins component in child:  { gameObject.name }");

        timer = GetComponentInChildren<Timer>();
        if (timer == null)
            throw new Exception($"There is no Timer component in child:  { gameObject.name }");

        playerPannels = GetComponentInChildren<PlayerPannels>();
        if (playerPannels == null)
            throw new Exception($"There is no PlayerPannels component in child:  { gameObject.name }");
    }
}
