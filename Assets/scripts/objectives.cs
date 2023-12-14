using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectives : MonoBehaviour
{
    private Transform player;

    private float xPosition;
    private float yPosition;
    private float zPosition;
    private float goingDownSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player1").transform;

        xPosition = transform.localPosition.x;
        yPosition = transform.localPosition.y;
        zPosition = transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    { //ahahhh
        if (player.position.y > transform.position.y &&
             player.position.x < transform.position.x + 10f &&
             player.position.z < transform.position.x + 10f)
        {
            yPosition = Mathf.Clamp(yPosition, 0f, 20f);
            yPosition = yPosition - goingDownSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
        }
        if (player.position.y > transform.position.y &&
             player.position.x > transform.position.x + -10f &&
             player.position.z < transform.position.x + 10f)
        {
            yPosition = Mathf.Clamp(yPosition, 0f, 20f);
            yPosition = yPosition - goingDownSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
        }
        if (player.position.y > transform.position.y &&
             player.position.x > transform.position.x + -10f &&
             player.position.z > transform.position.x + -10f)
        {
            yPosition = Mathf.Clamp(yPosition, 0f, 20f);
            yPosition = yPosition - goingDownSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
        }
        if (player.position.y > transform.position.y &&
             player.position.x < transform.position.x + 10f &&
             player.position.z > transform.position.x + -10f)
        {
            yPosition = Mathf.Clamp(yPosition, 0f, 20f);
            yPosition = yPosition - goingDownSpeed * Time.deltaTime;
            transform.localPosition = new Vector3(xPosition, yPosition, zPosition);
        }
    }
}
