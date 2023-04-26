using UnityEngine;

public class EnemyBossWaitingState : EnemyBossBaseState
{
    private Vector2 directionX = Vector2.zero;

    // Waiting points
    private Transform[] points;
    private int arrayIndex;
    private float blindDistance = 0.1f;

    // Timer settings
    private float timerTick;
    private float waitingTime = 3f;

    private Transform bossTransform;

    public override void EnterState(EnemyBossStateManager bossManager)
    {
        // Timer set settings
        timerTick = 0f;
        arrayIndex = 0;

        points = bossManager.bossPlatform.waitingPoints;

        SetDirectionX(points[arrayIndex], bossManager.transform);
    }

    public override void ExitState(EnemyBossStateManager bossManager)
    {
        directionX = Vector2.zero;
        bossManager.bossMovement.HorizontalMovement(directionX);
    }

    public override void UpdateState(EnemyBossStateManager bossManager)
    {
        bossManager.bossMovement.HorizontalMovement(directionX);
        CheckObjectsDistance(points[arrayIndex], bossManager.transform);

        bossTransform = bossManager.transform;
    }

    private void CheckObjectsDistance(Transform point, Transform character)
    {
        float distance = point.position.x - character.position.x;
        if (Mathf.Abs(distance) < blindDistance)
        {
            directionX = Vector2.zero;
            Timer(waitingTime);
        }
    }
    private void Timer(float value)
    {
        if (timerTick < value)
            timerTick += Time.deltaTime;
        else
        {
            timerTick = 0;
            IncreaseArrayIndex();
            SetDirectionX(points[arrayIndex], bossTransform);
        }
    }

    private void SetDirectionX(Transform point, Transform character)
    {
        if (point.position.x - character.position.x < 0)
            directionX = Vector2.left;
        if (point.position.x - character.position.x > 0)
            directionX = Vector2.right;
    }

    private void IncreaseArrayIndex()
    {
        arrayIndex++;

        if (arrayIndex > points.Length - 1)
            arrayIndex = 0;
    }
}
