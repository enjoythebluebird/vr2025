using UnityEngine;
using UnityEngine.InputSystem;

public class FlyTest : MonoBehaviour
{
    public GameObject head;
    public GameObject leftHand;
    public float flyingSpeed = 0.0f;
    public InputActionReference gripAction;

    private Rigidbody XROrigin;

    void Start()
    {
        XROrigin = GetComponent<Rigidbody>();
        var inputActionAsset = GetComponent<PlayerInput>().actions;
        XROrigin.useGravity = false;
    }

    void Update()
    {
        Flying();
        ZeroGravity();
    }

    private bool CheckIfFlying()
    {
        return gripAction.action.ReadValue<float>() > 0.1f; // Adjust the threshold as needed
    }

    private void Flying()
    {
        if (CheckIfFlying())
        {
            Vector3 flyDir = leftHand.transform.position - head.transform.position;
            transform.position += flyDir * flyingSpeed;
        }
    }

    private void ZeroGravity()
    {
        // Assuming you want to check for collision with the floor
        if (Physics.Raycast(transform.position, -Vector3.up, 0.1f))
        {
            
        }
    }
}
