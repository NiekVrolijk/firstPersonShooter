using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class damageScript : MonoBehaviour
{
    ////player slowed time
    //private float timer;
    //private float timeSlowed = 2f;
    //private bool hasBeenSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //timer += Time.deltaTime;

        //if (timer >= timeSlowed)
        //{
        //    cameraScript.walkingSpeed = Mathf.Clamp(cameraScript.walkingSpeed, 1.5f, 3f);
        //    cameraScript.runningSpeed = Mathf.Clamp(cameraScript.runningSpeed, 2.5f, 5f);
        //    cameraScript.AirWSpeed = Mathf.Clamp(cameraScript.AirWSpeed, 1.05f, 2.1f);
        //    cameraScript.AirRSpeed = Mathf.Clamp(cameraScript.AirRSpeed, 1.75f, 3.5f);

        //    cameraScript.walkingSpeed += 0.3f;
        //    cameraScript.runningSpeed += 0.5f;
        //    cameraScript.AirWSpeed += 0.21f;
        //    cameraScript.AirRSpeed += 0.35f;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if bullet hit player
        if (collision.gameObject.CompareTag("player1"))
        {
            //take away 3 HP form player and destroy bullet
            cameraScript.playerHealth -= 3;

            ////player slowed
            //cameraScript.walkingSpeed = Mathf.Clamp(cameraScript.walkingSpeed, 1.5f, 3f);
            //cameraScript.runningSpeed = Mathf.Clamp(cameraScript.runningSpeed, 2.5f, 5f);
            //cameraScript.AirWSpeed = Mathf.Clamp(cameraScript.AirWSpeed, 1.05f, 2.1f);
            //cameraScript.AirRSpeed = Mathf.Clamp(cameraScript.AirRSpeed, 1.75f, 3.5f);

            //cameraScript.walkingSpeed -= 0.3f;
            //cameraScript.runningSpeed -= 0.5f;
            //cameraScript.AirWSpeed -= 0.21f;
            //cameraScript.AirRSpeed -= 0.35f;
            //timer = 0;
            
            //destroy's self
            Destroy(gameObject);
        }
    }
}
