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
    
    private void Awake()
    {
        chart = transform.parent.gameObject;
        camera = GameObject.Find("Main Camera");
        expandLine = true; 
        maxTime = Random.Range(0.4f, 1.0f);
    }

    private void Update()
    {
        if(expandLine)
        {
            transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * speed, lineWidth, transform.localScale.z);

            //We update the camera position each frame based on the LineCollider position
            camera.GetComponent<CameraControl>().SetCurrentXY(LineCollider.transform.position.x,
                                                              LineCollider.transform.position.y);

            cumTime += Time.deltaTime;

            if(cumTime >= maxTime)
            {
                //We rest cumTime as when the object is called and enabled again later on, it will start the countdown again
                cumTime = 0;

                //We stop expanding the sprite since it reached destination
                expandLine = false;

                //If a parent is scaled, so its children. So we undo the parents scaling to restablish original shape
                LineCollider.GetComponent<Transform>().localScale = new Vector3(1/transform.localScale.x,
                                                                                1/transform.localScale.y,
                                                                                1/transform.localScale.z);

                //LineCollider.GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 90); 

                //We enable the sprite renderer to show the connector sprite
                LineCollider.GetComponent<SpriteRenderer>().enabled = true;

                //We create a new line starting from where the collider is
                chart.GetComponent<ChartSetup>().AddNewLine(LineCollider.transform.position.x, 
                                                            LineCollider.transform.position.y, 
                                                            LineCollider.transform.position.z);
            }
        } 
    }  

    public void DisableColliderSprite()
    {
        LineCollider.GetComponent<SpriteRenderer>().enabled = false;
    }
}
