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

    //Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //To make groundCheck position, ground distance and ground mask equall isGrounded

        if(isGrounded && velocity.y < 0) //if isGrounded on and "Y-Axis" is below 0 make it -2
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); //giving x value of Horizontal Axis
        float z = Input.GetAxis("Vertical"); //giving z value of Vertical Axis

        Vector3 move = transform.right * x + transform.forward * z; //Making character move with mouse movement

        controller.Move(move * speed * Time.deltaTime); //movement

        if(Input.GetButtonDown("Jump") && isGrounded) //if input jump "Space Bar" 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //Jump
        }

        velocity.y += gravity * Time.deltaTime; //velocity of y axis for jump and gravity

        controller.Move(velocity * Time.deltaTime); 
    }
}






//{
//    CharacterController characterController;
//    public float MovementSpeed = 1;
//    public float Gravity = 9.8f;
//    private float velocity = 1;
//    //[SerializeField] private StaminaManager staminaDown;
//    //public bool isMoving;

//    private void Start()
//    {
//        characterController = GetComponent<CharacterController>();
//    }

//    void Update()
//    {
//        // player movement - forward, backward, left, right
//        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
//        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
//        characterController.Move((transform.right * horizontal + transform.forward * vertical) * Time.deltaTime);
//        //isMoving = true;

//        // Gravity
//        if (characterController.isGrounded)
//        {
//            velocity = 0;
            
//        }
//        else
//        {
//            velocity -= Gravity * Time.deltaTime;
//            characterController.Move(new Vector3(0, velocity, 0));
//        }

//        //if (isMoving)
//        //{
//        //    staminaDown.StaminaReduction();
//        //}
//        //else
//        //{
//        //    staminaDown.StaminaIncrease();
//        //}
//    }
//}