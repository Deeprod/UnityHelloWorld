using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] lineContainer;
    private int lineContainerID;
    private float rotation;

    private void Awake()
    {
       lineContainerID = -1;
       rotation = 1.0f;
       AddNewLine(-8.0f, 0.0f, 0.0f);
       
    }

    public void AddNewLine(float _x, float _y, float _z)
    {
        if(lineContainerID < lineContainer.Length - 1)
        {
            lineContainerID += 1;
            rotation = -Mathf.Sign(rotation) * Random.Range(0.0f, 89.0f);
            lineContainer[lineContainerID].transform.position = new Vector3(_x,_y,_z);
            lineContainer[lineContainerID].transform.localRotation = Quaternion.Euler(0, 0, rotation);
            lineContainer[lineContainerID].SetActive(true);
        }
    }
}
