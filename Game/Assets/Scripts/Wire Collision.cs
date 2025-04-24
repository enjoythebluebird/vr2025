using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class WireCollision : MonoBehaviour
{
    public GameObject hand;
    public GameObject grabCollider;
    public FuseBoxPuzzle FBP;

    // Dictionary to store initial positions of wires
    private Dictionary<GameObject, Vector3> initialPositions = new Dictionary<GameObject, Vector3>();

    private void Start()
    {
        // Store the initial position of this wire
        initialPositions[gameObject] = transform.position;
    }

    private void Update()
    {
        if(Vector3.Distance(grabCollider.transform.position, transform.position) > 0.5)
        {
            grabCollider.transform.position = transform.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            if (tag == "wire1")
            {
                FBP.Wire1();
            }
            else if (tag == "wire2")
            {
                FBP.Wire2();
            }
            else if (tag == "wire3")
            {
                FBP.Wire3();
            }
            else if (tag == "wire4")
            {
                FBP.Wire4();
            }
            else if (tag == "wire5")
            {
                FBP.Wire5();
            }
        }
        else
        {
            // Store the initial position of the other wire if not already stored
            if (!initialPositions.ContainsKey(other.gameObject))
            {
                initialPositions[other.gameObject] = other.transform.position;
            }

            // Call loseLife and reset positions
            FBP.loseLife();
            ResetWirePositions(other.gameObject);
        }
    }

    private void ResetWirePositions(GameObject otherWire)
    {
        // Reset this wire's position
        if (initialPositions.ContainsKey(gameObject))
        {
            transform.position = initialPositions[gameObject];
        }

        // Reset the other wire's position
        if (initialPositions.ContainsKey(otherWire))
        {
            otherWire.transform.position = initialPositions[otherWire];
        }
    }

    public void Shake()
    {
        if (tag == "wire1")
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(1.0f, 0.25f, 100f);
        }
        else if (tag == "wire2")
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.5f, 0.5f, 100f);
        }
        else if (tag == "wire3")
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.25f, 0.25f, 100f);
        }
        else if (tag == "wire4")
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.75f, 1.0f, 100f);
        }
        else
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(1.0f, 3.0f, 100f);
        }
    }
}
