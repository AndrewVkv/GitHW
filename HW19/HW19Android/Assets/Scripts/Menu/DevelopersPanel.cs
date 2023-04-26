using UnityEngine;

public class DevelopersPanel : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void DeletePlayerPrefsKeys()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(Const.LEVELS, 0);
        PlayerPrefs.SetInt(Const.COINS, 0);
        PlayerPrefs.SetInt(Const.HEARTS, Const.STARTHEARTSVALUE);
        PlayerPrefs.SetInt(Const.OPENSCENE, 0);
        PlayerPrefs.SetInt(Const.GUN, 0);
    }
}
