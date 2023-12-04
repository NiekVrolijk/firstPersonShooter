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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;

        if(Input.GetMouseButton(0) && canShoot <= shootTimer)
        {
            Debug.Log("shoot");
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag.Equals("NPC"))
                {
                    Destroy(hit.collider.gameObject);
                }

            }
            shootTimer = 0f;
        }
    }
}
