using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// player state
public enum playerSTATE { alive, dead, falling }
public class PLayerCollision : MonoBehaviour
{
    // collision tags
    private readonly string obstacleTag = "Obstacle";
    private readonly string destroyableobstacleTag = "DestroyableObstacle";
    private readonly string spikeTag = "Spike";
    private readonly string finishTag = "Finish";
    private readonly string StopMovingTag = "StopMoving";
    private readonly string coinTag = "Coin";
    private readonly string ammunitionTag = "Ammunition";

    // create get coin event
    UnityEvent eventGetCoins = new UnityEvent();

    // get acces
    private Inventory playerInventory;
    private DisplayInventory playerDisplayInventory;

    public playerSTATE state = playerSTATE.alive;

    public static PLayerCollision Instance;

    private void Start()
    {
        if (Instance == null)
            Instance = this;

        // get reference
        playerInventory = GetComponent<Inventory>();
        playerDisplayInventory = GetComponent<DisplayInventory>();

        eventGetCoins.AddListener(StartUpdateStuff);
        eventGetCoins.Invoke();
        eventGetCoins.RemoveListener(StartUpdateStuff);
        eventGetCoins.AddListener(UpdateCoins);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(destroyableobstacleTag))
        {
            state = playerSTATE.dead;
            DeathRoutine();
        }
        if (other.CompareTag(obstacleTag))
        {
            state = playerSTATE.dead;
            DeathRoutine();
        }
        if (other.CompareTag(coinTag))
        {
            int listIndex = other.gameObject.GetComponent<CoinIndex>().coinIndex;
            CoinsManager.instance.RemoveAddCoinPlayerCollision(listIndex);
            eventGetCoins.Invoke();

        }
        if (other.CompareTag(spikeTag))
        {
            playerInventory.CollisionSpikeObstacle();
        }
        if (other.CompareTag(finishTag))
        {
            AnimationManager.Instance.FinishAnim();
            ZeroSpeed();
            GamePannels.instance.OpenWinPannel();
        }
        if (other.CompareTag(StopMovingTag))
        {
            PlayerMover.Instance.inMovementLR = true;
            ThirdPersonCamFly.Instance.StartFinishCamFly();
        }
        if (other.CompareTag(ammunitionTag)) 
        {
            Inventory.Instance.CollideAmmunition();
            int number = other.gameObject.GetComponent<AmmunitionListIndex>().index;
            AmmuitionSpawn.instance.RemoveAmmunitionAtList(number);
        }
    }
    private void ZeroSpeed()
    {
        RoadController.Instance.speed = 0;
    }
    private void DeathAnim()
    {
        AnimationManager.Instance.ObstacleDeath();
    }
    public void DeathRoutine()
    {
        ZeroSpeed();
        DeathAnim();
        ThirdPersonCamFly.Instance.StartFlyCamDeath();
        playerDisplayInventory.ZeroHearts();
    }
    private void StartUpdateStuff() 
    {
        playerDisplayInventory.UpdateCoinText();
        playerDisplayInventory.UpdateBullets();
    }
    private void UpdateCoins()
    {
        playerInventory.PlusCoin();
        playerDisplayInventory.UpdateCoinText();
    }
}
