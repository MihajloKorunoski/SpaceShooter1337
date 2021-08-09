using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
    [SerializeField] private TMP_Text points;
    
    void Start()
    {
        points.text = GameMenager.GetFullCoins();
        if (points.text == null)
            points.text = ("0");
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}