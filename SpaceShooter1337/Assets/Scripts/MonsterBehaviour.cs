using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : EnemyBehaviour
{
    private float monsterSpeed = 2f;
    private int maxHealth { get; set; }
    private int coins { get; set; }


    // Update is called once per frame
    void Update()
    {
        transform.Translate((monsterSpeed * Vector2.down * Time.deltaTime));

        if (transform.position.y + transform.localScale.y <= GameMenager.bottomLeftPosition.y)
        {
            Destroy((gameObject));
        }
    }

    public void SetSpeed(float speed)
    {
        monsterSpeed = speed;
    }

    public override int GetMaxHealth()
    {
        maxHealth = 100;
        return maxHealth;
    }

    public override int GetCoins()
    {
        coins = 3;
        return coins;
    }
}