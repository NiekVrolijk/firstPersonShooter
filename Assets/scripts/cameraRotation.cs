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

    public Camera cam;
    public float defaultFov = 90;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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

        if (!Input.GetMouseButtonDown(1))
        {
           speed = 500f;
           cam.fieldOfView = (defaultFov);
        }
        if (Input.GetMouseButton(1))
        {
            speed = 300f;
            cam.fieldOfView = (defaultFov * 0.60f);
        }

    }
}
