using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep {

    CreepType mType;
    CreepState mState;
    float mVelocity;
    float mCurrentHP;
    float mMaxHP;

	public Creep (CreepType Tipo, float HP = 100f, float Velocidad = 5f) {
        mType = Tipo;
        mMaxHP = mCurrentHP = HP;
        mVelocity = Velocidad;
        mState = CreepState.Idle;
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
}

public enum CreepType { Normal, Air, Immune};
public enum CreepState { Idle, Walking, Dying, Dead};