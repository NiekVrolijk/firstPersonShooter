using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    //var
    //what do i clone and how many of em do i make?
    public GameObject enemyOG;
    public int enemyMax = 50;

    private float timer = 0f;
    private float canspawn = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //loop until all enemy's are spawned
        for (int i = 0; i < enemyMax; i++)
        {
            GameObject enemy = Instantiate(enemyOG);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= canspawn)
        {
            GameObject enemy = Instantiate(enemyOG);
            timer = 0f;
        }
    }
}
