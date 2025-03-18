using UnityEngine;

public class Handphysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {   
        rb.linearVelocity = (target.position - transform.position) / Time.fixedDeltaTime;

        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
