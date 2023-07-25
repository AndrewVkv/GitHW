
public class LosePannel : Pannel
{
    private void Start()
    {
        EventBus.eLose.AddListener(ActivePannel);
        ActivePannel(false);
    }
}
