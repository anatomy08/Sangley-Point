using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour // ep 94-96
{
    int Score; 
    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "0000";
    }

    public void ScoreSystem(int amountIncrease)
    {
        Score += amountIncrease;
        
        scoreText.text = Score.ToString();
        
    }
}
