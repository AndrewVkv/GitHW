public class BrokenState : LockState
{
    public override void Enter(LockManager lockState) { }

    public override void Exit(LockManager lockState) { }

    public override void Update(LockManager lockState) { }

    public override void UseDrillTool(LockManager lockState) { }

    public override void UseHummerTool(LockManager lockState) { }

    public override void UseMasterKetTool(LockManager lockState) { }
}
