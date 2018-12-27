using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowResource : MonoBehaviour
{
    public enum type
    {
        FIRE,
        WATER
    }

    private Transform paths;
    public type TowerType;
    private Color myColor;


	// Use this for initialization
	void Start ()
    {
        paths = GetComponentInChildren<Transform>();

        if (type.FIRE == TowerType)
        {
            myColor = Color.red;
        }
        else
        {
            myColor = Color.blue;
        }
    }
	
    public void changeToMaterial(int index)
    {
        for (int i = 0; i < paths.childCount; i++)
        {
            if (i >= index)
            {
                Material temp = paths.GetChild(i).gameObject.GetComponent<Renderer>().material;
                temp.color = Color.gray;
            }
            else
            {
                Material temp = paths.GetChild(i).gameObject.GetComponent<Renderer>().material;
                temp.color = myColor;
            }
        }
    }
}
