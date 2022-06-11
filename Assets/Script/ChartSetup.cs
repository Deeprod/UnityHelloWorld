using UnityEngine;

public class ChartSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] lineExpander; 
    private int lineID;
    public int lineModID;
    private float rotation; 
    public float currentX;
    public float currentY;


    private void Awake()
    {
       lineID = -1;
       rotation = 1.0f;
       AddNewLine(-8.0f, 0.0f, 0.0f); 
    }

    public void AddNewLine(float _x, float _y, float _z)
    {
        lineID += 1;

        // We cycle through the same lineExpander objects
        lineModID = lineID % lineExpander.Length;

        //Initialize rotation
        rotation = -Mathf.Sign(rotation) * Random.Range(0.0f, 89.0f);

        //We transform the lineExpander to have correct scale, position and rotation
        lineExpander[lineModID].transform.localScale = new Vector3(0.1f, 0.3f, 1.0f);
        lineExpander[lineModID].transform.position = new Vector3(_x,_y,_z);
        lineExpander[lineModID].transform.localRotation = Quaternion.Euler(0, 0, rotation); 

        //Now the LineExpander can start the expansion
        lineExpander[lineModID].GetComponent<LineExpander>().expandLine = true;

        //We turn off the sprit renderer as it should only pop when the line switch
        lineExpander[lineModID].GetComponent<LineExpander>().DisableColliderSprite();

        //Only on the first call, the lineExpander need to be activated
        if (lineID < lineExpander.Length)
            lineExpander[lineModID].SetActive(true);
    }

}
