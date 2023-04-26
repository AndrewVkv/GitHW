using UnityEngine;

public class HeroUI : MonoBehaviour
{
    [SerializeField] private HeroHealthUI healthUI;
    [SerializeField] private HeroCoinsUI coinUI;
    [SerializeField] private ShotGunUI shotGunUI;

    private void Awake()
    {
        healthUI = GetComponentInChildren<HeroHealthUI>();
        coinUI = GetComponentInChildren<HeroCoinsUI>();
        shotGunUI = GetComponentInChildren<ShotGunUI>();
    }

    public void UpdateHealth(int value) => healthUI.UpdateHearts(value);
    public void UpdateCoins(int value) => coinUI.UpdateCoins(value);

    public void SetShotGunUI(bool key) => shotGunUI.SetObjectActive(key);
}
