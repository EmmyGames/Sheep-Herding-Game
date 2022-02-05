using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	public TextMeshProUGUI scoreText;

	private void Start() => scoreText.text = "You Scored " + GameState.Score + " points!";
}
