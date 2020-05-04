using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSheep : MonoBehaviour
{
    public GameObject sheepPrefab;
    public GameObject blackSheepPrefab;
    public GameObject goldSheepPrefab;
    private float respawnTime = 6.0f;

    private void Start()
    {
        // spawn 10 sheep
        StartCoroutine(sheepWave());
        for(int i = 0; i < 10; i++)
        {
            spawnSheep();
        }
    }

    void spawnSheep()
    {
        //goes from 1 to 30
        int specialSheep = Random.Range(1, 31);
        GameObject sheep;
        //1 in 30 chance for gold sheep
        if(specialSheep == 30)
        {
            sheep = Instantiate(goldSheepPrefab) as GameObject;
        }
        //1 in 15 chance of black sheep
        else if (specialSheep > 0 && specialSheep < 3)
        {
            sheep = Instantiate(blackSheepPrefab) as GameObject;
        }
        //26 in 30 chance for normal sheep
        else
        {
            sheep = Instantiate(sheepPrefab) as GameObject;
        }
        float x = Random.Range(-45, 45);
        float z = Random.Range(-40, 45);
        sheep.transform.position = new Vector3(x, 0.0f, z);
    }

    IEnumerator sheepWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnSheep();
        }
    }
}
