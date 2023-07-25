using UnityEngine;

public class MenuAuthorState : MenuBaseState
{
    public override void EnterState(MenuStateManager menu)
    {
        Debug.Log("Hello From Author State");
        menu.menuPannel.SetActive(false);
        menu.authorPannel.SetActive(true);
    }

}
