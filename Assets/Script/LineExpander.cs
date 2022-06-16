using UnityEngine;

public class LineExpander : MonoBehaviour
{
    private GameObject chart;
    private GameObject camera;
    public bool expandLine;

    [SerializeField] private float speed; 
    [SerializeField] private float lineWidth;
    [SerializeField] private GameObject LineCollider;

    private float maxTime;
    private float cumTime;
    private float cumTimeLast;
    
    private void Awake()
    {
        chart = GameObject.Find("Chart"); //transform.parent.gameObject;
        camera = GameObject.Find("Main Camera");
        expandLine = true; 
        maxTime = 0.4f;
    }

    private void Update()
    {
        if(expandLine)
        {
            cumTimeLast = cumTime;
            cumTime += Time.deltaTime;

            if(cumTime < maxTime)
            {
                transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * speed, lineWidth, transform.localScale.z);

                //We update the camera position each frame based on the LineCollider position
                camera.GetComponent<CameraControl>().SetCurrentXY(LineCollider.transform.position.x,
                                                                LineCollider.transform.position.y);
            } 
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + (maxTime - cumTimeLast) * speed, lineWidth, transform.localScale.z);

                //We rest cumTime as when the object is called and enabled again later on, it will start the countdown again
                cumTime = 0;

                //We stop expanding the sprite since it reached destination
                expandLine = false;

                //We create a new line starting from where the collider is
                chart.GetComponent<ChartSetup>().AddNewLine(LineCollider.transform.position.x, 
                                                            LineCollider.transform.position.y, 
                                                            LineCollider.transform.position.z);
            }
        } 
    }  
}
