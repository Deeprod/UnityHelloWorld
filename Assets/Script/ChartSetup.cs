using UnityEngine;

public class ChartSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] lineExpander; 
    private int lineID;
    private int lineModID;
    private float rotation; 

    private void Awake()
    {
       lineID = -1;
       rotation = 1.0f;
       AddNewLine(-8.0f, 0.0f, 0.0f); 
    }

    public void AddNewLine(float _x, float _y, float _z)
    {
        lineID += 1;
        lineModID = lineID % lineExpander.Length;
        rotation = -Mathf.Sign(rotation) * Random.Range(0.0f, 89.0f);
        lineExpander[lineModID].transform.localScale = new Vector3(0.1f, 0.3f, 1.0f);
        lineExpander[lineModID].transform.position = new Vector3(_x,_y,_z);
        lineExpander[lineModID].transform.localRotation = Quaternion.Euler(0, 0, rotation); 
        lineExpander[lineModID].GetComponent<LineExpander>().expandLine = true;

        if (lineID < lineExpander.Length)
            lineExpander[lineModID].SetActive(true);
    }
}
