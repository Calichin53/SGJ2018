using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    Projectile mProjectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (mProjectile != null)
        {
            mProjectile.Update(Time.deltaTime);
            if (mProjectile.destroyMe)
            { Destroy(this.gameObject); }
        }
	}

    public void SetUp(Projectile proyectil)
    {
        mProjectile = proyectil;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            mProjectile.TargetReached();
        }
    }

}
