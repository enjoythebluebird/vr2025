using UnityEngine;

public class passthroughmanagerscript : MonoBehaviour
{

    public OVRPassthroughLayer layer1;
    public OVRPassthroughLayer layer2;
    private bool clicked = false;
    private bool op = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void changeopcacity()
    {
        if (!op)
        {
            layer1 textureOpacity = 1;
            op = true;
        }
        else
        {
            layer1 textureOpacity = 0.2f;
            op = false;
        }
    }

    public void switchlayers()
    {
        if (clicked) { 
            clicked = true;
            layer1 enabled = false;
            layer2 enabled = true;
        }
        else
        {
            clicked = false;
            layer1 enabled = true;
            layer2 enabled = false;

        }


        // Update is called once per frame
        void Update()
            {

            }
}
