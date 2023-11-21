using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent badEnemy;
    // Start is called before the first frame update
    void Start()
    {
        badEnemy.SetDestination(new Vector3(20f, 0f, 5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
