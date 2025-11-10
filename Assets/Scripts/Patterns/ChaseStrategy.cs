using UnityEngine;

public class ChaseStrategy : IEnemyStrategy
{
    public void Execute(Enemy enemy)
    {
        if (PlayerHealth.Instance == null) return;

        Vector2 direction = (PlayerHealth.Instance.transform.position - enemy.transform.position).normalized;
        enemy.transform.Translate(direction * enemy.speed * 1.3f * Time.deltaTime);
    }
}