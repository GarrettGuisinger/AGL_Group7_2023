using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed;
    public Vector2 mousedelta;
 
    float pitch;
    float yaw;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        pitch += rotationSpeed * Input.GetAxis("Mouse Y");
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
       
        // Clamp pitch:
        pitch = Mathf.Clamp(pitch, -90f, 90f);
       
        // Wrap yaw:
        while (yaw < 0f) {
            yaw += 360f;
        }
        while (yaw >= 360f) {
            yaw -= 360f;
        }
       
        // Set orientation:
        transform.eulerAngles = new Vector3(-pitch, yaw, 0f);

        mousedelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
