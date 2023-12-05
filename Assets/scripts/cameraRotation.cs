using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraRotation : MonoBehaviour
{
    public Transform player;
    private float xMouse;
    public float yMouse;
    private float xRotation;
    public float speed = 700f;
    //aiming
    public Camera cam;
    private float zoomMultiplier = 1.666667f;
    private float defaultFov = 90;
    private float zoomDuration = 0.1f;
    //gun aiming
    public GameObject gun;
    private float gunXPosition;
    //recoil
    //public float recoil;
    //private float recoilSpeed = 0.8f;
    //private Quaternion rotation1;
    //private Quaternion rotation2;
    //private bool recoilCheck;
    //private float shootTimer;
    //private float canShoot = 0.2f;

    ////private Vector3 currentRotation;
    ////private Vector3 targetRotation;

    ////[SerializeField] private float recoilX;
    ////[SerializeField] private float recoilY;
    ////[SerializeField] private float recoilZ;

    ////[SerializeField] private float snappiness;
    ////[SerializeField] private float returnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        zoomMultiplier = 1f / 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        ////targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        ////currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.deltaTime);
        ////transform.localRotation = Quaternion.Euler(currentRotation);


        //shootTimer += Time.deltaTime;
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
            speed = 400f; //was 40
            //gunXPosition = -0.38f;
        }
        else if (cam.fieldOfView != defaultFov)
        {
            ZoomCamera(defaultFov, 0.221f);
            speed = 700f; //was 70
            //gunXPosition = 0.221f;
        }
       
        if (Input.GetMouseButton(0)/* && canShoot <= shootTimer*/)
        {
            //recoilCheck = true;
            RecoilCamera();
            //shootTimer = 0f;
        }

        //if(recoilCheck)
        //{
        //    transform.localRotation = Quaternion.Slerp(rotation1, rotation2, recoilSpeed * Time.deltaTime);
        //}
    }
    private void RecoilCamera()
    {

        //recoil = Random.Range(-1f, -5f);
        //rotation1 = Quaternion.Euler(transform.localRotation.x, 0f, 0f);
        //rotation2 = Quaternion.Euler(transform.localRotation.x + recoil, 0f, 0f);


        ////targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));

    }
    void ZoomCamera(float target, float LTarget)
    {
        float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
        cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
        gunXPosition = Mathf.MoveTowards(gunXPosition, LTarget, angle / zoomDuration * Time.deltaTime);
    }
}
