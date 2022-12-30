using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionContainer : MonoBehaviour
{
    public static Transform explosionContainerTransform;
    public static ExplosionContainer instance;

    private List<GameObject> explosionObjectsList = new List<GameObject>();
    private void Awake()
    {
        explosionContainerTransform = transform;
    }
    private void Start()
    {
        EventBus.eMove.AddListener(MoveObjectsInList);
        if (instance == null)
            instance = this;
    }
    private void MoveObjectsInList()
    {
        if (explosionObjectsList.Count != 0)
        {
            float speed = RoadBuilder.Instance.GetRoadSpeed();
            foreach (GameObject item in explosionObjectsList)
            {
                item.transform.localPosition -= Vector3.forward * speed * Time.fixedDeltaTime;
            }
        }
    }
    public void AddAtList(GameObject explosionObj) 
    {
        explosionObjectsList.Add(explosionObj);
    }
    public void RemoveAtList(int objIndex)
    {
        explosionObjectsList.RemoveAt(objIndex);
    }
    public int ListCount() 
    {
        return explosionObjectsList.Count;
    }
    public void SortList() 
    {
        for (int i = 0; i < explosionObjectsList.Count; i++)
        {
            explosionObjectsList[i].GetComponent<ObstacleBlast>().Set(i);
        }
    }
    //public void Update()
    //{        
    //    if(Input.GetKey(KeyCode.Space))
    //        print("ListCount = " + explosionObjectsList.Count);
    //}

}
