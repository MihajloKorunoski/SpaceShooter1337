using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed { get; set; }
    private Vector2 direction { get; set; }
    public bool isFromPlayer { get; set; }
    public int damage { get; set; }

    public void Init(Vector2 myDir, float mySpeed, bool isFromPl)
    {
        this.direction = myDir;
        this.speed = mySpeed;
        this.isFromPlayer = isFromPl;
        damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime);

        if (transform.position.y >= GameMenager.topRightPosition.y)
        {
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}