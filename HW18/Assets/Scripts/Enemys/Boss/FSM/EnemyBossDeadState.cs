
public class EnemyBossDeadState : EnemyBossBaseState
{
    public override void EnterState(EnemyBossStateManager bossManager)
    {
        bossManager.bossMovement.Jump();
        bossManager.bossMovement.DisableCollider();
        GlobalEventManager.RiseEvWin();
    }

    public override void ExitState(EnemyBossStateManager bossManager)
    {

    }

    public override void UpdateState(EnemyBossStateManager bossManager)
    {

    }
}
