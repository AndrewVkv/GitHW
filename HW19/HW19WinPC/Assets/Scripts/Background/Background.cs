using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private const float offsetZ = 10f;

    private Camera cam;
    private float speed;
    private Vector3 backgroundPosition;

    [SerializeField] private List<Parallax> parallaxList = new List<Parallax>();


    private void Awake() => cam = Camera.main;

    private void FixedUpdate()
    {
        MoveBackground();

        speed = backgroundPosition.x;
        MoveLayers(speed);
    }

    private void MoveBackground() 
    {
        backgroundPosition = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + offsetZ);
        transform.position = backgroundPosition;
    }

    protected void MoveLayers(float speed) 
    {
        foreach (var item in parallaxList)
            item.MoveTextureMaterial(speed);
    }

}
