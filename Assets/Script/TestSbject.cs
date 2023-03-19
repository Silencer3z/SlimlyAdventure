using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSbject : MonoBehaviour
{
    [SerializeField] private float speed;
   [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right*speed);
        }
        else if (Input.GetAxis("Horizontal")>0)
        {
            rb.AddForce(Vector3.right*speed);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.right*speed);
        }
        else if (Input.GetAxis("Vertical")>0)
        {
            rb.AddForce(Vector3.right*speed);
        }
       
    }
}
