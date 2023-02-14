using UnityEngine;

public class GFX : MonoBehaviour
{
    private Cap cap;

    private void Start() => cap = GetComponentInChildren<Cap>();

    public Transform GetCapTransform() => cap.transform;
}
