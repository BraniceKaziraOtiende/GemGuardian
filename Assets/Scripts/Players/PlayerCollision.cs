using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && PlayerHealth.Instance != null)
        {
            PlayerHealth.Instance.TakeDamage(10);  // SAFE
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ICollectible>(out var collectible) && PlayerHealth.Instance != null)
        {
            collectible.Collect(PlayerHealth.Instance);  // SAFE
        }
    }
}