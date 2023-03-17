using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
   public float jumpForce = 10f;

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
      }
   }
}
