using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private float swapDelay; 
    //private float rotationSpeed;
    
    private void Awake()
    {
        //rotationSpeed = 0.0f;
    }

    private void Update()
    {

        //rotationSpeed += 75.0f;
        //if(rotationSpeed > 360.0f)
        //    rotationSpeed -= 360;

        transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * speed, transform.localScale.y, transform.localScale.z);
        //transform.localRotation = Quaternion.Euler(0, 0, rotationSpeed);
       
    }  

}
