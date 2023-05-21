using UnityEngine;

public class Methods : MonoBehaviour
{
    public void DecreaseScale() 
    {
        transform.localScale = transform.localScale / 2;
    }
    public void AddRB() 
    {
        gameObject.AddComponent<Rigidbody>();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
