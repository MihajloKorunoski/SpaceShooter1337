using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : EnemyBehaviour
{
    private float monsterSpeed = 2f;
    private int maxHealth = 100;
    private int coins = 3;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate((monsterSpeed * Vector2.down * Time.deltaTime));

        if (transform.position.y + transform.localScale.y <= GameMenager.bottomLeftPosition.y)
        {
            Destroy((gameObject));
        }
    }

    public void SetSpeed(int speed)
    {
        monsterSpeed = speed;
    }

    public override int GetMaxHealth()
    {
        return maxHealth;
    }

    public override int GetCoins()
    {
        return coins;
    }
}
