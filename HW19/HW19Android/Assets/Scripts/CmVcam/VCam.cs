using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCam : MonoBehaviour
{
    //private const float forwardCamOffset = 0.25f;
    //private const float rearCamOffset = 0.75f;
    private const float xCamOffset = 0.5f;

    private float smoothTime = 0.1f;
    private float velocity;

    private CinemachineVirtualCamera vCam;
    private CinemachineFramingTransposer CmFrTransposer;

    private Vector2 direction;
    private PlayerGameInput gameInput;

    private void Awake()
    {
        if (TryGetComponent(out CinemachineVirtualCamera cv))
            vCam = cv;
        CmFrTransposer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
        CmFrTransposer.m_TrackedObjectOffset.x = xCamOffset;

        gameInput = FindObjectOfType<PlayerGameInput>();
        direction = gameInput.Direction;
    }

    private void ReflectCamTrackedOffset(Vector2 direction)
    {
        if (direction.x > 0f)
            CmFrTransposer.m_TrackedObjectOffset.x = Mathf.SmoothDamp(CmFrTransposer.m_TrackedObjectOffset.x, xCamOffset, ref velocity, smoothTime);
        if (direction.x < 0f)
            CmFrTransposer.m_TrackedObjectOffset.x = Mathf.SmoothDamp(CmFrTransposer.m_TrackedObjectOffset.x, -xCamOffset, ref velocity, smoothTime);
    }

    private void Update()
    {
        direction = gameInput.Direction;
        ReflectCamTrackedOffset(direction);
    }
}
