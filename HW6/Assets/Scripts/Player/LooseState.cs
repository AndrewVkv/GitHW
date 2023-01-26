public class LooseState : PlayerState
{
    public override void Enter(LockManager lockState) => lockState.PlayerPannels().LoosePannel.SetActivePannel(true);

    public override void Exit(LockManager lockState) { }
}
