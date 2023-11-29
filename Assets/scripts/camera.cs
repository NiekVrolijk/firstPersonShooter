using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class camera : MonoBehaviour
{
    //var

    // x and z speed
    [SerializeField] private float currentSpeed;
    [SerializeField] public float walkingSpeed = 3f;
    [SerializeField] public float runningSpeed = 5f;
    [SerializeField] public float AirWSpeed = 2.1f;
    [SerializeField] public float AirRSpeed = 3.5f;
    
    //jump (y speed)
    public float gravity = -30f;
    private float baseLineGravity;
    public float jumpHeight = 3f;

    //double jump
    private int doubleJump;
    private int doubleJumpAmount = 1;
    private float jumpTimer;
    private float canJump = 0.4f;


    private Vector3 moveDirection;
    private Vector3 moveDirection2;
    private Vector3 moveDirectionX;
    private Vector3 moveDirectionZ;
    private Vector3 velocity;

    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;



    // Start is called before the first frame update
    void Start()
    {
        //makes default speed walking speed and baselinegravity = to gravity
        currentSpeed = walkingSpeed;
        baseLineGravity = gravity;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //reset doublejump
        if (characterController.isGrounded)
        {
            doubleJump = doubleJumpAmount;
        }
        //run double jump timer
        jumpTimer += Time.deltaTime;
    }

    private void Move()
    {
        //movement 

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float MoveZ = Input.GetAxis("Vertical");
        float MoveX = Input.GetAxis("Horizontal");

        moveDirectionZ = new Vector3(0, 0, MoveZ);
        moveDirectionX = new Vector3(MoveX, 0, 0);
        moveDirection = transform.TransformDirection(moveDirectionX + moveDirectionZ);

        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift) && characterController.isGrounded) //walk
        {
            Walk();
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift) && characterController.isGrounded) //run
        {
            Run();
        }

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift) && !characterController.isGrounded) //walk while in air
        {
            AirWalk();
        }
        else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift) && !characterController.isGrounded) //run while in air
        {
            AirRun();
        }

        if (Input.GetKey(KeyCode.Space) && doubleJump > 0 && canJump <= jumpTimer && !characterController.isGrounded) // jump
        {
            jump();
            //double jump
            doubleJump -= 1;
            jumpTimer = 0f;
        }

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space) && canJump <= jumpTimer) // jump
            {
                jump();
                jumpTimer = 0f;
            }

            if (moveDirection != Vector3.zero)// idle
            {
                idle();
            }
        }
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; // applies gravity
        characterController.Move(velocity * Time.deltaTime);
    }
    private void Walk()
    {
        moveDirection *= walkingSpeed;
    }
    private void Run()
    {
        moveDirection *= runningSpeed;
    }

    private void AirWalk()
    {
        moveDirection *= AirWSpeed;
    }
    private void AirRun()
    {
        moveDirection *= AirRSpeed;
    }

    private void jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    private void idle()
    {

    }
}

