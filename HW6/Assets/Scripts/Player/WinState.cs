public class WinState : PlayerState
{
    public override void Enter(LockManager lockState) => lockState.PlayerPannels().WinPannel.SetActivePannel(true);

    public override void Exit(LockManager lockState) { }
}
