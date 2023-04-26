using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePannel : MonoBehaviour
{
    private void Awake()
    {
        GlobalEventManager.eDeadHero.AddListener(LoseScreen);
        gameObject.SetActive(false);
    }
    private void LoseScreen() => gameObject.SetActive(true);

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
