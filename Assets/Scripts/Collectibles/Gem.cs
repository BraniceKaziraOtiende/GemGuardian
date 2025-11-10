using UnityEngine;

public class Gem : MonoBehaviour, ICollectible
{
    public void Collect(PlayerHealth player)
    {
        GameManager.Instance.AddGem();  // ← Perfect for gems!
        Destroy(gameObject);
    }
}