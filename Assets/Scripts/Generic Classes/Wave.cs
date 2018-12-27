using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave {

    public int mCantidad;
    public CreepType mType;
    public float mDelay;
    
    public Wave(int Cantidad =10, CreepType Tipo = CreepType.Normal, float Retraso = 5f)
    {
        mCantidad = Cantidad;
        mType = Tipo;
        mDelay = Retraso;
    }
}
