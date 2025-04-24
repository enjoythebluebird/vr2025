using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Transform mainCamera;
    

    public Vector3 offset;
    public GameObject cam;
    public GameObject NPC;
    public GameObject textObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = cam.transform;
        textObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textObject.activeSelf)
        {
            textObject.transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
            textObject.transform.position = NPC.transform.position + offset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Show the text when a collision occurs
        if (other.CompareTag("Player"))
        {
            textObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Hide the text when the object exits the collision
        if (other.CompareTag("Player"))
        {
            textObject.SetActive(false);
        }
    }
}
