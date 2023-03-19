using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTrap : MonoBehaviour
{
    [SerializeField]private Rigidbody trap;

    [SerializeField]private Vector3 AngularV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trap.angularVelocity = AngularV;
    }
}
