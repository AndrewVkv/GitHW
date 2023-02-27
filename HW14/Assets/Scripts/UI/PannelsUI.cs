using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PannelsUI : MonoBehaviour
{
    protected void OnEnable() => gameObject.SetActive(true);

    protected void OnDisable() => gameObject?.SetActive(false);

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void GoHome() => SceneManager.LoadScene(0);
}
