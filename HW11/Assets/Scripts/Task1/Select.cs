using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public void Close() => SceneManager.LoadScene(0);

    public void LoadLevel(int index) => SceneManager.LoadScene(index);
}
