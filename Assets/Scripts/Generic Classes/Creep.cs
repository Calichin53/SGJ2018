using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep {

    CreepType mType;
    CreepState mState;
    float mVelocity;
    float mCurrentHP;
    float mMaxHP;
    float dt, tmpTimer;
    Vector3 mPosition;

    public Vector3 Position { get { return mPosition; } }

	public Creep (CreepType Tipo, Vector3 posicion, float HP = 100f, float Velocidad = 5f) {
        mType = Tipo;
        mMaxHP = mCurrentHP = HP;
        mVelocity = Velocidad;
        mState = CreepState.Idle;
        mPosition = posicion;
	}
	
    public void Damage(float damage)
    {
        mCurrentHP -= damage;
        if (mCurrentHP <= 0)
        {
            //Matame
            mState = CreepState.Dead;
        }
    }

    public bool isAlive()
    {
        if (mCurrentHP <= 0)
            return false;
        else
            return true;
    }

    public void Update(float DeltaTime)
    {
        dt = DeltaTime;

        switch (mState)
        { case CreepState.Idle: //No hacemos nada
                break;
            case CreepState.Walking: //Nos movemos
                break;
            case CreepState.Dying: //Ejecuta animación de Muerte
                //Al terminar la animación se va a Dead
                mState = CreepState.Dead;
                break;
            case CreepState.Dead: //Estamos muertos
                break;
            default:
                break;
        }

    }
}

public enum CreepType { Normal, Air, Immune};
public enum CreepState { Idle, Walking, Dying, Dead};