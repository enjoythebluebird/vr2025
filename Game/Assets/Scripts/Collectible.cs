using UnityEngine;
using System;
using System.Collections;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    void Awake() => total++;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlyTest flyTest = other.gameObject.GetComponent<FlyTest>();
            flyTest.maxSpeed *= 2.0f;
            flyTest.flyingSpeed *= 3.0f;
            flyTest.StartCoroutine(flyTest.ResetMaxSpeed());
            Destroy(gameObject);
        }
    }
}
