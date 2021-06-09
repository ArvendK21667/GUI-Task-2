using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour

{
    CharacterController characterController;
    public float MovementSpeed = 1;
    public float Gravity = 9.8f;
    private float velocity = 1;
    //[SerializeField] private StaminaManager staminaDown;
    //public bool isMoving;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((transform.right * horizontal + transform.forward * vertical) * Time.deltaTime);
        //isMoving = true;

        // Gravity
        if (characterController.isGrounded)
        {
            velocity = 0;
            
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }

        //if (isMoving)
        //{
        //    staminaDown.StaminaReduction();
        //}
        //else
        //{
        //    staminaDown.StaminaIncrease();
        //}
    }
}