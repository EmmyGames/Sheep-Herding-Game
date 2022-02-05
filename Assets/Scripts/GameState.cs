using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
	private const int BASE_TIME_INCREASE = 4;
	private const int BLACK_TIME_INCREASE = 10;
	public static int Score;
	public Text scoreText;
	public AudioClip ding;


	private void Start() => scoreText.text = "Score: " + Score;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Sheep"))
		{
			//Destroys the collider so it can't trigger more than once
			Destroy(other);
			//Destroys the sheep after a delay
			Destroy(other.gameObject, 2);
			Score++;
			CountdownTimer.CurrentTime += BASE_TIME_INCREASE;
			scoreText.text = "Score: " + Score;
			GetComponent<AudioSource>().PlayOneShot(ding);
		}
		if (other.gameObject.CompareTag("Black Sheep"))
		{
			//Destroys the collider so it can't trigger more than once
			Destroy(other);
			//Destroys the sheep after a delay
			Destroy(other.gameObject, 2);
			Score++;
			CountdownTimer.CurrentTime += BLACK_TIME_INCREASE;
			scoreText.text = "Score: " + Score;
			GetComponent<AudioSource>().PlayOneShot(ding);
		}
		if (other.gameObject.CompareTag("Gold Sheep"))
		{
			//Destroys the collider so it can't trigger more than once
			Destroy(other);
			//Destroys the sheep after a delay
			Destroy(other.gameObject, 2);
			Score += 5;
			CountdownTimer.CurrentTime += BLACK_TIME_INCREASE;
			scoreText.text = "Score: " + Score;
			GetComponent<AudioSource>().PlayOneShot(ding);
		}
	}
}
