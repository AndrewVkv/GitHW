using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private BossHealth bossHealth;
    [SerializeField] private Slider slider;
    private Vector3 sliderOffset = new Vector3(0, 2, 0);

    private void Awake()
    {
        bossHealth = GetComponentInParent<BossHealth>();
        slider = GetComponent<Slider>();
    }

    private void Update() => slider.transform.position = Camera.main.WorldToScreenPoint(bossHealth.transform.localPosition + sliderOffset);

    public void SetUIMaxValue(int value) => slider.maxValue = value;
    public void SetUIMinValue(int value) => slider.maxValue = value;
    public void SetUICurrentValue(int value) => slider.value = value;
}
