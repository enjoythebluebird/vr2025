using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 5, 0);
        }
        
        if (Input.GetKey("w"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 3);
        }

        if (Input.GetKey("s"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -3);
        }

        if (Input.GetKey("d"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(3, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(-3, 0, 0);
        }

    }
}
