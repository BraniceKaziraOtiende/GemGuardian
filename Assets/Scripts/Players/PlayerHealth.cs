using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public static PlayerHealth Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Health: " + health);
        if (health <= 0) GameManager.Instance.GameOver();
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(100, health + amount);
    }

    public int GetCurrentHealth()
    {
        return health;
    }
}