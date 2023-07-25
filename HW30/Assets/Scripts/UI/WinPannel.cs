
public class WinPannel : Pannel
{
    private void Start()
    {
        EventBus.eWin.AddListener(ActivePannel);
        ActivePannel(false);
    }
}
