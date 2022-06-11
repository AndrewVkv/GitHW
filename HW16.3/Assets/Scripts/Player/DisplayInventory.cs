using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public static DisplayInventory Instance;
    private Inventory inventory;

    public Text coinText;
    public Text bulletText;
    public Text levelText;
    public Image[] hearts = new Image[3];
    public Sprite life, noLife;

    private void Awake()
    {
        // create singletone object
        Instance = this;

        // get reference
        inventory = GetComponent<Inventory>();
        UpdateHP();
        UpdateLevelText(1);
    }

    public void UpdateCoinText()
    {
        coinText.text = inventory.GetCoins().ToString();
    }
    public void UpdateBullets() 
    {
        bulletText.text = inventory.GetBullets().ToString();
    }
    public void UpdateHP() 
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (inventory.GetHP() > i)
                hearts[i].sprite = life;
            else
                hearts[i].sprite = noLife;
        }
        if (inventory.GetHP() <= 0)
        {
            PLayerCollision.Instance.DeathRoutine();
            PLayerCollision.Instance.state = playerSTATE.dead;
        }
    }
    public void FallingRoutine() 
    {
        PLayerCollision.Instance.state = playerSTATE.falling;
        ZeroHearts();
        GamePannels.instance.FallingPannel();
    }
    public void ZeroHearts() 
    {
        for (int i = 0; i < hearts.Length; i++)
            hearts[i].sprite = noLife;
    }
    public void UpdateLevelText(int lvl) 
    {
        levelText.text = lvl.ToString();
    }

}
