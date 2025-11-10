using UnityEngine;

public class PatrolStrategy : IEnemyStrategy
{
    private float timer = 0f;

    public void Execute(Enemy enemy)
    {
        timer += Time.deltaTime;
        float xMove = Mathf.Sin(timer * 2f) * 0.5f;
        Vector2 movement = new Vector2(xMove, 0);
        enemy.transform.Translate(movement * enemy.speed * Time.deltaTime);
    }
}