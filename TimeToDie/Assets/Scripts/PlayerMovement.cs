using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    bool outSprint = false;
    bool inSprint = false;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Reset velocity for on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // Reduce velocity for mid-air movement
        if (!isGrounded)
        {
            if (inSprint){
                speed -=0.75f;
            } else {
                speed -=1.25f;
            }
            if (speed<=8f) speed = 8f;
        //Crouching
        } else if (Input.GetButton("Crouch"))
        {
            speed = 4f;



        //Jumping
        //Check if stop sprinting, if so slow down the player with min speed of 12
        } else if (Input.GetButtonUp("Sprint") || outSprint){
            inSprint = false;
            outSprint = true;
            speed -= 0.05f;
            if (speed<=12f){
                outSprint = false;
                speed = 12f;
            }
        //If currently sprinting, increase the speed with max speed of 20
        } else if (Input.GetButton("Sprint"))
        {
            inSprint = true;
            speed += 1f;
            if (speed>20f) speed = 20f;
        } else
        {
            speed = 12f;
        }
        // WASD Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * speed * Time.deltaTime);
        // Jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
