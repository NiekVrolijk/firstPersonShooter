using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraRotation : MonoBehaviour
{
    //var
    //for looking around
    public Transform player;
    private float xMouse;
    public float yMouse;
    private float xRotation;
    //mouse sensitivity
    public float speed = 700f;

    //zooming in while aiming down sights
    public Camera cam;
    private float zoomMultiplier = 1.666667f;
    private float defaultFov = 90;
    private float zoomDuration = 0.1f;
    //gun position changed while aiming down sights
    public GameObject gun;
    private float gunXPosition;

    // Start is called before the first frame update
    void Start()
    {
        //locks curser to center
        Cursor.lockState = CursorLockMode.Locked;

        //sets zoom multiplier (desides how much cam zooms in while aiming down sights)
        zoomMultiplier = 1f / 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        //sets gun y and z values to basic, and x value according to if the player is ADS(ing)
        gun.transform.localPosition = new Vector3(gunXPosition, -0.374f, -0.031f);

        //makes camera follow mouse
        xMouse = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * speed * Time.deltaTime;
        xRotation -= yMouse;
        //makes sure you cant look behind you upside down and binds xRotation to the x rotation of the cam
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * xMouse);

        //zooms in, changes gun position and changes mouse sensitivity 
        if (Input.GetMouseButton(1))
        {
            ZoomCamera(defaultFov / zoomMultiplier, -0.38f);
            //mouse sensitivity 
            speed = 400f; 
        }
        else if (cam.fieldOfView != defaultFov)
        {
            ZoomCamera(defaultFov, 0.221f);
            //mouse sensitivity 
            speed = 700f; 
        }
    }
    void ZoomCamera(float target, float LTarget)
    {
        //changes field of view
        float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
        //changes gun position
        gunXPosition = Mathf.MoveTowards(gunXPosition, LTarget, angle / zoomDuration * Time.deltaTime);
    }
}
