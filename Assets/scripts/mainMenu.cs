using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if enter is pressed, start game (reset HP) for if you play again.
        if (Input.GetKey(KeyCode.Return))
        {
            cameraScript.playerHealth = 100;
            SceneManager.LoadScene("map1");
        }
    }
}