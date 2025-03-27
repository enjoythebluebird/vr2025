using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class FlyTest : MonoBehaviour
{
    public GameObject head;
    public GameObject leftHand;
    public float flyingSpeed = 0.0f;
    public InputActionReference gripAction;
    public Rigidbody XROrigin;
    public float maxSpeed = 5.0f;

    private float originalMaxSpeed;
    private float originalFlyingSpeed;

    void Start()
    {
        var inputActionAsset = GetComponent<PlayerInput>().actions;
        XROrigin.useGravity = false;
        originalMaxSpeed = maxSpeed;
        originalFlyingSpeed = flyingSpeed;
    }

    void Update()
    {
        Flying();
    }

    private bool CheckIfFlying()
    {
        return gripAction.action.ReadValue<float>() > 0.1f;
    }

    private void Flying()
    {
        if (CheckIfFlying())
        {
            Vector3 flyDir = leftHand.transform.position - head.transform.position;
            Vector3 newVelocity = XROrigin.linearVelocity + flyDir.normalized * flyingSpeed * Time.deltaTime;

            if (newVelocity.magnitude > maxSpeed)
            {
                newVelocity = newVelocity.normalized * maxSpeed;
            }

            XROrigin.linearVelocity = newVelocity;

            if (!IsInvoking(nameof(FlyingVibration)))
            {
                InvokeRepeating(nameof(FlyingVibration), 0.1f, 0.1f);
            }
        }
        else
        {
            XROrigin.linearVelocity *= 0.975f;
            CancelInvoke(nameof(FlyingVibration));
        }
    }

    private void FlyingVibration()
    {
        leftHand.GetComponent<HapticImpulsePlayer>().SendHapticImpulse(0.5f, 0.11f, 100f);
    }

    public IEnumerator ResetMaxSpeed()
    {
        yield return new WaitForSeconds(5.0f);
        maxSpeed = originalMaxSpeed; // Reset properly
        flyingSpeed = originalFlyingSpeed;
    }
}
