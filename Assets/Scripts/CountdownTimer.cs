using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public static float currentTime = 0f;
    //Make this 1 second higher than you think, it floors the time
    float startingTime = 51f;
    int minutes;
    int seconds;

    public Text timerText;

    private void Start()
    {
        currentTime = startingTime;
        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = minutes + ":" + seconds.ToString("00");
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        minutes = Mathf.FloorToInt(currentTime / 60);
        seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = minutes + ":" + seconds.ToString("00");
        //this is 1 instead of 0 because the seconds are floored and will display negative if it goes to 0
        if(currentTime <= 1)
        {
            SceneManager.LoadScene("Lose");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
