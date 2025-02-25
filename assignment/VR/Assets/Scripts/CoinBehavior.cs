using UnityEngine;

public class CoinBehavoir : MonoBehaviour
{
    private Vector3 myStartPosition;
    private AudioSource myAudio;
    private MeshRenderer myRenderer;
    private SphereCollider myCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myStartPosition = transform.position;
        myAudio = GetComponent<AudioSource>();
        myRenderer = GetComponent<MeshRenderer>();
        myCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myStartPosition + new Vector3(0.0f, Mathf.Sin(Time.time)/10.0f, 0.0f);
        transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        myAudio.Play();
        myRenderer.enabled = false;
        myCollider.enabled = false;
    }
}
