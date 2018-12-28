using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NexoController : MonoBehaviour {
    //public Text life;
    public float vida;

    public EnemyNavMesh golpe;

	// Use this for initialization
	void Start () {
        //life.text = vida.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        Destroy(other.gameObject);

        /*if (other.CompareTag("Enemy"))
        {
            //vida -= golpe.daño;
        }
        //life.text = vida.ToString();*/
    }

}
