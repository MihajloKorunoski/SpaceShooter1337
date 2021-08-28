using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameMenager : MonoBehaviour
{
    public static Vector2 bottomLeftPosition { get; set; }

    public static Vector2 topRightPosition { get; set; }

    private int coinsCount { get; set; }
    private int coins { get; set; }
    private int bossCoins { get; set; }
    private int damage { get; set; }

    //public PlayerBehaviour player { get; set; }
    [SerializeField] PlayerBehaviour player;

    public MonsterBehaviour[] monster;

    [SerializeField] GameObject wave;

    [SerializeField] private TMP_Text points;

    public BossBehaviour[] boss;

    private int bossNumber {get; set;}
    private int waves { get; set; }
    private float monsterSpeed;
    private int random;
    private int maxHealth;
    private static string FullCoins { get; set; }
    
    
    void Start()
    {
        damage = 30;
        coins = 3;
        maxHealth = 2000;
        bossCoins = 5;
        monsterSpeed = 2f;
        
        Laser.SetDamage(damage);
        BossBehaviour.SetHealth(maxHealth);
        BossBehaviour.SetCoins(bossCoins);
        MonsterBehaviour.SetCoins(coins);
        monster[0].SetSpeed(monsterSpeed);
        bottomLeftPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRightPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        PlayerBehaviour p = Instantiate(player);
        p.GainCoin += HandleCoinGaining;
        p.PlayerDied += HandlePlayerDied;
        BossBehaviour.BossDied += HandleBossDeath;
        waves = Random.Range(3, 7);
        StartGeneratingMonster();
    }

    private void OnDestroy()
    {
        BossBehaviour.BossDied -= HandleBossDeath;
    }

    void HandleBossDeath()
    {
        monsterSpeed += 0.2f;
        StartGeneratingMonster();
    }

    void HandlePlayerDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HandleCoinGaining()
    {
        ++coinsCount;
        points.text = coinsCount.ToString();
        FullCoins = coinsCount.ToString();
    }

    void StartGeneratingMonster()
    {
        InvokeRepeating("GenerateWave", 2, 3);
    }

    void GenerateWave()
    {
        if (waves == 0)
        {
            CancelInvoke();
            Invoke("GenerateBoss", 5f);
            waves = Random.Range(3, 7);
            damage += 5;
            Laser.SetDamage(damage);

            if (coins <= 10)
            {
                ++coins;
                MonsterBehaviour.SetCoins(coins);
            }

            return;
        }

        waves--;

        GameObject monsterWave = Instantiate(wave, Vector2.zero, Quaternion.identity, transform);

        for (int i = 0; i < 5; ++i)
        {
            random = Random.Range(0, monster.Length);
            float position = (i + 0.5f) / 5;
            Vector2 monsterPosition =
                Camera.main.ScreenToWorldPoint((new Vector2(Screen.width * position, Screen.height)));
            monsterPosition += Vector2.up * monster[random].transform.localScale.y;

            MonsterBehaviour monsterBehaviour =
                Instantiate(monster[random], monsterPosition, Quaternion.identity, monsterWave.transform);
            monsterBehaviour.SetSpeed(monsterSpeed);
        }
    }

    void GenerateBoss()
    {
        Vector2 position = new Vector2(0, topRightPosition.y + 2.5f);
        BossBehaviour bossBehaviour = Instantiate(boss[bossNumber], position, Quaternion.identity, transform);
        ++bossNumber;
        if (bossNumber > 3)
        {
            bossNumber = 0;
        }
        if (bossCoins <= 50)
        {
            bossCoins += 5;
            BossBehaviour.SetCoins(bossCoins);
        }
        
        maxHealth += 500;
        BossBehaviour.SetHealth(maxHealth);
    }

    public static string GetFullCoins()
    {
        return FullCoins;
    }
}