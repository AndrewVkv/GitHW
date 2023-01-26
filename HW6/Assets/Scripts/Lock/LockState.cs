public abstract class LockState
{
    public abstract void Enter(LockManager lockState);
    public abstract void Exit(LockManager lockState);
    public abstract void Update(LockManager lockState);
    public abstract void UseDrillTool(LockManager lockState);
    public abstract void UseHummerTool(LockManager lockState);
    public abstract void UseMasterKetTool(LockManager lockState);

}
