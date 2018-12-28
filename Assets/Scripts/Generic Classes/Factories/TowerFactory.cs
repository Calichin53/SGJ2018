using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TowerFactory {

    public static Tower NewTowerofType(TowerType Tipo)
    {
        Tower tmp;

        switch (Tipo)
        {
            case TowerType.BasicTower:
                //tmp= new Tower()
                tmp = null;
                break;
            case TowerType.FireTower:
                tmp = null;
                break;
            case TowerType.WaterTower:
                tmp = null;
                break;
            default:
                tmp = null;
                break;
        }
        return tmp;
    }
}
