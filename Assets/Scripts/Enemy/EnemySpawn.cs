using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public Transform enemy;
    public Transform SpawnPoint;
    public float timeOfSpawn;
    public float countDown=2f;

    private int waveIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeOfSpawn;
        }

        countDown -= Time.deltaTime; 

	}

    IEnumerator SpawnWave()
    {

        waveIndex++;

        for (int i = 0; i <= waveIndex; i++)
        {
            SpawEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawEnemy()
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }

}
