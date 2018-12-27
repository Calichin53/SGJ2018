using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [Header("EnemigoBasico")]

    public float speed;
    public float daño;


    private Transform target;
    private int wavePointIndex = 0;


	// Use this for initialization
	void Start ()
    {
        target = WayPoint.points[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNext();
        }
	}

    void GetNext()
    {
        if (wavePointIndex >= WayPoint.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        wavePointIndex++;
        target = WayPoint.points[wavePointIndex];
    }


}
