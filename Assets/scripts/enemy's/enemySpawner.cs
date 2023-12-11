using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public GameObject enemyOG;
    public int enemyMax = 50;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyMax; i++)
        {
            GameObject enemy = Instantiate(enemyOG);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
