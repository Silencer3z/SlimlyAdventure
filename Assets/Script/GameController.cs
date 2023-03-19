using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using TreeEditor;
using UnityEditor.Timeline.Actions;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //SerializeField] private Rigidbody rb;

    [SerializeField] private List<GameObject> respawnPoint;

    [SerializeField] private Vector3 vectorPoint;
    [SerializeField] private GameObject FinishUI;
    
    [SerializeField] private float Dead;
    [SerializeField] private float OutMap;
    [SerializeField] public int Key = 0;
    [SerializeField] public int Requirement;
    public int stage = 1;

    public TextMeshProUGUI KeyUI;
    public TextMeshProUGUI RequirementUI;
    public TextMeshProUGUI stageUI;
   
    

    // Update is called once per frame
    void FixedUpdate()
    {
        RequirementUI.text = "Key Require " + Requirement.ToString();
        KeyUI.text = "YourKey : " + Key.ToString()+"/" + Requirement.ToString();
        stageUI.text ="Stage : "+ stage.ToString();
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
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
        
        //Stage Check

        /*if (stage == 4)
        {
            Requirement = 7;
        }*/

        if (stage == 5)
        {
            RequirementUI.text = "Final Stage";
            KeyUI.text = "Final Stage";
            stageUI.text = "Final Stage ";
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //CheckPoint & StageCheck
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            Key++;
        }
        if (Key == Requirement)
        {
            Debug.Log("You can pass");
            if (other.gameObject.CompareTag("Respawn"))
            {
                vectorPoint =  other.transform.position;
                Destroy(other.gameObject);
                Key = 0;
                stage++;
                Requirement+=2;
            }
            else if (Key != Requirement)
            {
                Debug.Log("You're not met the requirement");
            }
        }
        
        
        //Danger Object If touch = Death & ResetPosition to Current CheckPoint
        if (other.gameObject.CompareTag("Danger"))
        {
            Debug.Log("I'm In");
            Dead = 1;
            
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            FinishUI.SetActive(true);
            gameObject.GetComponent<pauseMenu>().pauseMenuUI.SetActive(false);
            Time.timeScale = 0f;

        }


    }
}
