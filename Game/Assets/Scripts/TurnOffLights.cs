using UnityEngine;

public class TurnOffLights : MonoBehaviour
{
    public GameObject light;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Destroy(light);
        }
    }
}
