using UnityEngine;

public class SavePoint : MonoBehaviour
{
    private Inventory inventory;

    private void Awake()
    {
        GlobalEventManager.eFinish.AddListener(DeleteSavePointKeysOnLevel);
        GlobalEventManager.eFinish.AddListener(SaveInventory);
        GlobalEventManager.eWin.AddListener(DeleteSavePointKeysOnLevel);
        GlobalEventManager.eWin.AddListener(SaveInventory);

        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Hero hero)) 
        {
            float xPos = hero.transform.position.x;
            float yPos = hero.transform.position.y;
            SaveHeroXPosition(xPos, yPos);
            SaveInventory();
            gameObject.SetActive(false);
        }
    }

    private void SaveHeroXPosition(float xValue, float yValue) 
    {
        PlayerPrefs.SetFloat(Const.XPOSITION, xValue);
        PlayerPrefs.SetFloat(Const.YPOSITION, yValue);
    }

    private void DeleteSavePointKeysOnLevel()
    {
        PlayerPrefs.DeleteKey(Const.XPOSITION);
        PlayerPrefs.DeleteKey(Const.YPOSITION);
    }

    private void SaveHearts()
    {
        int heartsValue = inventory.GetHeartsValue();
        PlayerPrefs.SetInt(Const.HEARTS, heartsValue);
    }

    private void SaveCoins() 
    {
        int coinsValue = inventory.GetCoisnValue();
        PlayerPrefs.SetInt(Const.COINS, coinsValue);
    }
    private void SaveInventory() 
    {
        SaveHearts();
        SaveCoins();
    }
}
