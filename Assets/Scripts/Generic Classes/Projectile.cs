using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile {

    ProjectileType mType;
    ProjectileState mState;
    Vector3 mPosition, mDirection;
    float mVelocity, tmpTimer, dt, mDamage;
    public bool destroyMe;
    Creep mTarget;

    public Projectile(Creep Objetivo, Vector3 Posicion, float Velocidad= 10f, ProjectileType Tipo= ProjectileType.Normal, float Dano= 10f)
    {
        mType = Tipo;
        mPosition = Posicion;
        mVelocity = Velocidad;
        mTarget = Objetivo;
        dt = tmpTimer=0;
        destroyMe = false;
    }

	public void Update (float DeltaTime) {
        dt = DeltaTime;
        switch (mState)
        {
            case ProjectileState.Initialized:
                mState = ProjectileState.Moving;
                Move();
                break;
            case ProjectileState.Moving://Persigue al objetivo

                //Considerar que si se pierde el objetivo igual se debe llegar hasta el último punto donde estuvo
                break;
            case ProjectileState.ReachingTarget://Objetivo alcanzado, asignar daño
                DamageTarget();
                break;
            case ProjectileState.Destroy://Esperar hasta ser destruido
                destroyMe = true;
                break;
        }
	}

    void DamageTarget()
    { mTarget.Damage(mDamage);
        mState=ProjectileState.Destroy;
    }

    void Move()
    {
        mDirection = (mTarget.Position - mPosition).normalized;
        mPosition += mDirection * mVelocity * dt;
    }

    public void TargetReached()
    { mState= ProjectileState.ReachingTarget; }

}

public enum ProjectileType{Normal, Fire, Water};
public enum ProjectileState {Initialized, Moving, ReachingTarget, Destroy};
