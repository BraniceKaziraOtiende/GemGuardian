using UnityEngine;

public interface ICollectible
{
    void Collect(PlayerHealth player);  // CHANGED: PlayerHealth instead of Player
}