using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    //var

    //float maxXValue = 8.6f;
    //float maxYValue = 4.7f;
    [SerializeField]
    private float currentSpeed;
    public float walkingSpeed = 5f;
    public float runningSpeed = 10f;

    public float gravity = -0.3f;
    private float baseLineGravity;
    public float jumpSpeed = 0.8f;

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
    }

    // Update is called once per frame
    void Update()
    {
        //movement 
        //Debug.Log(characterController.isGrounded);
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
    //gravity
        move = transform.right * moveX + 
               transform.up * gravity +
               transform.forward * moveZ;

        //run
        characterController.Move(move);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
        } else
        {
            currentSpeed = walkingSpeed;
        }

        //jump
        if (characterController.isGrounded && Input.GetKey(KeyCode.Space))
        {
            gravity = baseLineGravity;
            gravity *= -jumpSpeed;
        }

        if (gravity > baseLineGravity)
        {
            gravity -= 2 * Time.deltaTime;
        }
    }
}
