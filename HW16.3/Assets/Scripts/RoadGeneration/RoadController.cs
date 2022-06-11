using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    // sonstants
    private readonly float delAddDelay = 1f;
    public readonly float startDelay = 3f;
    private readonly float jumpMultiplayer = 2f;
    private readonly float slideMultiplayer = 1.5f;
    private readonly float changeSpeedDuration = 1f;
    private readonly float startSpeed = 1f;

    [SerializeField]
    AnimationCurve curve;

    private RoadBuilder roadBuilder;
    private float speed3;
    public static RoadController Instance { get; private set; }

    public float speed = 3f;
    [Range(5, 15)]
    public int roadLength = 10;
    [Range(0, -20)]
    public int destroyPositionZ = -10;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        speed3 = speed;
        roadBuilder = GetComponent<RoadBuilder>();
        StartCoroutine(StartRoadMoving(startDelay));
        StartCoroutine(tryDellAddPlatform(delAddDelay));
    }
    /// <summary>
    /// Start delay befor move
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    private IEnumerator StartRoadMoving(float time)
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            roadBuilder.MovePlatforms(speed);
            ObstacleManager.Instance.MoveObstacles(speed);
            CoinsManager.instance.MoveCoins(speed);
            AmmuitionSpawn.instance.MoveAmmunition(speed);
            yield return null;
        }
    }
    /// <summary>
    /// Always check position & try delete platform
    /// </summary>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator tryDellAddPlatform(float delay)
    {
        while (true)
        {
            roadBuilder.CheckPlatformPosition();
            yield return new WaitForSeconds(delay);
        }
    }
    /// <summary>
    /// Change speed on Jump
    /// </summary>
    public void StartChangeSpeed4Jump()
    {
        StartCoroutine(ChangeSpeed4Jump(changeSpeedDuration));
    }
    private IEnumerator ChangeSpeed4Jump(float duration) 
    {
        // chenge speed non lineary
        float tmpSpeed = speed3;
        speed = Mathf.Lerp(speed, speed * jumpMultiplayer, duration / jumpMultiplayer);
        yield return new WaitForSeconds(duration);
        speed = Mathf.Lerp(speed, speed / jumpMultiplayer, duration / jumpMultiplayer);
        speed = tmpSpeed;

        if (PLayerCollision.Instance.state == playerSTATE.dead)
            speed = 0;
    }
    /// <summary>
    /// Change speed on slide
    /// </summary>
    public void StartChangeSpeed4Slide()
    {
        StartCoroutine(ChangeSpeed4Slide(changeSpeedDuration));
    }
    private IEnumerator ChangeSpeed4Slide(float duration)
    {
        // chenge speed non lineary
        float tmpSpeed = speed3;
        speed = Mathf.Lerp(speed, speed * slideMultiplayer, duration / slideMultiplayer);
        yield return new WaitForSeconds(duration);
        speed = Mathf.Lerp(speed, speed / slideMultiplayer, duration / slideMultiplayer);
        speed = tmpSpeed;

        if (PLayerCollision.Instance.state == playerSTATE.dead)
            speed = 0;
    }
    /// <summary>
    /// Acceleration on start from start speed too set speed
    /// </summary>
    /// <param name="delay"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator LerpSpeedOnStart(float delay, float duration) 
    {        
        yield return new WaitForSeconds(delay);
        float time = 0;
        float elapcedPercentage = 0;
        float setSpeed = speed;
        while (time < duration)
        {
            // chenge speed non lineary
            elapcedPercentage = time / duration;
            speed = Mathf.Lerp(startSpeed, setSpeed, curve.Evaluate(elapcedPercentage));
            time += Time.deltaTime;
            yield return null;
        }
        speed = setSpeed;
    }
    public void LerpSpeed(float durationIdleToSprint) 
    {
        StartCoroutine(LerpSpeedOnStart(startDelay, durationIdleToSprint));
    }

}
