using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public static Vector2 bottomLeftPosition { get; set; }

    public static Vector2 topRightPosition { get; set; }

    //public PlayerBehaviour player { get; set; }
    public PlayerBehaviour player;

    public MonsterBehaviour monster;

    public GameObject wave;
    

    // Start is called before the first frame update
    void Start()
    {
        bottomLeftPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRightPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        Instantiate(player);
        
        StartMonsterGeneration();
    }

    void StartMonsterGeneration()
    {
        InvokeRepeating("GenerateWave", 2, 3); 
    }
    void GenerateWave()
    {
        GameObject monsterWave = Instantiate( wave, Vector2.zero, Quaternion.identity, transform);

        for (int i = 0; i < 5; i++)
        {
            float x = (i + 0.5f) / 5;
            Vector2 pos = Camera.main.ScreenToWorldPoint((new Vector2(Screen.width * x, Screen.height)));
            pos += Vector2.up * monster.transform.localScale.y;

            Instantiate(monster, pos, Quaternion.identity, monsterWave.transform);
        }
    }
}