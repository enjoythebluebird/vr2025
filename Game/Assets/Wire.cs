using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] Transform startTransform, endTransform;
    [SerializeField] int segment = 10;
    [SerializeField] float totalLength = 10;


    [SerializeField] float totalWeight = 10;
    [SerializeField] float drag = 1;
    [SerializeField] float angurlarDrag = 1;

    Transform[] segments;
    [SerializeField] Transform segmentParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
