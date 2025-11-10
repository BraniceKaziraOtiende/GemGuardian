using UnityEngine;

public class Cherry : MonoBehaviour, ICollectible
{
    public void Collect(PlayerHealth player)
    {
        if (player != null)  // SAFETY CHECK
        {
            player.Heal(20);
        }
        Destroy(gameObject);
    }
}