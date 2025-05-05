using UnityEngine;

public class AlienHitbox : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Alien alien = GetComponentInParent<Alien>();
            if (alien != null)
            {
                alien.TakeDamage(damageAmount);
            }

            Destroy(collision.gameObject);
        }
    }
}
