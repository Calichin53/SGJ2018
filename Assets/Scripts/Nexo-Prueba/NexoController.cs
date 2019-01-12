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
        //Destroy(other.gameObject);
        //Disminuir puntos de vida
        //other.gameObject.GetComponentInChildren<EnemyBehaviourScript>().PlayRandomSound();
        if (other.tag == "enemy")
        {
            GameManager.instance.PlayerGetDamaged(1);

            GameManager.instance.RemoveEnemy(other.gameObject);
            Debug.Log("recibes " + 1 + " de daño...");
        }
            /*if (other.CompareTag("Enemy"))
        {
            //vida -= golpe.daño;
        }
        //life.text = vida.ToString();*/
    }

}
