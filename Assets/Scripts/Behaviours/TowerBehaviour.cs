using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {

    public TowerType Tipo;
    Tower mTower;
	// Use this for initialization
	void Start () {
        CreateTower();
	}
	
	// Update is called once per frame
	void Update () {
        if (mTower != null)
        { mTower.Update(Time.deltaTime); }
	}

    void CreateTower()
    {
        mTower = TowerFactory.NewTowerofType(Tipo,transform.position);
    }
}
