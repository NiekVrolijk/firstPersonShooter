using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private enemyMovement EnemyMovement;
    public Transform player;
    public float attackRange = 10f;

    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;
    private bool moveRandomly;


    private void Awake()
    {
        EnemyMovement = GetComponent<enemyMovement>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) <= attackRange) 
        {
            rend.sharedMaterial = attackMaterial;
            EnemyMovement.badEnemy.SetDestination(player.position);
            moveRandomly = true;
        }
        else
        {
            rend.sharedMaterial = defaultMaterial;
            if (moveRandomly)
            {
                EnemyMovement.RandomMove();
            }
            moveRandomly = false;
        }
    }

    
}
