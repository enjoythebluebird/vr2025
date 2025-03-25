using System.Collections;
using UnityEngine;

public class CustomHapticScript : MonoBehaviour
{
    private bool picked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void pickedup()
    {
        picked = true;
    }

    IEnumerator ContinuousVibration()
    {
        yield return new WaitForSeconds(1.0f);
        GetComponent<HapticImpulsePlayer>().SendHapticFeedback(0.1f, 3f, 100f);
        yield return new WaitForSeconds(3f);

        if (picked){
            StartCoroutine(ContinuousVibration());
        }
    }

    public void pickedup()
    {
        picked = false;
    }

    public void lowamp()
    {
        GetComponent<HapticImpulsePlayer>().SendHapticFeedback(0.1f, 1f, 100f);
    }

    public void medamp()
    {
        GetComponent<HapticImpulsePlayer>().SendHapticFeedback(0.5f, 1f, 100f);
    }

    public void highamp()
    {
        GetComponent<HapticImpulsePlayer>().SendHapticFeedback(1f, 1f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
