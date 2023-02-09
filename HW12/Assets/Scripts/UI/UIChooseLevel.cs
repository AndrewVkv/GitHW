using UnityEngine;
using UnityEngine.SceneManagement;

public class UIChooseLevel : MonoBehaviour
{
    public void LoadLevel(int index) => SceneManager.LoadScene(index);
}
