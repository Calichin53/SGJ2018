using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawn : MonoBehaviour {
    public Transform enemy;
    public Transform SpawnPoint;
    public float timeOfSpawn;
    public float countDown=2f;
    public Text oleada;



    private int waveIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (countDown <= 0f)
        {
            StartCoroutine(WaitForSpawn());
            countDown = timeOfSpawn;
        }

        countDown -= Time.deltaTime;
        oleada.text = "Siguiente oleada en: "+ Mathf.Round(countDown).ToString() +"s";
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

    IEnumerator WaitForSpawn()
    {

        StartCoroutine(SpawnWave());
        yield return new WaitForSeconds(4f);
        

    }


    void SpawEnemy()
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }

}
