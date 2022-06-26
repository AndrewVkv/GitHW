using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmuitionSpawn : MonoBehaviour
{
    // constant
    private readonly float radiusSpereCheckGround = 0.2f;

    private List<GameObject> ammunitionList = new List<GameObject>();
    private STAGE currentStage;
    public static AmmuitionSpawn instance;

    public GameObject Ammunition;
    [Header("Ground Layer")]
    public LayerMask groundMask;
    [Header("Coin Layer")]
    public LayerMask coinMask;
    [Header("Obstacle Layer")]
    public LayerMask obstacleMask;


    private void Start()
    {
        instance = this;
        StartCoroutine(CheckAmmunitionPositionTryDestroy());

        currentStage = Stage.instance.stage;
    }
    /// <summary>
    /// Install ammunition object
    /// </summary>
    private void SetAmmunition()
    {
        Vector3 position = Vector3.zero;
        bool groundOnPosition = false;
        bool coinOnPosition = false;
        bool obstacleOnPosition = false;
        bool result = false;

        while (!result)
        {
            // get random position & check ground, no coin & no obstacle
            position = CoinsManager.instance.GetRandomPosition();
            groundOnPosition = Physics.CheckSphere(position, radiusSpereCheckGround, groundMask);
            coinOnPosition = Physics.CheckSphere(position, radiusSpereCheckGround, coinMask);
            obstacleOnPosition = Physics.CheckSphere(position, radiusSpereCheckGround, obstacleMask);
            result = groundOnPosition && !coinOnPosition && !obstacleOnPosition;
        }
        GameObject ammunitionInstall = Instantiate(Ammunition, position, Quaternion.identity, transform.transform);
        ammunitionInstall.GetComponent<AmmunitionListIndex>().index = ammunitionList.Count;
        ammunitionList.Add(ammunitionInstall);
    }

    public void MoveAmmunition(float speed) 
    {
        foreach (GameObject ammunitionObject in ammunitionList)
        {
            ammunitionObject.transform.position -= Vector3.forward * speed * Time.deltaTime;
        }
    }
    /// <summary>
    /// Check position to destroy
    /// </summary>
        private void CheckAmmunitionPosition()
    {
        if (ammunitionList.Count > 0) 
        {
            for (int i = 0; i < ammunitionList.Count; i++)
            {
                if (ammunitionList[i].transform.position.z < RoadController.Instance.destroyPositionZ)
                    RemoveAmmunitionAtList(i);
            }
        }
    }
    public void RemoveAmmunitionAtList(int index) 
    {
        GameObject ammunitionToDestroy = ammunitionList[index];
        ammunitionList.RemoveAt(index);
        Destroy(ammunitionToDestroy);
        if (ammunitionList.Count > 0) 
        {
            for (int i = 0; i < ammunitionList.Count; i++)
            {
                ammunitionList[i].GetComponent<AmmunitionListIndex>().index = i;
            }
        }
    }
    private IEnumerator CheckAmmunitionPositionTryDestroy() 
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CheckAmmunitionPosition();
            CheckPlafrormsCounRemoved();
        }
    }
    /// <summary>
    /// Install ammunition object every 10 platforms removed
    /// </summary>
    private void CheckPlafrormsCounRemoved() 
    {
        if (currentStage != Stage.instance.stage)
        {
            SetAmmunition();
            currentStage = Stage.instance.stage;
        }

    }
}
