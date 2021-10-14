using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracking : MonoBehaviour
{
    private int score = 0;
    public string text;
    public Text textelement;

    void Start()
    {
        text = string.Format("Score: {0}", score);
        textelement.text = text;
    }

    void Update()
    {
        text = string.Format("Score: {0}", score);
    }

    public void incrementScore(int amount)
    {
        score += amount;
    }
}
