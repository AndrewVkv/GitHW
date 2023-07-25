using UnityEngine;
using UnityEngine.SceneManagement;

public class Pannel : MonoBehaviour
{
    public void ActivePannel(bool key) => gameObject.SetActive(key);

    public void RestartButton() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Go2Menu() 
    {
        SceneManager.LoadScene(0);
    }
}
