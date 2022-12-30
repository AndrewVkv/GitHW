using UnityEngine;

public class MainCam : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        cam.orthographic = true;
    }
}
