using UnityEngine;

public class Door : MonoBehaviour,IObserver
{
    private Animator animator;
    [SerializeField]
    private bool key = false;

    private void Start() => animator = GetComponent<Animator>();

    public void Open()
    {
        if (key) animator.SetTrigger(Consts.OPEN_TRIGGER);
        print("Open");
    }
    public void Close()
    {
        animator.SetTrigger(Consts.CLOSE_TRIGGER);
        print("Close");
    }
    public void HasKey(bool has) => key = has;

    public void OnLooseNotify()
    {
        print("Door Notify");
    }
}

