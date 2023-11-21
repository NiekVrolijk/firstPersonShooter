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

    public float gravity = -0.5f;
    private float baseLineGravity;
    public float jumpSpeed = 0.8f;

    private float moveX;
    private float moveZ;
    private Vector3 move;

    public CharacterController characterController;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
        rb = GetComponent<Rigidbody>();
        baseLineGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(characterController.isGrounded);
        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * moveX + 
               transform.up * gravity +
               transform.forward * moveZ;

        characterController.Move(move);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runningSpeed;
        } else
        {
            currentSpeed = walkingSpeed;
        }


        if (characterController.isGrounded /*&& Input.GetButtonDown("jump")*/ && Input.GetKey(KeyCode.Space))
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
