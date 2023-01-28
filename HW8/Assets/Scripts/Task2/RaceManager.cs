using UnityEngine;
using System;

public class RaceManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] runners;

    private Runner currentRunner;
    private int indexRunner = 0;
    [SerializeField]
    private int nextIndexRunner; 

    private float passDistance = 0.5f;

    private void Start()
    {
        for (int i = 0; i < runners.Length; i++)
        {
            Runner runner = runners[i].GetComponent<Runner>();
            if (runner == null)
                throw new Exception($"There is no Runner component at {runners[i].name}");
        }

        currentRunner = runners[indexRunner].GetComponent<Runner>();
        nextIndexRunner = indexRunner + 1;
    }

    private void FixedUpdate()
    {
        currentRunner.Run(runners[nextIndexRunner].transform);
        currentRunner.LookForward(runners[nextIndexRunner].transform);

        if (DistanceBetweenRunners() < passDistance)
            SwitchRunner();
    }

    private float DistanceBetweenRunners() 
    {
        Vector3 currentRunnerPosition = currentRunner.transform.position;
        Vector3 nexttRunnerPosition = runners[nextIndexRunner].transform.position;

        float distanceBetweenRunners = Vector3.Distance(currentRunnerPosition, nexttRunnerPosition);
        return distanceBetweenRunners;
    }

    private void SwitchRunner() 
    {
        if (nextIndexRunner == 0)
            indexRunner = -1;

        indexRunner++;
        nextIndexRunner++;

        if (indexRunner == runners.Length - 1)
            nextIndexRunner = 0;

        currentRunner = runners[indexRunner].GetComponent<Runner>();
    }
}
