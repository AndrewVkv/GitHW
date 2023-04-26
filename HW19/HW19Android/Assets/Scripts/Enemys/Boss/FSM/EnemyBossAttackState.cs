using UnityEngine;

public class EnemyBossAttackState : EnemyBossBaseState
{
    private const float reload = 1f;

    private Transform bossTransform;
    private Vector2 directionX = Vector2.zero;

    private bool shot = true;
    private Timer timer = new Timer();
    public override void EnterState(EnemyBossStateManager bossManager)
    {
        bossManager.bossMovement.HorizontalMovement(directionX);
    }

    public override void UpdateState(EnemyBossStateManager bossManager)
    {
        bossTransform = bossManager.transform;

        Vector2 heroPositionOnPlatform = new Vector2(bossManager.heroPositionOnBossPlatform.x, bossManager.heroPositionOnBossPlatform.y);
        Vector2 bossPosirionOnPlatform = new Vector2(bossTransform.position.x, bossTransform.position.y);
        Vector2 direction = heroPositionOnPlatform - bossPosirionOnPlatform;

        bossManager.bossMovement.ReflectCharacter(direction);

        shot = timer.StartT(reload);
        if (shot)
            bossManager.weapon.Shoot();
    }
    public override void ExitState(EnemyBossStateManager bossManager)
    {

    }

}
