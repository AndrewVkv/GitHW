using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayButton() 
    {
        SceneManager.LoadScene(1);
    }
}
