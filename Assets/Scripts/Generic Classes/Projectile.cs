using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile {

    ProjectileType mType;
    ProjectileState mState;
    Vector3 mPosition;
    float mVelocity, tmpTimer, dt, mDamage;
    Creep mTarget;

    public Projectile(Creep Objetivo, Vector3 Posicion, float Velocidad= 10f, ProjectileType Tipo= ProjectileType.Normal, float Daño= 10f)
    {
        mType = Tipo;
        mPosition = Posicion;
        mVelocity = Velocidad;
        mTarget = Objetivo;
        dt = tmpTimer=0;
    }

	void Update (float DeltaTime) {
        dt = DeltaTime;
        switch (mState)
        {
            case ProjectileState.Initialized:
                mState = ProjectileState.Moving;
                break;
            case ProjectileState.Moving://Persigue al objetivo

                //Considerar que si se pierde el objetivo igual se debe llegar hasta el último punto donde estuvo
                break;
            case ProjectileState.ReachingTarget://Objetivo alcanzado, asignar daño
                DamageTarget();
                break;
            case ProjectileState.Destroy://Esperar hasta ser destruido
                break;
        }
	}

    void DamageTarget()
    { mTarget.Damage(mDamage);
        mState=ProjectileState.Destroy;
    }

}

public enum ProjectileType{Normal, Arco, Laser};
public enum ProjectileState {Initialized, Moving, ReachingTarget, Destroy};
