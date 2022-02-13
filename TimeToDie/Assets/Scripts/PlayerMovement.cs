using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    // Movement variables
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool outSprint = false;
    bool inSprint = false;
    bool inSlide = false;

    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    void Update()
    {
        // Reset velocity for on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        // Check to see if character is moving, if not can't accelerate
        if ((move.x == 0 && move.z == 0) || !isGrounded) 
        {
            isMoving = false;
        } 
        else 
        {
            isMoving = true;
        }

        //Crouching
        if (Input.GetButton("Crouch"))
        {
            if ((speed >= 18f || inSlide) && isMoving)
            {
                inSlide = true;
                speed /= 1.005f;

            } 
            else 
            {
                inSlide = false;
                speed = 4f;
            }

        //Sprinting
        //Check if stop sprinting, if so slow down the player with min speed of 12
        } 
        else if (Input.GetButtonUp("Sprint") || outSprint)
        {
            inSprint = false;
            outSprint = true;
            speed -= 0.05f;
            if (speed <= 12f && isGrounded)
            {
                outSprint = false;
                speed = 12f;
            }
        //If currently sprinting, increase the speed with max speed of 20
        } 
        else if (Input.GetButton("Sprint") && isMoving)
        {
            inSprint = true;
            speed += 0.1f;
            if (speed > 20f) speed = 20f;
        } 
        else
        {
            inSlide = false;
            speed = 12f;
        }

        // WASD Movement
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //determine jumpHeight using current speed
            jumpHeight = speed/3f;
            if (jumpHeight >= 5f) jumpHeight = 5f;
            speed /= 2f;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
