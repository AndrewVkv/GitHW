using System.Collections;
using UnityEngine;

public class SliderPlatform : MonoBehaviour
{
    private Anchor anchor;
    private Platform platform;

    private float delay = 6f;
    private void Awake()
    {
        anchor = GetComponentInChildren<Anchor>();
        platform = GetComponentInChildren<Platform>();
    }
    private void Start()
    {
        Vector2 anchorPosition2D = new Vector2(anchor.transform.position.x, anchor.transform.position.y);
        platform.SetConnectedAnchor(anchorPosition2D);
        StartCoroutine(PlatformCycle(delay));
    }

    private IEnumerator PlatformCycle(float delay) 
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            platform.MoveUpPlatform();
            yield return new WaitForSeconds(delay);
            platform.MoveDownPlatform();
        }
    }
}
