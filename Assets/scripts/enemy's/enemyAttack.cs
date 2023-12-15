using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    //locate player and form what distance should the enemy follow player (and connecting to enemyMovement script)
    private enemyMovement EnemyMovement;
    private Transform player;
    public float attackRange = 50;

    //enemy change collor when seeing player (within the 35)
    public Material defaultMaterial;
    public Material attackMaterial;
    private Renderer rend;
    private bool moveRandomly;

    //enemy attack/shoot
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private float fireSpeed = 25; //bullet speed
    private float fireRange = 20; //can shoot at player within this range
    //enemy attack/shoot timer
    private float timer = 0f;
    private float canFire = 2f;

    private void Awake()
    {
        //locate player and get components from enemy movement script
        player = GameObject.FindGameObjectWithTag("player1").transform;
        EnemyMovement = GetComponent<enemyMovement>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //timer for time between enemy attacks and enemy attack script.
        timer += Time.deltaTime;
        FireBullet();

        //if player within attackrange(should be follow range really) follow player
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = attackMaterial;
            EnemyMovement.badEnemy.SetDestination(player.position);
            moveRandomly = true;
        }
        //if not move randomly as stated in enemyMovement script
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
        //if player within fire range and it has been 2 sec sinds last shot, then fire
        if (Vector3.Distance(transform.position, player.position) <= fireRange && timer >= canFire)
        {
            //look where the bullet needs to start
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            //then look where it should go and how fast
            Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            spawnedBullet.GetComponent<Rigidbody>().velocity = directionToPlayer * fireSpeed;
            //destroy bullet after 5 sec and reset timer
            Destroy(spawnedBullet, 5);
            timer = 0f;
        }
    }
}