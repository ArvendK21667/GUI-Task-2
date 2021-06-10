using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public StaminaManager staminaScript; 

    Vector3 velocity;
    bool isGrounded;
    bool isMoving;

    public void Start()
    {
        isMoving = false;
    }
    //Update is called once per frame
    void Update()
    {
        if(isMoving == true)
        {
            staminaScript.StaminaReduction();
        }
        
        if (isMoving == false && isGrounded == true) 
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



        if (move.magnitude < 0.1f)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
            staminaScript.ResetStaminaRegenTimer();
        }


        controller.Move(move * speed * Time.deltaTime);  //movement


        if (Input.GetButtonDown("Jump") && isGrounded) //if input jump "Space Bar" 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //Jump
            staminaScript.StaminaReductionByJump();
        }

        velocity.y += gravity * Time.deltaTime; //velocity of y axis for jump and gravity

        controller.Move(velocity * Time.deltaTime); 
    }
}