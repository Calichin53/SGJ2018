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


    public Tower()
    {
        //Constructor

        mType = TowerType.BasicTower;
        HasATarget = false;
        
    }

    public void AskForTarget()
    {

    }

    public void Attack()
    {
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
            AskForTarget();
        }
    }

    public void Build()
    {

    }

    public void Update(float deltaTime)
    {
        dt = deltaTime;
        switch (mState)
        {
            case TowerState.Idle:
                break;
            case TowerState.Blocked:
                break;
            case TowerState.Building:
                break;
            case TowerState.Attacking:
                break;
            case TowerState.Destructed:
                break;
            default:
                break;
        }
    }

}

public enum TowerType { BasicTower, WaterTower, FireTower };
public enum TowerState { Building, Idle, Attacking, Blocked, Destructed};