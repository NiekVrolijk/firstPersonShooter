using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public NavMeshAgent badEnemy;
    public float squereOfMovement = 20f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPosition;
    private float zPosition;
    private float yPosition;
    public float closeEnough = 2;
    // Start is called before the first frame update
    void Start()
    {
       
        xMin = -squereOfMovement;
        xMax = squereOfMovement;
        zMin = -squereOfMovement;
        zMax = squereOfMovement;
        
        RandomMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            RandomMove();
        }
    }

    private void RandomMove()
    {
        xPosition = Random.Range(xMin, xMax);
        zPosition = Random.Range(zMin, zMax);
        yPosition = transform.position.y;
        badEnemy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}
