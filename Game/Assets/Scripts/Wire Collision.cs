using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class WireCollision : MonoBehaviour
{
    public GameObject hand;
    public FuseBoxPuzzle FBP;
    
    private void Update()
    {
        
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
            FBP.life--;
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
