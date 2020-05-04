using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static int score = 0;
    const int baseTimeIncrease = 4;
    const int blackTimeIncrease = 10;
    public Text scoreText;
    public AudioClip ding;

    private void Start()
    {
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sheep")
        {
            //Destroys the collider so it can't trigger more than once
            Destroy(other);
            //Destroys the sheep after a delay
            Destroy(other.gameObject, 2);
            score++;
            CountdownTimer.currentTime += baseTimeIncrease;
            scoreText.text = "Score: " + score;
            GetComponent<AudioSource>().PlayOneShot(ding);
        }
        if(other.gameObject.tag == "Black Sheep")
        {
            //Destroys the collider so it can't trigger more than once
            Destroy(other);
            //Destroys the sheep after a delay
            Destroy(other.gameObject, 2);
            score++;
            CountdownTimer.currentTime += blackTimeIncrease;
            scoreText.text = "Score: " + score;
            GetComponent<AudioSource>().PlayOneShot(ding);
        }
        if(other.gameObject.tag == "Gold Sheep")
        {
            //Destroys the collider so it can't trigger more than once
            Destroy(other);
            //Destroys the sheep after a delay
            Destroy(other.gameObject, 2);
            score+= 5;
            CountdownTimer.currentTime += blackTimeIncrease;
            scoreText.text = "Score: " + score;
            GetComponent<AudioSource>().PlayOneShot(ding);
        }
    }
}
