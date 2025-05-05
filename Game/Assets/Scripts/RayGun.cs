using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayGun : MonoBehaviour
{
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    [SerializeField] private AudioSource pewpewAudio;
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private LayerMask targetLayers;
    [SerializeField] private GameObject bullet;

    private void Start()
    {
        if (grabInteractable == null)
        {
            grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        }

        if (grabInteractable != null)
        {
            grabInteractable.activated.AddListener(TriggerPulled);
        }
        else
        {
            Debug.LogError("?? grabInteractable is null on RayGun. Check your prefab!");
        }
        Debug.Log("RayGun is starting from: " + gameObject.name + " (Scene: " + gameObject.scene.name + ")");

        if (grabInteractable == null)
        {
            Debug.LogError("grabInteractable is null on: " + gameObject.name);
        }


    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.activated.RemoveListener(TriggerPulled);
        }
    }

    private void TriggerPulled(ActivateEventArgs arg0)
    {
        // Haptics
        var interactorGO = (arg0.interactorObject as MonoBehaviour)?.gameObject;
        if (interactorGO != null)
        {
            var controllerInteractor = interactorGO.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor>();
            controllerInteractor?.SendHapticImpulse(0.5f, 0.25f);
        }

        // Sound
        pewpewAudio?.Play();

        // Fire
        FireRaycastIntoScene();
    }

    private void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, Mathf.Infinity, targetLayers))
        {
            if (hit.collider.TryGetComponent<Alien>(out Alien alien))
            {
                int damage = 0;

                if (hit.collider.CompareTag("Head"))
                {
                    damage = 40;
                }
                else if (hit.collider.CompareTag("Body"))
                {
                    damage = 50;
                }

                alien.TakeDamage(damage);
            }
        }

        if (bullet != null)
        {
            GameObject spawnedBullet = Instantiate(bullet, raycastOrigin.position, raycastOrigin.rotation);

            if (spawnedBullet.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.linearVelocity = raycastOrigin.forward * 20f;
            }

            Destroy(spawnedBullet, 5f);
        }
    }

}
