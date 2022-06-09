using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] lineContainer;
    private int lineContainerID;

    private void Awake()
    {
       lineContainerID = 0;
    }

    public void AddNewLine()
    {
        lineContainerID += 1;
        lineContainer[lineContainerID].transform.position = new Vector3(3,0,0);
        lineContainer[lineContainerID].SetActive(true);
    }
}
