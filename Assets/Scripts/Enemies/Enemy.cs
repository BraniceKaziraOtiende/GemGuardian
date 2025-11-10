using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health = 50;
    [SerializeField] public float speed = 2f;  // Each enemy sets its own
    public IEnemyStrategy Strategy { get; set; }

    protected virtual void Update()
    {
        Strategy?.Execute(this);  // ← MOVEMENT HAPPENS HERE
    }

    public virtual void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) Die();
    }

    protected virtual void Die()
    {
        // Drop gem/cherry
        int rand = Random.Range(0, 2);
        GameObject drop = rand == 0
            ? Resources.Load<GameObject>("GemPrefab")
            : Resources.Load<GameObject>("CherryPrefab");
        if (drop) Instantiate(drop, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}