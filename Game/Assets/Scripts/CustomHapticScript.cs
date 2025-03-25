using UnityEngine;

public class CustomHapticScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
