using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower {

    TowerType mType;

    public Tower()
    {
        mType = TowerType.BasicTower;
        //Constructor
    }

}

public enum TowerType { BasicTower, WaterTower, FireTower };
public enum TowerState { Building, Idle, Attacking, Blocked, Destructed};