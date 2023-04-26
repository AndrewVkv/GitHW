using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private class BHealth 
    {
        private int health;

        public int Health 
        {
            get { return health; }
            set { health = value; }
        }

        public BHealth(int heath)
        {
            this.health = heath;
        }
    }

    private const int startHealth = 10;
    private const int deadHealth = 0;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private EnemyBossStateManager bossManager;

    private BHealth bossHealth = new BHealth(startHealth);


    private void Awake() 
    {
        healthBar = GetComponentInChildren<HealthBar>();

        if(TryGetComponent(out EnemyBossStateManager boss))
            bossManager = boss;
    }

    private void Start() 
    {
        healthBar.SetUIMinValue(deadHealth);
        healthBar.SetUIMaxValue(startHealth);
        healthBar.SetUICurrentValue(bossHealth.Health);
    }

    private void CheckAlive()
    {
        if (bossHealth.Health <= 0)
            bossManager.SwitchState(bossManager.deadState);
    }

    public void ReceiveDamage(int value)
    {
        bossHealth.Health -= value;
        CheckAlive();
        UpdateBossUI();
    }

    private void UpdateBossUI() => healthBar.SetUICurrentValue(bossHealth.Health);
}
