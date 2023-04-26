using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BuyHearts : BuyHeartButton
{
    [SerializeField] private int hearts;
    [SerializeField] private int price;

    private const float delay2UpdateBudget = 0.25f;

    [SerializeField]
    private void Awake()
    {
        heatButton = new HeatButton(hearts, price);
    }

    public void BuyButtonHearts()
    {
        // Condition
        int currentBudget = PlayerPrefs.GetInt(Const.COINS);
        if (currentBudget >= price) 
        {
            currentBudget -= price;
            PlayerPrefs.SetInt(Const.COINS, currentBudget);

            // Transaction
            int currentValue = PlayerPrefs.GetInt(Const.HEARTS);
            if (currentValue + hearts <= Const.MAXHEARTSVALUE)
                PlayerPrefs.SetInt(Const.HEARTS, currentValue + hearts);
            else
                PlayerPrefs.SetInt(Const.HEARTS, Const.MAXHEARTSVALUE);
        }
        else
            print("Mo Coins");
    }


    private IEnumerator InteractableButton() 
    {
        while (true)
        {
            UpdateBudget();
            yield return new WaitForSeconds(delay2UpdateBudget);
        }
    }

    private void UpdateBudget() 
    {
        int currentBudget = PlayerPrefs.GetInt(Const.COINS);
        if (currentBudget >= price)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
            gameObject.GetComponent<Button>().interactable = false;
    }

    private void OnEnable()=> StartCoroutine(InteractableButton());

    private void OnDisable()=> StopCoroutine(InteractableButton());
}
