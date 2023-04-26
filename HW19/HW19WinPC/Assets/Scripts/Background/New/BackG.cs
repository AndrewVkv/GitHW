using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackG : MonoBehaviour
{
    private const float offsetZ = 10f;

    //private float turnSmoothTime = 0.15f;
    //private float turnSmoothVelocity;

    //private Camera cam;
    private VCam vCam;
    private float speed;
    private Vector3 backgroundPosition;

    [SerializeField] private List<Prlx> backLayers = new List<Prlx>();

    private void Awake() 
    {
        vCam = FindObjectOfType<VCam>();
        //cam = Camera.main;
    }


    private void Update()
    {
        MoveBackground();

        speed = backgroundPosition.x;
        //speed = 0f;
        MoveLayers(speed);
    }
    private void MoveBackground()
    {
        backgroundPosition = new Vector3(vCam.transform.position.x, vCam.transform.position.y, vCam.transform.position.z + offsetZ);
        transform.position = backgroundPosition;
    }

    private void MoveLayers(float speed)
    {
        foreach (var item in backLayers)
        {
            item.MoveTextureMaterial(speed);
        }
    }
}
