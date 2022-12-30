using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private readonly string message = "CharacterController in parenå is nissing";
    private readonly string obstacleTag = "Obstacle";
    private readonly string coinTag = "Coin";
    private readonly string finishTag = "Finish";

    private CoinManager coinManager;
    private RoadBuilder roadBuilder;
    private CharacterController characterController;
    private void Start()
    {
        if (CoinManager.Instance != null)
            coinManager = CoinManager.Instance;
        if(RoadBuilder.Instance != null)
            roadBuilder = RoadBuilder.Instance;

        if (GetComponent<CharacterController>() != null)
            characterController = GetComponent<CharacterController>();
        else
            Debug.Log(message);

        EventBus.eObstacleCollision.AddListener(eObstacleCollisionTest);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(obstacleTag))
        {
            print(obstacleTag);
            roadBuilder.StopMovingRoad();
            characterController.enabled = false;
            EventBus.eObstacleCollision.Invoke();
        }
        if (other.CompareTag(coinTag))
        {
            int coinIndexToDelete = other.GetComponent<CoinIndex>().coinIndex;
            //print(coinIndexToDelete);
            coinManager.RemoveCoinAtList(coinIndexToDelete);
            EventBus.eCoinCollision.Invoke();
        }
        if (other.CompareTag(finishTag))
        {
            print(finishTag);
            EventBus.eWin.Invoke();
            //RoadBuilder.Instance.StopMovingRoad();
            //PlayerAnim.animInstance.Finish();
        }
    }
    private void eObstacleCollisionTest() 
    {
        print("eCollisionTest");
    }
}
