using UnityEngine;

public class ChartSetup : MonoBehaviour
{
    [SerializeField] private GameObject[] lineExpander; 
    [SerializeField] private GameObject[] lineConnector; 
    private int lineID;
    public int lineModID;
    private int connectorID;
    public int connectorModID;
    private float rotation; 
    public float currentX;
    public float currentY;

    // Calibration variables
    public float lineConnectorLastX;
    public float lineConnectorLastY;

    private void Awake()
    {
       lineID = -1;
       connectorID = -1;
       rotation = -1.0f;
       AddNewLine(0.0f, 0.0f, 0.0f); 
    }

    public void AddNewLine(float _x, float _y, float _z)
    {
        lineID += 1;
        connectorID += 1;

        // We cycle through the same lineExpander objects
        lineModID = lineID % lineExpander.Length;
        connectorModID = connectorID % lineConnector.Length;

        //Initialize rotation
        rotation = -Mathf.Sign(rotation) * Random.Range(60.0f, 80.0f);

        //We transform the lineExpander to have correct scale, position and rotation
        lineExpander[lineModID].transform.localScale = new Vector3(0.1f, 0.3f, 1.0f);
        lineExpander[lineModID].transform.position = new Vector3(_x,_y,_z);
        lineExpander[lineModID].transform.localRotation = Quaternion.Euler(0, 0, rotation); 



        //3.2332






        Debug.Log("lX:" + lineConnectorLastX + " // X :" + _x + " // lY:" + lineConnectorLastY + " // Y :" + _y + " ////// " + Mathf.Sqrt(Mathf.Pow(lineConnectorLastX - _x, 2)+Mathf.Pow(lineConnectorLastY - _y, 2)));

        lineConnectorLastX = _x;
        lineConnectorLastY = _y; 









        //We set the position of the connector
        lineConnector[connectorModID].transform.position = new Vector3(_x,_y,_z);
        //Only on the first call, the lineConnector needs to be activated
        if (connectorID < lineConnector.Length)
            lineConnector[connectorModID].SetActive(true);

        //Now the LineExpander can start the expansion
        lineExpander[lineModID].GetComponent<LineExpander>().expandLine = true;
        //Only on the first call, the lineExpander needs to be activated
        if (lineID < lineExpander.Length)
            lineExpander[lineModID].SetActive(true);
    }

}
