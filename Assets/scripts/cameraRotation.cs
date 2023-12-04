using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraRotation : MonoBehaviour
{
    public Transform player;
    private float xMouse;
    private float yMouse;
    private float xRotation;
    public float speed = 700f;
    //aiming
    public Camera cam;
    private float zoomMultiplier = 1.666667f;
    private float defaultFov = 90;
    private float zoomDuration = 0.1f;
    //gun aiming
    public GameObject gun;
    public float gunXPosition;
    //recoil
    public float recoil;
    public float recoilSpeed = 0.1f;
    public Quaternion rotation1;
    public Quaternion rotation2;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        zoomMultiplier = 1f / 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        gun.transform.localPosition = new Vector3(gunXPosition, -0.374f, -0.031f);
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
            ZoomCamera(defaultFov / zoomMultiplier, -0.38f);
            speed = 400f;
            //gunXPosition = -0.38f;
        }
        else if (cam.fieldOfView != defaultFov)
        {
            ZoomCamera(defaultFov, 0.221f);
            speed = 700f;
            //gunXPosition = 0.221f;
        }
       
        if (Input.GetMouseButton(0))
        {
            RecoilCamera();
            
        }
    }
    private void RecoilCamera()
    {
        
        recoil = Random.Range(-5, -1);
        rotation1 = Quaternion.Euler(xRotation, 0f, 0f);
        rotation2 = Quaternion.Euler(xRotation + recoil, 0f, 0f);
        transform.localRotation = Quaternion.Slerp(rotation1, rotation2, recoilSpeed * Time.deltaTime);
        //Debug.Log(rotation1 + " " + rotation2 + " " + recoilSpeed);
        //xRotation = Mathf.MoveTowards(xRotation, xRotation + recoil, recoilSpeed * Time.deltaTime);
    }
    void ZoomCamera(float target, float LTarget)
    {
        //float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        //cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
        //gunXPosition = Mathf.MoveTowards(gunXPosition, LTarget, angle / zoomDuration * Time.deltaTime);

        //float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);

        //// Smoothly interpolate camera field of view
        //cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);

        //// Calculate the percentage of completion for the interpolation
        //float t = 1.0f - (cam.fieldOfView - defaultFov) / (target - defaultFov);

        //// Smoothly interpolate a separate variable for gun position based on the percentage of completion
        //float smoothGunXPosition = Mathf.Lerp(gunXPosition, LTarget, t);
        
        //gun.transform.localPosition = new Vector3(smoothGunXPosition, -0.374f, -0.031f);
        
       
    }
}
