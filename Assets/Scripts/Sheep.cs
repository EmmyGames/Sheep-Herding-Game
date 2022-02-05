using System.Collections;
using UnityEngine;

public class Sheep : MonoBehaviour
{
	public GameObject sheepPrefab;
	public GameObject blackSheepPrefab;
	public GameObject goldSheepPrefab;
	private const float RESPAWN_TIME = 6.0f;


	private void Start()
	{
		// spawn 10 sheep
		StartCoroutine(SheepWave());
		for (var i = 0; i < 10; i++) SpawnSheep();
	}

	private void SpawnSheep()
	{
		//goes from 1 to 30
		var specialSheep = Random.Range(1, 31);
		GameObject sheep;
		//1 in 30 chance for gold sheep
		if (specialSheep == 30)
			sheep = Instantiate(goldSheepPrefab);
		//1 in 15 chance of black sheep
		else if (specialSheep > 0 && specialSheep < 3)
			sheep = Instantiate(blackSheepPrefab);
		//26 in 30 chance for normal sheep
		else
			sheep = Instantiate(sheepPrefab);
		float x = Random.Range(-45, 45);
		float z = Random.Range(-40, 45);
		sheep.transform.position = new Vector3(x, 0.0f, z);
	}

	private IEnumerator SheepWave()
	{
		while (true)
		{
			yield return new WaitForSeconds(RESPAWN_TIME);
			SpawnSheep();
		}
	}
}
