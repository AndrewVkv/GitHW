using UnityEngine;

public class ShotGun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Gun gun))
        {
            PlayerPrefs.SetInt(Const.GUN, 1);
            //gun.HasShotGun = true;
            gun.UpdateShotGun();
            Destroy(gameObject);
        }
    }
}
