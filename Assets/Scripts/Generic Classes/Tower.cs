using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower {

    public TowerType mType;
    public TowerState mState;
    public float AttackRate, AttackPoints;
    public float BuildingSpeed, BuildingCost;
    float tmpTimer, dt, mRange;
    public Creep Target;
    public bool HasATarget;
    Tower NextUpgrade;
    Vector3 mPosition;


    public Tower(Vector3 Posicion, TowerType Tipo = TowerType.BasicTower,float ARate=1f, float APoints=10f,float BSpeed=10f, float BCost=5f, float Rango=4f)
    {
        //Constructor
        mState = TowerState.Idle;
        mType = Tipo;
        HasATarget = false;
        mPosition = Posicion;
        AttackRate = ARate;
        AttackPoints = APoints;
        BuildingSpeed = BSpeed;
        BuildingCost = BCost;
        mRange = Rango;        
    }

    public void CopyModel(Tower Modelo)
    {
        //Constructor, creamos una copia de otra torre
        mType = Modelo.mType;
        AttackPoints = Modelo.AttackPoints;
        AttackRate = Modelo.AttackRate;
        BuildingSpeed = Modelo.BuildingSpeed;
        BuildingCost = Modelo.BuildingCost;
        mRange = Modelo.mRange;

        tmpTimer = dt = 0;
        Target = null;
        NextUpgrade = null;
        mState = TowerState.Idle;
        HasATarget = false;
    }

    public void GetNewTarget()
    {
        float minDistance=1000f;
        float tmp = 0;
        for (int i = 0; i < GameManager.instance.CreepsInLevel.Count;)
        {
            tmp = (GameManager.instance.CreepsInLevel[i].Position - mPosition).magnitude;
            if ( tmp<= mRange)
            {
                if (tmp < minDistance)
                {
                    minDistance = tmp;
                    Target = GameManager.instance.CreepsInLevel[i];
                    HasATarget = true;
                }
            }
        }
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

    //En Deshuso
    public bool IsInRange(Vector3 Objetivo)
    {
        if ((mPosition - Objetivo).magnitude <= mRange)
            return true; 
        else
            return false;
    }

    public void Update(float DeltaTime)
    {
        //Se gestiona la máquina de estados

        dt = DeltaTime;
        switch (mState)
        {
            case TowerState.Idle://Esperamos un nuevo objetivo
                if (!HasATarget)
                {
                    //AskForTarget();
                    GetNewTarget();
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
            case TowerState.Destructed:// No hacemos nada, tas muerto
                break;
            default:
                break;
        }
    }

}

public enum TowerType { BasicTower, WaterTower, FireTower };
public enum TowerState { Building, Idle, Attacking, Blocked, Destructed};