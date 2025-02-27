using UnityEngine;
using UnityEngine.InputSystem;

public class FlyTest : MonoBehaviour
{
    public GameObject head;
    public GameObject leftHand;
    public float flyingSpeed = 0.0f;
    public InputActionReference gripAction;
    public Rigidbody XROrigin;
    public float maxSpeed = 5.0f;

    void Start()
    {
        var inputActionAsset = GetComponent<PlayerInput>().actions;
        XROrigin.useGravity = false;
    }

    void Update()
    {
        Flying();
    }

    private bool CheckIfFlying()
    {
        return gripAction.action.ReadValue<float>() > 0.1f; // Adjust the threshold as needed
    }

    private void Flying()
    {
        // Check if the player is pressing trigger
        if (CheckIfFlying())
        {
            // If currently flying apply speed to make player move faster
            Vector3 flyDir = leftHand.transform.position - head.transform.position;
            Vector3 newVelocity = XROrigin.linearVelocity + flyDir.normalized * flyingSpeed * Time.deltaTime;

            // Cap the speed but allow direction change
            if (newVelocity.magnitude > maxSpeed)
            {
                newVelocity = newVelocity.normalized * maxSpeed;
            }

            XROrigin.linearVelocity = newVelocity;
        }
        //else
        //{
        //    // If not currently flying slow the player down
        //    XROrigin.linearVelocity *= 0.99f;
        //}
    }
}
