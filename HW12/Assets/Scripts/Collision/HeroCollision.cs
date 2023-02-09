using UnityEngine;

public class HeroCollision : MonoBehaviour
{
    private GameHandler gameHandler;
    private Door doorToOpen;
    private BridgeButton bridgeButton;

    private void Start() => gameHandler = GetComponentInParent<GameHandler>();

    public void OpenDoor() => doorToOpen.Open();
    public void OpenBridge() => bridgeButton.OpenBridge();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Consts.FINISH_TAG))
            gameHandler.GetWinEv().WinNotify();

        if (other.CompareTag(Consts.BRIDGE_BUTTON_TAG))
        {
            gameHandler.GetUIPannel().GetUIBridgeButton_Image().SetActiveImage(true);
            bridgeButton = other.GetComponent<BridgeButton>();
        }

        if (other.CompareTag(Consts.WASD_TAG))
            gameHandler.GetUIPannel().GetWASD_Image().SetActiveImage(true);

        if (other.CompareTag(Consts.JUMP_TAG))
            gameHandler.GetUIPannel().GetJump_Image().SetActiveImage(true);

        if (other.CompareTag(Consts.DOOR_TAG))
        {
            gameHandler.GetUIPannel().GetDoor_Image().SetActiveImage(true);
            other.GetComponent<Door>().HasKey(true);

            doorToOpen = other.GetComponent<Door>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Consts.BRIDGE_BUTTON_TAG))
        {
            gameHandler.GetUIPannel().GetUIBridgeButton_Image().SetActiveImage(false);
            bridgeButton = null;
        }

        if (other.CompareTag(Consts.WASD_TAG))
            gameHandler.GetUIPannel().GetWASD_Image().SetActiveImage(false);

        if (other.CompareTag(Consts.JUMP_TAG))
            gameHandler.GetUIPannel().GetJump_Image().SetActiveImage(false);

        if (other.CompareTag(Consts.DOOR_TAG))
        {
            gameHandler.GetUIPannel().GetDoor_Image().SetActiveImage(false);
            other.GetComponent<Door>().HasKey(false);

            doorToOpen = null;
            other.GetComponent<Door>().Close();            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            print("Obstacle");
            gameHandler.GetLooseEv().Notify();
        }
    }

}


