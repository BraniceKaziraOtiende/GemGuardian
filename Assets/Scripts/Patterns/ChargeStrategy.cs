using UnityEngine;

public class ChargeStrategy : IEnemyStrategy
{
    private bool isCharging = false;
    private float chargeTimer = 0f;

    public void Execute(Enemy enemy)
    {
        if (!isCharging)
        {
            isCharging = true;
            chargeTimer = 1.5f;
        }

        if (chargeTimer > 0)
        {
            enemy.transform.Translate(Vector2.down * enemy.speed * 3f * Time.deltaTime);
            chargeTimer -= Time.deltaTime;
        }
        else
        {
            enemy.Strategy = new PatrolStrategy();
        }
    }
}