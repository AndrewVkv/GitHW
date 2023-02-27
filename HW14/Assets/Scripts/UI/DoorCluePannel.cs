using UnityEngine;

public class DoorCluePannel : MonoBehaviour
{
    private void Start()
    {
        GlobalEventManager.OnDoorClue.AddListener(SetActiveDoorClue);
        SetActiveDoorClue(false);
    }

    private void SetActiveDoorClue(bool key)=> gameObject.SetActive(key);
}
