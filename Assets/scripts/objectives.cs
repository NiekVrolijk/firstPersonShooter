using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectives : MonoBehaviour
{
    //get player transform info
    private Transform player;

    //position floats
    private float xPosition;
    private float yPosition;
    private float zPosition;
    //flatform speed going down and going up
    private float goingDownSpeed = 2.4f;
    private float goingUpSpeed = 0.8f;

    //timer and time before platform starts moving up again
    private float timer;
    private float goUpTime = 30f;

    //bool for if the flatform is down (and a little give so you don't have to put all platforms perfectly on the ground
    private bool objectionCapped = false;
    private float lowEnough = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //get player transform info
        player = GameObject.FindGameObjectWithTag("player1").transform;

        //link position floats to actual position (could've used a vector3 IK)
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;

        //sets if the flatform is capped to false
        objectionCapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        //run timer
        timer += Time.deltaTime;
        //looks if player is above platform (over 100 meters above it), so you can jump while on the flatform.
        if (player.position.y > transform.position.y &&
             player.position.x <= transform.position.x + 10f &&
             player.position.x >= transform.position.x - 10f &&
             player.position.z <= transform.position.z + 10f &&
             player.position.z >= transform.position.z - 10f
             )
        {
            //move platform down
            //makes flatform not go higher than original position and not go through the floor
            yPosition = Mathf.Clamp(yPosition, 0.5f, 20f);
            //moves platform down
            yPosition = yPosition - goingDownSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
            //resets timer
            timer = 0f;
        }
        //if it's been more than 30 sec move platform up
        else if (timer >= goUpTime) 
        {
            //makes flatform not go higher than original position and not go through the floor
            yPosition = Mathf.Clamp(yPosition, 0.5f, 20f);
            //moves platform up
            yPosition = yPosition + goingUpSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
        }

        //makes sure that if a platform is down it's "capped" and if it moves up again then it is "upcapped"
        //if not capped
        if (objectionCapped == false)
        {
            //and platform is low enough to be capped
            if (transform.position.y <= lowEnough)
            {
                //then add point to objectives capped
                cameraScript.objectivesCaptured += 1;
                //and cap objective
                objectionCapped = true;
            }
        }
        //if cappedn
        if (objectionCapped == true)
        {
            //and higher than a capped position
            if (transform.position.y >= lowEnough)
            {
                //take away the capped point
                cameraScript.objectivesCaptured -= 1;
                //set capped to false
                objectionCapped = false;
            }
        }
    }
}
