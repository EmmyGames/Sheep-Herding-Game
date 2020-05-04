using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "You Scored " + GameState.score + " points!";
    }
}
