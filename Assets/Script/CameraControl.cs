using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject axisY;
    [SerializeField] private GameObject axisX;
    [SerializeField] private float axisYOffset;
    [SerializeField] private float axisXOffset;
    //[SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float cameraOffsetX;
    [SerializeField] private float cameraOffsetY;
    //private float lookAhead;
    public float currentX;
    public float currentY;
    private float upperCameraLimit;
    private float lowerCameraLimit;

    private void Update()
    {
        //Follow Player test
        //transform.position = new Vector3(Mathf.Max(player.position.x + lookAhead, 0), transform.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        
        upperCameraLimit = transform.position.y + cameraOffsetY;
        lowerCameraLimit = transform.position.y - cameraOffsetY; 

        if (currentY > upperCameraLimit)
            transform.position = new Vector3(currentX - cameraOffsetX, transform.position.y + currentY - upperCameraLimit, transform.position.z);
        else if (currentY < lowerCameraLimit)
            transform.position = new Vector3(currentX - cameraOffsetX, transform.position.y + currentY - lowerCameraLimit, transform.position.z);
        else
            transform.position = new Vector3(currentX - cameraOffsetX, transform.position.y, transform.position.z);

        axisY.transform.position = new Vector3(currentX - cameraOffsetX - axisYOffset, axisY.transform.position.y, axisY.transform.position.z);
        axisX.transform.position = new Vector3(currentX - cameraOffsetX - axisYOffset, lowerCameraLimit - axisXOffset, axisX.transform.position.z);

        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void SetCurrentXY(float _x, float _y)
    {
        currentX = _x;
        currentY = _y;
    }
    
}
