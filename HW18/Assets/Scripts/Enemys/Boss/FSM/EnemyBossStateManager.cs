using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyBossMovement))]
public class EnemyBossStateManager : MonoBehaviour
{
    private readonly string POINTS_MESSAGE = "Link BossPlatform is NULL";

    // Boss reference state
    private EnemyBossBaseState currentState;
    public EnemyBossWaitingState waitingState = new EnemyBossWaitingState();
    public EnemyBossAttackState attackState = new EnemyBossAttackState();
    public EnemyBossDeadState deadState = new EnemyBossDeadState();

    public IMovement bossMovement { get; private set; }
    public IWeapon weapon { get; private set; }
    public BossPlatform bossPlatform;
    public Vector2 heroPositionOnBossPlatform { get; set; }

    private void Awake()
    {
        if (TryGetComponent(out IMovement mmovememt))
            bossMovement = mmovememt;

        if(TryGetComponent(out IWeapon wp))
            weapon = wp;

        if (bossPlatform == null)
            throw new Exception(POINTS_MESSAGE);
    }
    private void Start()
    {
        currentState = waitingState;
        currentState.EnterState(this);     
    }

    private void Update() => currentState.UpdateState(this);

    public void SwitchState(EnemyBossBaseState state) 
    {
        currentState.ExitState(this);
        currentState=state;
        state.EnterState(this);
    }
}
