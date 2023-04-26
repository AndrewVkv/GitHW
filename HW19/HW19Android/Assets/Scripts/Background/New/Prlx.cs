using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prlx : MonoBehaviour
{
    [SerializeField] private MeshRenderer rend;

    [Range(0.005f, 0.01f)]
    public float xMultiplyer;

    private void Awake() => rend = GetComponent<MeshRenderer>();

    public void MoveTextureMaterial(float speed) => rend.material.mainTextureOffset = new Vector2(speed * xMultiplyer, 0);
}
