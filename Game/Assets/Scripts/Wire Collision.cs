using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class WireCollision : MonoBehaviour
{
    public GameObject hand;
    public GameObject grabCollider;
    public FuseBoxPuzzle FBP;

    // Dictionary to store initial positions of wires
    private static Dictionary<GameObject, Vector3> initialPositions = new Dictionary<GameObject, Vector3>();

    private void Start()
    {
        // Store the initial position of this wire
        initialPositions[gameObject] = transform.position;
    }

    private void Update()
    {
        if(Vector3.Distance(grabCollider.transform.position, transform.position) > 0.1)
        {
            transform.position = grabCollider.transform.position;
            grabCollider.GetComponent<XRGrabInteractable>().enabled = false;
            grabCollider.transform.position = initialPositions[gameObject];
            grabCollider.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            if (CompareTag("wire1"))
            {
                grabCollider.GetComponent<XRGrabInteractable>().enabled = false;
                FBP.Wire1();
            }
            else if (CompareTag("wire2"))
            {
                grabCollider.GetComponent<XRGrabInteractable>().enabled = false;
                FBP.Wire2();
            }
            else if (CompareTag("wire3"))
            {
                grabCollider.GetComponent<XRGrabInteractable>().enabled = false;
                FBP.Wire3();
            }
            else if (CompareTag("wire4"))
            {
                grabCollider.GetComponent<XRGrabInteractable>().enabled = false;
                FBP.Wire4();
            }
            else if (CompareTag("wire5"))
            {
                grabCollider.GetComponent<XRGrabInteractable>().enabled = false;
                FBP.Wire5();
            }
        }
        else if(other.CompareTag("wire1") || other.CompareTag("wire2") || other.CompareTag("wire3") || other.CompareTag("wire4") || other.CompareTag("wire5"))
        {
            // Call loseLife and reset positions
            ResetWirePositions(other.gameObject);
            FBP.loseLife();
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
        if (CompareTag("wire1"))
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(1.0f, 0.25f, 100f);
        }
        else if (CompareTag("wire2"))
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.5f, 0.5f, 100f);
        }
        else if (CompareTag("wire3"))
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.25f, 3.0f, 100f);
        }
        else if (CompareTag("wire4"))
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.75f, 1.0f, 100f);
        }
        else
        {
            hand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(1.0f, 5.0f, 100f);
        }
    }
}
