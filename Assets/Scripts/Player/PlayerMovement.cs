using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float jumpForce = 7.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    public float speed = 7.0f;
    private float turnSpeed = 0.05f;
    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = right
    public int laneDistance = 40;
    public bool isGrounded;
    public bool gameStarted = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) gameStarted = true;
        //if (!gameStarted)
        {

        }
        if (gameStarted)
        {
            //Inputkeys
            if (Input.GetKeyDown(KeyCode.A)) MoveLane(false);

            if (Input.GetKeyDown(KeyCode.D)) MoveLane(true);

            //calculation where in future
            Vector3 targetPosition = transform.position.z * Vector3.forward;

            if (desiredLane == 0) targetPosition += Vector3.left * laneDistance;
            else if (desiredLane == 2) targetPosition += Vector3.right * laneDistance;

            Vector3 moveVector = Vector3.zero;
            moveVector.x = (targetPosition - transform.position).normalized.x * speed;
            moveVector.y = -0.1f;
            moveVector.z = speed;

            //bool isGrounded = IsGrounded();
            //calculate y
            if (IsGrounded())
            {
                verticalVelocity = -0.1f;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalVelocity = jumpForce;
                    Debug.Log("hallo ik jump");
                }
            }
            else
            {
                verticalVelocity -= (gravity * Time.deltaTime);

                //faster going down
                if (Input.GetKeyDown(KeyCode.Space)) verticalVelocity = -jumpForce;

                moveVector.y = verticalVelocity;
                moveVector.z = speed;
            }

            //move the player
            controller.Move(moveVector * Time.deltaTime);

            //rotation when turns
            Vector3 direction = controller.velocity;
            if (direction != Vector3.zero)
            {
                direction.y = 0;
                transform.forward = Vector3.Lerp(transform.forward, direction, turnSpeed);
            }

            
        }
    }

    //checks which lane player is, moves player in 3 lanes, 0,1,2
    private void MoveLane(bool goingRight)
    {
        /*if (!goingRight)
        {
            desiredLane--;
            if (desiredLane == -1) desiredLane = 0;
        }
        else
        {
            desiredLane++;
            if (desiredLane == 3) desiredLane = 2;
        }*/

        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);

    }

    private bool IsGrounded()
    {
        Ray GroundRay = new Ray(new Vector3(controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f, controller.bounds.center.z ), Vector3.down);
        Debug.DrawRay(GroundRay.origin, GroundRay.direction, Color.cyan, 1.0f);

        return (Physics.Raycast(GroundRay, 0.2f + 0.1f));

    }

}