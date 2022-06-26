using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private readonly int mainSceneIndex = 1;
    public void OpenMainScene() 
    {
        SceneManager.LoadScene(mainSceneIndex);   
    }
}
