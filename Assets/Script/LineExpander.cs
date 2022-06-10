using UnityEngine;

public class LineExpander : MonoBehaviour
{
    private GameObject chart;
    public bool expandLine;
    [SerializeField] private float speed; 
    [SerializeField] private float lineWidth;
    [SerializeField] private GameObject LineCollider;
    private float maxTime;
    private float cumTime;
    
    private void Awake()
    {
        chart = transform.parent.gameObject;
        expandLine = true; 
        maxTime = Random.Range(0.2f, 0.3f);
    }

    private void Update()
    {
        if(expandLine)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * speed, lineWidth, transform.localScale.z);
            cumTime += Time.deltaTime;
            if(cumTime >= maxTime)
            {
                cumTime = 0;
                expandLine = false;
                LineCollider.GetComponent<Transform>().localScale = new Vector3(1/transform.localScale.x,1/transform.localScale.y,1/transform.localScale.z);
                LineCollider.GetComponent<SpriteRenderer>().enabled = true;
                chart.GetComponent<ChartSetup>().AddNewLine(transform.Find("LineCollider").position.x, 
                                                            transform.Find("LineCollider").position.y, 
                                                            transform.Find("LineCollider").position.z);
            }
        } 
    }  
}
