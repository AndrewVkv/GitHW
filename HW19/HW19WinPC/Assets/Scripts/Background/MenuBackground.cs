using UnityEngine;

public class MenuBackground : Background
{
    private float moveSpeed;
    private float multiplier = 6f;
    private void Update()
    {
        moveSpeed += Time.deltaTime * multiplier;
        MoveLayers(moveSpeed);
    }
}
