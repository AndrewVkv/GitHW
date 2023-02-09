using UnityEngine;

public class DeadColor : MonoBehaviour,IObserver
{
    private Color deadColor = Color.green;
    private GameHandler gameHandler;

    private void Start()
    {
        gameHandler = GetComponentInParent<GameHandler>();
        gameHandler.GetLooseEv().AddEv(this);
    }
    private void DeathColor()=> gameObject.GetComponent<Renderer>().material.color = deadColor;

    public void OnLooseNotify()=> DeathColor();
}
