using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    public static Vector2 bottomLeftPosition { get; set; }

    public static Vector2 topRightPosition { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        bottomLeftPosition = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRightPosition = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}