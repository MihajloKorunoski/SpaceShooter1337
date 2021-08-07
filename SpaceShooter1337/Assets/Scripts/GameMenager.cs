using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenager : MonoBehaviour
{
    public static Vector2 bottomLeftPosition { get; set; }

    public static Vector2 topRightPosition { get; set; }
    
    private int coins {get; set;}

    //public PlayerBehaviour player { get; set; }
    [SerializeField]
    PlayerBehaviour player;

    [SerializeField]
    MonsterBehaviour monster;

    [SerializeField]
    GameObject wave;

    [SerializeField]
    private TMP_Text points;
    
    void Start()
    {
        bottomLeftPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRightPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        PlayerBehaviour p = Instantiate(player) as PlayerBehaviour;
        p.GainCoin += HandleCoinGaining;
        StartGeneratingMonster();
    }

    void HandleCoinGaining()
    {
        ++coins;
        points.text = coins.ToString();
    }
    void StartGeneratingMonster()
    {
        InvokeRepeating("GenerateWave", 2, 3); 
    }
    void GenerateWave()
    {
        GameObject monsterWave = Instantiate( wave, Vector2.zero, Quaternion.identity, transform);

        for (int i = 0; i < 5; ++i)
        {
            float position = (i + 0.5f) / 5;
            Vector2 monsterPosition = Camera.main.ScreenToWorldPoint((new Vector2(Screen.width * position, Screen.height)));
            monsterPosition += Vector2.up * monster.transform.localScale.y;

            Instantiate(monster, monsterPosition, Quaternion.identity, monsterWave.transform);
        }
    }
}