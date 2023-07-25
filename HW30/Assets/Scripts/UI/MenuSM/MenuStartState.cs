using UnityEngine;

public class MenuStartState : MenuBaseState
{
    public override void EnterState(MenuStateManager menu)
    {
        Debug.Log("Hello From Start State");
        menu.menuPannel.SetActive(true);
        menu.authorPannel.SetActive(false);
    }

}
