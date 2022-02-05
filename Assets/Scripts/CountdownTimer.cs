using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
	public static float CurrentTime;
	public Text timerText;
	//Make this 1 second higher than you think, it floors the time
	[SerializeField]
	private float startingTime = 51f;
	private int _minutes;
	private int _seconds;

	private void Start()
	{
		CurrentTime = startingTime;
		_minutes = Mathf.FloorToInt(CurrentTime / 60);
		_seconds = Mathf.FloorToInt(CurrentTime % 60);
		timerText.text = _minutes + ":" + _seconds.ToString("00");
	}

	private void Update()
	{
		CurrentTime -= 1 * Time.deltaTime;
		_minutes = Mathf.FloorToInt(CurrentTime / 60);
		_seconds = Mathf.FloorToInt(CurrentTime % 60);
		timerText.text = _minutes + ":" + _seconds.ToString("00");
		//this is 1 instead of 0 because the seconds are floored and will display negative if it goes to 0
		if (CurrentTime <= 1)
		{
			SceneManager.LoadScene("Lose");
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
