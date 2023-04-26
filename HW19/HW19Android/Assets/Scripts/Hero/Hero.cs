using UnityEngine;

public class Hero : MonoBehaviour
{
    public IMovement Movement { get; private set; }

    private void Awake() => Movement = GetComponent<IMovement>();

}
