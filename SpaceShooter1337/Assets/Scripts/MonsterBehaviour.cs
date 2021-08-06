using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : EnemyBehaviour
{
    private float monsterSpeed = 2f;
    
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
        return 100;
    }

    public override int GetCoins()
    {
        return 3;
    }
}
