using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexoController : MonoBehaviour {
    public Text life;
    public float vida;

    public EnemyController golpe;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            vida -= golpe.daño;
        }
        life.text = vida.ToString();
    }

}
