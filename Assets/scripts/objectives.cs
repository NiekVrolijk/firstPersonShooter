using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectives : MonoBehaviour
{
    private Transform player;

    private float xPosition;
    private float yPosition;
    private float zPosition;
    private float goingDownSpeed = 2.4f;
    private float goingUpSpeed = 0.8f;

    private float timer;
    private float goUpTime = 30f;

    private bool objectionCapped = false;
    private float lowEnough = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player1").transform;

        xPosition = transform.position.x;
        yPosition = transform.position.y;
        zPosition = transform.position.z;

        objectionCapped = false;
    }

    // Update is called once per frame
    void Update()
    { //aaaahhhhhhh
        timer += Time.deltaTime;
        if (player.position.y > transform.position.y &&
             player.position.x <= transform.position.x + 10f &&
             player.position.x >= transform.position.x - 10f &&
             player.position.z <= transform.position.z + 10f &&
             player.position.z >= transform.position.z - 10f
             )
        {
            yPosition = Mathf.Clamp(yPosition, 0.5f, 20f);
            yPosition = yPosition - goingDownSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
            timer = 0f;
        }
        else if (timer >= goUpTime)
        {
            yPosition = Mathf.Clamp(yPosition, 0.5f, 20f);
            yPosition = yPosition + goingUpSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
        }
        if (objectionCapped == false)
        {
            if (transform.position.y <= lowEnough)
            {
                cameraScript.objectivesCaptured += 1;
                objectionCapped = true;
                Debug.Log("ahhhh");
            }
        }
        if (objectionCapped == true)
        {
            if (transform.position.y >= lowEnough)
            {
                cameraScript.objectivesCaptured -= 1;
                objectionCapped = false;
            }
        }
    }
}
