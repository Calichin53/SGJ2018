using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCollision : MonoBehaviour
{
    private FlowResource parent;

    int index;

	void Start ()
    {
        parent = GetComponentInParent<FlowResource>();
    }
	
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piedra"))
        {
            parent.changeToMaterial(transform.GetSiblingIndex());
        }
    }

    private void OnCollisionExit()
    {
        parent.changeToMaterial(transform.parent.childCount);
    }
}
