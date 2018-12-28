using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour {
    public Transform towerPrincipal;
    NavMeshAgent creep;
    private bool dentro = false;

    public NexoController poinLife;
	// Use this for initialization
	void Start () {
        creep = GetComponent<NavMeshAgent>();
        towerPrincipal = GameObject.FindGameObjectWithTag("PathEnd").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (!dentro)
        {
            creep.destination = towerPrincipal.position;
            
        }
        if (dentro)
        {
            
            creep.destination = this.transform.position;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dentro = false;
        }
    }

}
