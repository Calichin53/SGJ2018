using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower {

    public TowerType mType;
    public TowerState mState;
    public float AttackRate, AttackPoints;
    public float BuildingSpeed, BuildingCost;
    float tmpTimer, dt;
    public Creep Target;
    public bool HasATarget;
    Tower NextUpgrade;


    public Tower()
    {
        //Constructor

        mType = TowerType.BasicTower;
        HasATarget = false;
        
    }

    public void CopyModel(Tower Modelo)
    {
        //Constructor, creamos una copia de otra torre
        mType = Modelo.mType;
        AttackPoints = Modelo.AttackPoints;
        AttackRate = Modelo.AttackRate;
        BuildingSpeed = Modelo.BuildingSpeed;
        BuildingCost = Modelo.BuildingCost;

        tmpTimer = dt = 0;
        Target = null;
        NextUpgrade = null;
        mState = TowerState.Idle;
        HasATarget = false;
    }

    public void AskForTarget()
    {
        //Solicita al GameManager un nuevo objetivo

    }

    public void Attack()
    {
        //Ataca

        if (HasATarget)
        {
            tmpTimer += dt;
            if (tmpTimer >= AttackRate)
            {
                tmpTimer -= AttackRate;
                Target.Damage(AttackPoints);
                if (!Target.isAlive())
                    HasATarget = false;
            }
        }
        else
        {
            mState = TowerState.Idle;
        }
    }

    public void Build()
    {
        if (NextUpgrade != null)
        {
            tmpTimer += dt;
            if (tmpTimer >= NextUpgrade.BuildingSpeed)
            { CopyModel(NextUpgrade); }
        }
    }

    public void UnBlock()
    {
        mState = TowerState.Idle;
    }

    public void Block()
    {
        mState = TowerState.Blocked;
    }

    public void Update(float deltaTime)
    {
        //Se gestiona la máquina de estados

        dt = deltaTime;
        switch (mState)
        {
            case TowerState.Idle://Esperamos un nuevo objetivo
                if (!HasATarget)
                {
                    AskForTarget();
                }
                else
                {
                    mState = TowerState.Attacking;
                }
                break;
            case TowerState.Blocked://No hacemos nada mientras siga bloqueado
                break;
            case TowerState.Building:// Construimos
                Build();
                break;
            case TowerState.Attacking:
                Attack();
                break;
            case TowerState.Destructed:// No hacemos nada
                break;
            default:
                break;
        }
    }

}

public enum TowerType { BasicTower, WaterTower, FireTower };
public enum TowerState { Building, Idle, Attacking, Blocked, Destructed};