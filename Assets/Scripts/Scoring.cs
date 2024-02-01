using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Scoring : MonoBehaviour
{
    public TMP_Text ScoreValue;
    int ScoreValueI;

    public float furthestX = 0;

    public int DistanceScoreMultiplier = 50;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.x != furthestX && gameObject.transform.position.x > furthestX) 
        { 
            furthestX = gameObject.transform.position.x;
            UpdateScore(DistanceScoreMultiplier);
        }
    }

    public void UpdateScore(int score)
    {
        ScoreValueI = int.Parse(ScoreValue.text);
        ScoreValueI += score;
        ScoreValue.text = ScoreValueI.ToString();
    }
}
