using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLevels : MonoBehaviour
{
    private int activeSceneIndex;
    private Inventory inventory;

    private void Awake() 
    {
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        inventory = FindObjectOfType<Inventory>();

        GlobalEventManager.eFinish.AddListener(SaveLevel);
        GlobalEventManager.eFinish.AddListener(SaveCoins);
    }
    private void SaveLevel() 
    {
        if(!PlayerPrefs.HasKey(Const.LEVELS) || PlayerPrefs.GetInt(Const.LEVELS) < activeSceneIndex)
            PlayerPrefs.SetInt(Const.LEVELS, activeSceneIndex);
    }

    private void SaveCoins() 
    {
        int coinValue = inventory.GetCoisnValue();
        PlayerPrefs.SetInt(Const.COINS, coinValue);
    }
}
