using UnityEngine;

public class FireButton : MonoBehaviour
{
    private IWeapon weapon;
    private bool allowShoot;

    private void Awake()
    {
        weapon = FindObjectOfType<Gun>();
        CheckGun();
        allowShoot = true;

        GlobalEventManager.eGunCollected.AddListener(CheckGun);
        GlobalEventManager.eOpenSceneStarted.AddListener(NoShoot);
        GlobalEventManager.eOpenSceneFinished.AddListener(CanShoot);

    }
    public void FireB()
    {
        if (allowShoot)
            weapon.Shoot();
    }

    public void CheckGun()
    {
        if (PlayerPrefs.HasKey(Const.GUN))
        {
            if (PlayerPrefs.GetInt(Const.GUN) == 1)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }
        else
            gameObject.SetActive(false);
    }

    private void NoShoot()=> allowShoot = false;

    private void CanShoot()=> allowShoot = true;
}
