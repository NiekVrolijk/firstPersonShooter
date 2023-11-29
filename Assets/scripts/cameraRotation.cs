using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    public Transform player;
    private float xMouse;
    private float yMouse;
    private float xRotation;
    public float speed = 500f;
//aiming
    public Camera cam;
    public float zoomMultiplier = 1.666667f;
    public float defaultFov = 90;
    public float zoomDuration = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        zoomMultiplier = 1f / 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        //makes camera follow mouse
       xMouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
       yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
       xRotation -= yMouse;
       xRotation = Mathf.Clamp(xRotation, -90f, 90f);
       transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       player.Rotate(Vector3.up * xMouse);

        //zoom in
        if (Input.GetMouseButton(1))
        {
            ZoomCamera(defaultFov / zoomMultiplier);
            speed = 300f;
        }
        else if (cam.fieldOfView != defaultFov)
        {
            ZoomCamera(defaultFov);
            speed = 500f;
        }

    }
    void ZoomCamera(float target)
    {
        float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
    }
}
