using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Vector3 jump;
    public float speed;
    public float jumpForce;

    [SerializeField]public Rigidbody rb;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb.gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right*speed);
        }
        else if (Input.GetAxis("Horizontal")<0)
        {
            rb.AddForce(-Vector3.right*speed);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward*speed);
        }
        else if (Input.GetAxis("Vertical")<0)
        {
            rb.AddForce(-Vector3.forward*speed);
        }

        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
           rb.AddForce(jump*jumpForce,ForceMode.Impulse);
           isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        isGrounded = true;
    }
}
