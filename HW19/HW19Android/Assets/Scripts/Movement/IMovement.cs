using UnityEngine;

public interface IMovement 
{
    public void HorizontalMovement(Vector2 direction);
    public void ReflectCharacter(Vector2 direction);
    public void Jump();
    public void DisableCollider();
    public bool GetRightFace();

}
