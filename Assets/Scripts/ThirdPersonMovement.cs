using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float walkingspeed = 12;
    public float sprintingspeed = 18;
    public float crouchingspeed = 6;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public StaminaManager staminaScript; 

    Vector3 velocity;
    bool isGrounded;
    bool isMoving;
    bool isCrouching;
    bool isSprinting;

    public void Start()
    {
        Time.timeScale = 0;
        isMoving = false;
    }
    //Update is called once per frame
    void Update()
    {
        if(isMoving == true) //for Stamina adjustment
        {
            staminaScript.StaminaReductionByWalking();
        }
        
        if (isMoving == false && isGrounded == true) //for Stamina adjustment
        {
            staminaScript.StaminaIncrease();
        }

        if (isSprinting == true)  //for Stamina adjustment
        {
            staminaScript.StaminaReductionBySprinting();
        }

        if (isSprinting == false && isGrounded == true) //for Stamina adjustment
        {
            staminaScript.StaminaIncrease();
        }

        if (isCrouching == true) //for Stamina adjustment
        {
            staminaScript.StaminaReductionByCrouching();
        }

        if (isCrouching == false && isGrounded == true) //for Stamina adjustment
        {
            staminaScript.StaminaIncrease();
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //To make groundCheck position, ground distance and ground mask equall isGrounded

        if(isGrounded && velocity.y < 0) //if isGrounded on and "Y-Axis" and is below 0 make it -2
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); //giving x value of Horizontal Axis
        float z = Input.GetAxis("Vertical"); //giving z value of Vertical Axis

        Vector3 move = transform.right * x + transform.forward * z; //Making character move 

        if (move.magnitude < 0.1f) //if not moving set false
        {
            isMoving = false;
        }
        else //if moving resettimer method
        {
            isMoving = true;
            staminaScript.ResetStaminaRegenTimer();
        }

        float moveSpeed;

        if (Input.GetKey(KeyCode.R)) //if you press R change move speed to sprint
        {
            moveSpeed = sprintingspeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift)) //if you press Left Shift change move speed to crouch
        {
            moveSpeed = crouchingspeed;
        }
        else //otherwise having normal walking speed
            moveSpeed = walkingspeed;

        if (Input.GetButtonDown("Jump") && isGrounded) //if input jump "Space Bar" 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //Jump
            staminaScript.StaminaReductionByJump();
        }
        controller.Move(move * moveSpeed * Time.deltaTime);  // walking movement

        velocity.y += gravity * Time.deltaTime; //velocity of y axis for jump and gravity

        controller.Move(velocity * Time.deltaTime); 
    }
}