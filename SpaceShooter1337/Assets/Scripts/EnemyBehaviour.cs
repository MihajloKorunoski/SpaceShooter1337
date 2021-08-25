using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Coin goldCoin;
    private int health { get; set; }

    void Awake()
    {
        health = GetMaxHealth();
        if (gameObject == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    protected virtual void Die()
    {
        int coins = GetCoins();
        for (int i = 0; i < coins; ++i)
            Instantiate(goldCoin, transform.position, Quaternion.identity);
        if (gameObject != this) {
                Destroy (gameObject);
            }
        
    }

    void TakeDamage(int damage)
    {
        health = Mathf.Max(0, health - damage);

        if (health == 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Laser"))
        {
            Laser laser = other.GetComponent<Laser>();
            if (laser.isFromPlayer)
            {
                TakeDamage(laser.GetDamage());
                if (other.gameObject != this) {
                    Destroy (other.gameObject);
                }
            }
        }
    }

    public abstract int GetMaxHealth();
    public abstract int GetCoins();
}