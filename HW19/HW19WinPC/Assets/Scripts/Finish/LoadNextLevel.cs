using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Inventory inv))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
