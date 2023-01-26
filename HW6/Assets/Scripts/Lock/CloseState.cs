public class CloseState : LockState
{
    public override void Enter(LockManager lockState) => lockState.ResetTimer();

    public override void Exit(LockManager lockState) { }

    public override void Update(LockManager lockState) => lockState.UseTiner();

    public override void UseDrillTool(LockManager lockState) => lockState.UseDrill();

    public override void UseHummerTool(LockManager lockState) => lockState.UseHummer();

    public override void UseMasterKetTool(LockManager lockState) => lockState.UseMasterKey();

}
