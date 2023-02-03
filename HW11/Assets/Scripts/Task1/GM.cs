using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    [SerializeField]
    private PausePannel pausePannel;

    private void Start()
    {
        pausePannel = GetComponentInChildren<PausePannel>();

        if (pausePannel == null)
            throw new Exception($"There is no PausePannel component in child");

        pausePannel.gameObject.SetActive(false);
    }

    public void PauseOn() => pausePannel.gameObject.SetActive(true);
    public void PauseOf() => pausePannel.gameObject.SetActive(false);
    public void GoHome() => SceneManager.LoadScene(1);
    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
