using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public Camera cam;

    private Ray ray;
    private RaycastHit hit;

    private float shootTimer;
    private float canShoot = 0.2f;

    public GameObject muzzleFlash;
    private float muzzleFlashX;
    private float muzzleFlashY;
    private float muzzleFlashZ;
    private float flashTime = 1f;
    private float flashTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        //flashTimer += Time.deltaTime;
        //muzzleFlash.transform.localScale = new Vector3(muzzleFlashX, muzzleFlashY, muzzleFlashZ);

        //if (flashTime >= flashTimer)
        //{
        //    muzzleFlashX = 0f; muzzleFlashY = 0f; muzzleFlashZ = 0f;
        //}

        if(Input.GetMouseButton(0) && canShoot <= shootTimer)
        {
            //flashTimer = 0f;
            //muzzleFlashX = 0.1f; muzzleFlashY = 0.05f; muzzleFlashZ = 0.1f;

            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC"))
                {
                    Destroy(hit.collider.gameObject);
                }

            }
            //muzzleFlash.transform.localScale = new Vector3(muzzleFlashX, muzzleFlashY, muzzleFlashZ);
            shootTimer = 0f;
        }

    }
}
