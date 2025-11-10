using UnityEngine;

public class DiveStrategy : IEnemyStrategy
{
    public void Execute(Enemy enemy)
    {
        if (PlayerHealth.Instance == null) return;

        Vector2 dir = (PlayerHealth.Instance.transform.position - enemy.transform.position).normalized;
        enemy.transform.Translate(dir * enemy.speed * 2f * Time.deltaTime);

        // KILL EAGLE WHEN CLOSE (NO CARRY AWAY)
        if (Vector2.Distance(enemy.transform.position, PlayerHealth.Instance.transform.position) < 1.5f)
        {
            PlayerHealth.Instance.TakeDamage(20);
            enemy.TakeDamage(999);  // Eagle dies instantly
        }
    }
}