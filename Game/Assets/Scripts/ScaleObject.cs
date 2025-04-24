using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    private Vector3 InitialScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialScale = transform.localScale;
        UpdateTransformForScale();
    }

    // Update is called once per frame
    void Update()
    {
        if (start.transform.hasChanged || end.transform.hasChanged)
        {
            UpdateTransformForScale();
        }
        
    }

    void UpdateTransformForScale()
    {
        float distance = Vector3.Distance(start.transform.position, end.transform.position);
        transform.localScale = new Vector3(InitialScale.x, distance / 2f / 0.07f, InitialScale.z);

        Vector3 middlePoint = (start.transform.position + end.transform.position) / 2f;
        transform.position = middlePoint;

        Vector3 rotationDirection = (end.transform.position - start.transform.position) / 2f;
        transform.up = rotationDirection;
    }
}
