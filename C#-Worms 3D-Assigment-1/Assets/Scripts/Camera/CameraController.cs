

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    private float yawSpeed = 400f; 
    
    
    

    private float currentZoom = 10f;
    private float currentYaw = 0f;

    

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);


        currentYaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

       


    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        
        transform.RotateAround(target.position, Vector3.up, currentYaw );
    }

   /* void RotateWithMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        currentYaw += Input.GetAxis("Mouse X") * yawSpeed * Time.deltaTime;
        
    } */
}
