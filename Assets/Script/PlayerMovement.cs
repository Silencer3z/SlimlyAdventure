using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    
    [SerializeField] private float speed;
    [SerializeField] private float rotetionSpeed;
    [SerializeField] private float jumpSpeed;
    //[SerializeField] private Transform goal;

    private CharacterController charecterController;
    private float ySpeed;
    private float originalStepOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        charecterController = GetComponent<CharacterController>();
        originalStepOffset = charecterController.stepOffset;
        
            //NavMeshAgent agent = GetComponent<NavMeshAgent>();
           //agent.destination = goal.position;
    }
    
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
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotetionSpeed * Time.deltaTime);
        }
    }
}
