using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {

    public TowerType Tipo;
    public GameObject BulletModel;
    Tower mTower;
	// Use this for initialization
	void Start () {
        CreateTower();
	}
	
	// Update is called once per frame
	void Update () {
        if (mTower != null)
        { mTower.Update(Time.deltaTime);
            if (mTower.Fire == true)
            {
                FireToenemy();
                mTower.Fire = false;
            }
        }
	}

    void CreateTower()
    {
        mTower = TowerFactory.NewTowerofType(Tipo,transform.position);
    }

    void FireToenemy()
    {
        GameObject newBullet;
        newBullet = Instantiate(BulletModel);
        switch (Tipo)
        {   case TowerType.BasicTower:
                newBullet.GetComponent<ProjectileBehaviour>().SetUp(new Projectile(mTower.Target, transform.position,1f,ProjectileType.Normal, mTower.AttackPoints));
                break;
            case TowerType.FireTower:
                newBullet.GetComponent<ProjectileBehaviour>().SetUp(new Projectile(mTower.Target, transform.position, 0.5f,ProjectileType.Fire, mTower.AttackPoints));
                break;
            case TowerType.WaterTower:
                newBullet.GetComponent<ProjectileBehaviour>().SetUp(new Projectile(mTower.Target, transform.position, 5f, ProjectileType.Water, mTower.AttackPoints));
                break;
            default:
                break;
        }
    }

}
