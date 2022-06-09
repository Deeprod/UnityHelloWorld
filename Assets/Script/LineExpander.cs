using UnityEngine;

public class LineExpander : MonoBehaviour
{
    private float speed; 
    private GameObject chart;
    public bool expandLine;
    private float maxTime;
    private float cumTime;
    private float lineWidth;

    private void Awake()
    {
        expandLine = true;

        speed = 25;
        maxTime = Random.Range(0.1f, 0.4f);
        lineWidth = 0.4f; 

        chart = transform.parent.parent.gameObject;
    }

    private void Update()
    {
        if(expandLine)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * speed, lineWidth, transform.localScale.z);
            cumTime += Time.deltaTime;
            if(cumTime >= maxTime)
            {
                expandLine = false;
                chart.GetComponent<ChartSetup>().AddNewLine(transform.Find("LineCollider").position.x, transform.Find("LineCollider").position.y, transform.Find("LineCollider").position.z);
            }
        } 
    }  

    public void StopExpand()
    {
        expandLine = false;
    }
}
