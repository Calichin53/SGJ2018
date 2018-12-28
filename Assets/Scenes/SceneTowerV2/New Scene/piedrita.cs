using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piedrita : MonoBehaviour {

    public Transform platform;
    public Transform target;
    public float speed = 1;
    public bool activado_switch=false;
    private Vector3 start, end;

    // Use this for initialization
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (activado_switch) {
            if (target != null)
            {
                float fixeUpdate = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, fixeUpdate);
            }
            ;
        }

        if (transform.position == target.position)
        {
            activado_switch = false;
            //operador ternario "?"
            target.position = (target.position == start) ? end : start;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && target != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(platform.position, target.position);
            Gizmos.DrawSphere(platform.position, 0.15f);
            Gizmos.DrawSphere(target.position, 0.15f);
        }
    }
}
