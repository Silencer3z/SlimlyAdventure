using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private List<GameObject> respawnPoint;

    [SerializeField] private Vector3 vectorPoint;
    
    [SerializeField] private float Dead;
    [SerializeField] private float OutMap;

   


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        {
            
        }
        if (player.transform.position.y < OutMap)
        {
            player.transform.position = vectorPoint;
        }

        if (player.transform.position.x <-3.3 || player.transform.position.x >3.3)
        {
            player.transform.position = vectorPoint;
        }

        if (Dead >= 1)
        {
            player.transform.position = vectorPoint;
            Dead = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {

            vectorPoint =  other.transform.position;

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Danger"))
        {
            Debug.Log("I'm In");
            Dead = 1;
            
        }
        
    }
}