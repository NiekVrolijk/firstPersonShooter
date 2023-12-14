using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class shooting : MonoBehaviour
{
    //var
    //raycast aiming
    public Camera cam;
    private Ray ray;
    private RaycastHit hit;

    //time to shoot
    private float shootTimer;
    private float canShoot = 0.2f;

    //for muzzle flash
    public GameObject muzzleFlash;
    private float muzzleFlashX;
    private float muzzleFlashY;
    private float muzzleFlashZ;
    private float flashDuration = 0.1f;
    //Start is called before the first frame update
    void Start()
    {
        //sets muzzle flash object to size 0f
        muzzleFlashX = 0f; muzzleFlashY = 0f; muzzleFlashZ = 0f;
        muzzleFlash.transform.localScale = new Vector3(muzzleFlashX, muzzleFlashY, muzzleFlashZ);
    }

    // Update is called once per frame
    void Update()
    {
        //keeps track of time
        shootTimer += Time.deltaTime;

        //if shoot timer is higher than flash duration(0.1 sec) make flash disappear
        if (flashDuration <= shootTimer) 
        {
            //sets muzzle flash object to size 0f
            muzzleFlashX = 0f; muzzleFlashY = 0f; muzzleFlashZ = 0f;
            muzzleFlash.transform.localScale = new Vector3(muzzleFlashX, muzzleFlashY, muzzleFlashZ);
        }

        //shoot if player presses left mouse button, and shoot timer is higher than than time after last bullet required to shoot
        if(Input.GetMouseButton(0) && canShoot <= shootTimer)
        {
            //makes muzzle flash appear
            muzzleFlashX = 0.1f; muzzleFlashY = 0.05f; muzzleFlashZ = 0.1f;
            muzzleFlash.transform.localScale = new Vector3(muzzleFlashX, muzzleFlashY, muzzleFlashZ);
            //binds ray to mouse position
            ray = cam.ScreenPointToRay(Input.mousePosition);
            //shoots raycast; if raycast hit's something and that something is an enemy, then it dies
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC"))
                {
                    Destroy(hit.collider.gameObject);
                }

            }
            //resets shoot timer to 0 after having shot
            shootTimer = 0f;
        }

    }
}
