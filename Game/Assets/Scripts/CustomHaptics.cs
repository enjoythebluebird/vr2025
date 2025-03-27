using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class CustomHaptics : MonoBehaviour
{
    private bool picked = false;
    public Transform obj;
    public Transform goal;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void pickedUp()
    {
        picked = true;
        StartCoroutine(ContinuousVibration());
    }

    public void dropped()
    {
        picked = false;
    }

    IEnumerator ContinuousVibration()
    {
        yield return new WaitForSeconds(0.1f);
        if(Vector3.Distance(obj.position, goal.position) > 6.0f)
        {
            GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.1f, 1.0f, 100f);
        }
        else if(Vector3.Distance(obj.position,goal.position) > 3.0f)
        {
            GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.5f, 1.0f, 100f);
        }
        else
        {
            GetComponent<HapticImpulsePlayer>().SendHapticImpulse(1.0f, 1.0f, 100f);
        }
        yield return new WaitForSeconds(3.0f);

        if (picked)
        {
            StartCoroutine(ContinuousVibration());
        }
    }

    public void lowamp()
    {
        GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.1f, 1.0f, 100f);
    }
    public void midamp()
    {
        GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.5f, 1.0f, 100f);
    }
    public void hiwamp()
    {
        GetComponent<HapticImpulsePlayer>().SendHapticImpulse(1.0f, 1.0f, 100f);
    }
}
