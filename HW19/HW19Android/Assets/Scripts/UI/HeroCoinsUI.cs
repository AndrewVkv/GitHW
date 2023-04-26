using UnityEngine;
using UnityEngine.UI;

public class HeroCoinsUI : MonoBehaviour
{
    [SerializeField] private Text coinTextValue;
    private void Awake() => coinTextValue = transform.GetChild(0).GetComponent<Text>();
    public void UpdateCoins(int value) 
    {
        coinTextValue.text = value.ToString();
    }
}
