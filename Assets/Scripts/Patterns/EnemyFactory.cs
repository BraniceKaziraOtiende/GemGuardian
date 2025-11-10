using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance { get; private set; }

    [SerializeField] private GameObject[] enemyPrefabs;  // Drag 5 enemies

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SpawnRandomEnemy()
    {
        int type = Random.Range(0, enemyPrefabs.Length);
        Vector3 pos = new Vector3(Random.Range(-8f, 8f), 6f, 0);
        Enemy enemy = Instantiate(enemyPrefabs[type], pos, Quaternion.identity).GetComponent<Enemy>();
        enemy.Strategy = GetStrategyForType(type);
    }

    private IEnemyStrategy GetStrategyForType(int type)
    {
        return type switch
        {
            0 => new PatrolStrategy(),   // Bear / Slime
            1 => new ChaseStrategy(),    // Dog
            2 => new DiveStrategy(),     // Eagle
            3 => new ChargeStrategy(),   // Dino
            _ => new PatrolStrategy()
        };
    }
}