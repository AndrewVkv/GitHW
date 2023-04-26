using System;
using UnityEngine;

public class BossPlatform : MonoBehaviour
{
    private readonly string MESSAGE_BOSS_PLATFORM = "Link EnemyBossStateManager is NULL";
    private readonly string MESSAGE_BOSS_POINTS = "Array waitingPoints length is 0";

    [SerializeField] EnemyBossStateManager bossManager;
    public Transform[] waitingPoints; 

    private void Awake()
    {
        bossManager = FindAnyObjectByType<EnemyBossStateManager>();

        if (bossManager == null)
            throw new Exception(MESSAGE_BOSS_PLATFORM);

        if(waitingPoints.Length == 0)
            throw new Exception(MESSAGE_BOSS_POINTS);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Inventory inventory))
            bossManager.SwitchState(bossManager.attackState);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Inventory inventory))
        {
            Vector2 heroPosition = new Vector2(inventory.transform.position.x, inventory.transform.position.y);
            bossManager.heroPositionOnBossPlatform = heroPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Inventory inventory))
            bossManager.SwitchState(bossManager.waitingState);
    }

}
