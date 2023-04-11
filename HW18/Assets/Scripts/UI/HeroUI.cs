using UnityEngine;

public class HeroUI : MonoBehaviour
{
    [SerializeField] private HeroHealthUI healthUI;
    [SerializeField] private HeroCoinsUI coinUI;

    private void Awake()
    {
        healthUI = GetComponentInChildren<HeroHealthUI>();
        coinUI = GetComponentInChildren<HeroCoinsUI>();
    }

    public void UpdateHealth(int value) => healthUI.UpdateHearts(value);
    public void UpdateCoins(int value) => coinUI.UpdateCoins(value);
}
