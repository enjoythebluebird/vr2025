using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TeleportingDoor4 : MonoBehaviour
{
    private BoxCollider myCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnCollisionEnter(Collision collision)
    {
        //myCollider.enabled = false;
        SceneManager.LoadScene(0);
    }
}
