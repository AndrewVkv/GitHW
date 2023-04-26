
public abstract class EnemyBossBaseState
{
    public abstract void EnterState(EnemyBossStateManager bossManager);
    public abstract void UpdateState(EnemyBossStateManager bossManager);
    public abstract void ExitState(EnemyBossStateManager bossManager);
}
