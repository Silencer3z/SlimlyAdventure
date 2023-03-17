using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotetionSpeed;
    [SerializeField] private float jumpSpeed;
    /*[SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;*/

    private CharacterController charecterController;
    private float ySpeed;
    private float moveDirection;
    private bool isJumping;

    private float originalStepOffset;

    // Start is called before the first frame update
    void Start()
    {

        charecterController = GetComponent<CharacterController>();
        originalStepOffset = charecterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (charecterController.isGrounded)
        {
            charecterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
            
        }
        else
        {
            charecterController.stepOffset = 0;
        }

        //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        //charecterController.SimpleMove(movementDirection * magnitude);
        Vector3 velosity = movementDirection * magnitude;
        velosity.y = ySpeed;
        charecterController.Move(velosity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotetionSpeed * Time.deltaTime);
        }
        
        /*moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }*/
        
    }
    
    

    /*private void FixedUpdate()
    {
        rb.velocity = new Vector3( moveDirection* moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector3(0f , jumpForce));
        }
        isJumping = false;
    }*/
}
