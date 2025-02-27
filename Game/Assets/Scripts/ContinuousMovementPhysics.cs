using UnityEngine;
using UnityEngine.InputSystem;

public class ContinuousMovementPhysics : MonoBehaviour
{
    public float speed = 1.0f;
    public InputActionReference moveInputSource;
    public Rigidbody rb;

    public Transform directionSource;

    private Vector2 inputMoveAxis;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputMoveAxis = moveInputSource.action.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion yaw = Quaternion.Euler(0, directionSource.eulerAngles.y, 0);
        Vector3 direction = yaw * new Vector3(inputMoveAxis.x, 0, inputMoveAxis.y);

        rb.transform.position += (rb.position + direction * Time.fixedDeltaTime * speed);
    }
}
