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

    private float moveX;
    private float moveZ;
    private Vector3 move;



    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
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
        //if (Input.GetKey(KeyCode.W) /*&& transform.position.y < maxYValue*/)
        //{

        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S) /*&& transform.position.y > -maxYValue*/)
        //{

        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D) /*&& transform.position.x < maxXValue*/)
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A) /*&& transform.position.x > -maxXValue*/)
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
    }
}
