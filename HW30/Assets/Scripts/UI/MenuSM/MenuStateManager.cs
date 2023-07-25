using UnityEngine;

public class MenuStateManager : MonoBehaviour
{
    private MenuBaseState curretnState;

    public MenuStartState startState = new MenuStartState();
    public MenuAuthorState authorState = new MenuAuthorState();

    public GameObject menuPannel;
    public GameObject authorPannel;


    private void Start()
    {
        curretnState = startState;

        curretnState.EnterState(this);
    }

    public void SwitchState(MenuBaseState menu) 
    {
        curretnState = menu;
        curretnState.EnterState(this);
    }

    public void AuthotPannel() => SwitchState(authorState);

    public void StartPannel() => SwitchState(startState);
}
