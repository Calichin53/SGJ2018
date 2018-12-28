using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TowerFactory {

    public static Tower NewTowerofType(TowerType Tipo, Vector3 Posicion)
    {
        Tower tmp;

        switch (Tipo)
        {
            case TowerType.BasicTower:
                tmp = new Tower(Posicion);
                break;
            case TowerType.FireTower:
                tmp = new Tower(Posicion, TowerType.FireTower, 2f, 25f);
                
                break;
            case TowerType.WaterTower:
                tmp = new Tower(Posicion, TowerType.WaterTower,0.5f,6f);
                break;
            default:
                tmp = null;
                break;
        }
        return tmp;
    }
}
