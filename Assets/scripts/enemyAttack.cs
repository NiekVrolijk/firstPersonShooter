using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    private enemyMovement EnemyMovement;
    private Transform player;
    public float attackRange = 35;

    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;
    private bool moveRandomly;

    //enemy attack
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private float fireSpeed = 25;
    private float fireRange = 20;

    private float timer = 0f;
    private float canFire = 2f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player1").transform;
        EnemyMovement = GetComponent<enemyMovement>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        FireBullet();

        if (Vector3.Distance(transform.position, player.position) <= attackRange)
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

    private void FireBullet()
    {
        if (Vector3.Distance(transform.position, player.position) <= fireRange && timer >= canFire)
        {
            Debug.Log("enemy shot");
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            spawnedBullet.GetComponent<Rigidbody>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedBullet, 5);
            timer = 0f;
        }
    }
}