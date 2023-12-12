using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if bullet hit player
        if (collision.gameObject.CompareTag("player1"))
        {
            //take away 3 HP form player and destroy bullet
            cameraScript.playerHealth -= 3;
            Destroy(gameObject);
        }
    }
}
