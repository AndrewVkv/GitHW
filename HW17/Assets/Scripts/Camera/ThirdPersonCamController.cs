using UnityEngine;
using Cinemachine;
using System.Collections;

public class ThirdPersonCamController : MonoBehaviour
{
    //private readonly string inputAxisNameY = "Mouse Y";
    //private readonly string inputAxisNameX = "Mouse X";
    private readonly Vector2 startCamPosition = new Vector2(-90, 0.5f);
    //private readonly float delay2MoveCam = 10f;
    //private readonly float tenMidRingR = 10f;
    private readonly float twentyMidRingR = 20f;
    private readonly int middleRig = 1;

    private CinemachineFreeLook cFreeLook;
    private Vector3 originalCamPosition = Vector3.zero;
    private float originalMidRig;
    private float camTransitDuration = 20f;

    [SerializeField]
    private Transform lookAt;
    [SerializeField]
    private Transform deadLookAt;


    private void Start()
    {
        cFreeLook = GetComponent<CinemachineFreeLook>();
        originalCamPosition.x = cFreeLook.m_XAxis.Value;
        originalCamPosition.y = cFreeLook.m_YAxis.Value;
        originalMidRig = cFreeLook.m_Orbits[middleRig].m_Radius;

        cFreeLook.LookAt = lookAt;
        EventBus.eObstacleCollision.AddListener(SwitchCamDeath);

        //StartCamPosition();
        //StartCoroutine(MoveCamOnStart(delay2MoveCam));
    }
    private void StartCamPosition() 
    {
        cFreeLook.m_XAxis.Value = startCamPosition.x;
        cFreeLook.m_YAxis.Value = startCamPosition.y;
        cFreeLook.m_Orbits[middleRig].m_Radius = twentyMidRingR;
    }
    private IEnumerator MoveCamOnStart(float delay) 
    {
        yield return new WaitForSeconds(delay);
        float timeElapsed = 0;
        while (timeElapsed < camTransitDuration)
        {
            float percentageComplete = timeElapsed / camTransitDuration;
            cFreeLook.m_XAxis.Value = Mathf.Lerp(cFreeLook.m_XAxis.Value, originalCamPosition.x, percentageComplete);
            cFreeLook.m_YAxis.Value = Mathf.Lerp(cFreeLook.m_YAxis.Value, originalCamPosition.y, percentageComplete);
            cFreeLook.m_Orbits[middleRig].m_Radius = Mathf.Lerp(cFreeLook.m_Orbits[middleRig].m_Radius, originalMidRig, percentageComplete);
            timeElapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        cFreeLook.m_XAxis.Value = originalCamPosition.x;
        cFreeLook.m_YAxis.Value = originalCamPosition.y;
    }
    public void SwitchCamDeath()
    {
        cFreeLook.LookAt = deadLookAt;
    }
}
