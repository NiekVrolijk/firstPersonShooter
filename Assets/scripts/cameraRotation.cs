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
    public float zoomMultiplier = 1.666667f;
    public float defaultFov = 90;
    public float zoomDuration = 0.1f;

    //recoil
    public float recoil;
    public float recoilSpeed = 0.1f;
    public Quaternion rotation1;
    public Quaternion rotation2;
    bool isRecoiling = false;

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
            speed = 400f;
        }
        else if (cam.fieldOfView != defaultFov)
        {
            ZoomCamera(defaultFov);
            speed = 700f;
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
    void ZoomCamera(float target)
    {
        float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
    }
}
