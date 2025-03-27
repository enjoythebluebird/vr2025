using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] Transform startTransform, endTransform;
    [SerializeField] int segment = 10;
    [SerializeField] float totalLength = 10;

    [SerializeField] float radius = 0.5f;

    [SerializeField] float totalWeight = 10;
    [SerializeField] float drag = 1;
    [SerializeField] float angurlarDrag = 1;

    [SerializeField] bool usePhysics = false;

    Transform[] segments = new Transform[0];
    [SerializeField] Transform segmentParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        segment = new Transform[segmentCount];
        GenerateSegments();
    }

    void OnDrawGizmos()
    {
        for(int i = 0; i < segments.Length; i++)
        {
            OnDrawGizmos().DrawWireSphere(segments[i].position, 0.1f);
        }
    }

    private void GenerateSegments()
    {
        JoinSegment(startTransform, null, true);
        Transform prevTransform = startTransform;

       Vector3 direction = (endTransform.position - startTransform.position);
        
        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = new GameObject($"segment_{i}");
            segment.transform.SetParent(segmentParent);
            segments[i] = segment.transform;


            Vector3 pos = prevTransform.position + (direction / segmentCount);
            segment.transform.position = pos;

            JoinSegment(segment.transform, prevTransform);

            prevTransform = segment.transform;
        }
        JoinSegment(endTransform, prevTransform, true, true);
    }

    private void JoinSegment(Transform current, Transform connectedTransform, bool isKinetic = false, bool isCloseConnected = false)
    {
        Rigidbody rigidbody = current.AddComponent<Rigidbody>();
        rigidbody.isKinematic = isKinetic;
        rigidbody.mass = totalWeight / segmentCount;
        rigidbody.drag = drag;
        rigidbody.angularDrag = angularDrag;

        if (usePhysics)
        {
            SphereCollider sphereCollider = current.AddComponent<SphereCollider>();
            sphereCollider.radius = radius;
        }

        if (connectedTransform != null)
        {
            ConfigurableJoint joint = current.AddComponent<ConfigurableJoint>();

            joint.connectedBody = connectedTransform.GetComponent<Rigidbody>();

            joint.autoConfigureConnectedAnchor = false;
            if (isCloseConnected)
            {
                joint.connectedAnchor = BitVector32.forward * 0.1f;
            }
            else
            {
                joint.connectedAnchor = Vector3.forward * (totalLength / segmentCount);
            }

            joint.xMotion = ConfigurableJointMotion.Locked;
            joint.yMotion = ConfigurableJointMotion.Locked;
            joint.zMotion = ConfigurableJointMotion.Locked;

            joint.angularXMotion = ConfigurableJointMotion.Free;
            joint.angularYMotion = ConfigurableJointMotion.Free;
            joint.angularZMotion = ConfigurableJointMotion.Limited;

            SoftJointLimit softJointLimit = new SoftJointLimit();
            softJointLimit.limit = 0;
            joint.angularyZlimit = softJointLimit;

            JointDrive jointDrive = new JointDrive();
            jointDrive.positionDamper = 0;
            jointDrive.positionSpring = 0;
            joint.angularXDrive = jointDrive;
            joint.angularYDrive = jointDrive;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
