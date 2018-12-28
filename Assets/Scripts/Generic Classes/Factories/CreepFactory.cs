using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreepFactory {


    public static Creep NewCreepofType(CreepType Tipo, Vector3 Posicion)
    {
        Creep tmp;
        switch (Tipo)
        {
            case CreepType.Normal:
                tmp = new Creep(Tipo, Posicion);
                break;
            case CreepType.Immune:
                tmp = new Creep(Tipo, Posicion);
                break;
            default:
                tmp = null;
                break;
        }
        return tmp;
    }

}
