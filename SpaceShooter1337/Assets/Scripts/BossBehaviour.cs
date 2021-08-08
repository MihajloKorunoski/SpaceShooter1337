using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : EnemyBehaviour
{
    [SerializeField] private Transform spawnSpot;
    [SerializeField] private Laser laserPrefab;

    Transform player;

    public delegate void BossDying();

    public static event BossDying BossDied;

    private Vector2 direction { get; set; }
    private Laser laser { get; set; }
    private int maxHealth { get; set; }
    
    private int coins { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("ShootPlayer", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, Time.deltaTime);
    }

    void ShootPlayer()
    {
        direction = (player.position - transform.position).normalized;
        laser = Instantiate(laserPrefab, spawnSpot.position, Quaternion.identity) as Laser;
        laser.Init(direction, 5f, false);
    }

    public override int GetMaxHealth()
    {
        maxHealth = 2000;
        return maxHealth;
    }

    public override int GetCoins()
    {
        coins = 10;
        return coins;
    }
    protected override void Die()
    {
        if(BossDied != null)
            BossDied();
        base.Die();
    }
}