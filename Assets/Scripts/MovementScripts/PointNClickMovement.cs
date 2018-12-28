using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointNClickMovement : MonoBehaviour {
    
    Rigidbody rigidbody;
    Vector3 target;
    public float speed;
    MeshRenderer renderedHoveredIn;
    Color savedColorFromCollider;
    bool hasColliderUnhovered;

    


    //Flag que indica si se esta moviendo
    bool isMoving;

    //Valores que se usa para calcular el camino al hacer click
    float distanceToClickedPoint;
    float startTime;
    Vector3 startPositionBeforeClicked;

    //Layers para el Raycast
    //Crear Walkable y Tower como layers y asignarles 9 y 10
    public enum Layer
    {
        Walkable = 9,
        Tower = 10,
        RaycastEndStop = -1
    }
    public Layer[] layerPriorities = {
        Layer.Tower,
        Layer.Walkable
    };
    RaycastHit raycastHit;
    Layer layerHit;


    //Que tanta distancia se usa en el raycast
    [SerializeField] float distanceToBackground = 100f;

    //Camara principal(se usa para el raycast)
    Camera viewCamera;


    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {
        


        RayCastAllLayers(ref raycastHit, ref layerHit);
        //Cuando presiona el click derecho va hacia la posicion del mouse
        if (Input.GetMouseButtonDown(0))
        {
            if (layerHit == Layer.Walkable)
            {

                target = raycastHit.point;
                target.y = rigidbody.position.y;
                startPositionBeforeClicked = rigidbody.position;
                distanceToClickedPoint =Vector3.Distance(startPositionBeforeClicked, target);
                startTime = Time.time;
                
                if (!isMoving) isMoving = true;
            }
            else if (layerHit == Layer.Tower)
            {
                OnClickBuilding(raycastHit);
            }

        }
         if (layerHit == Layer.Tower)
        {
            if (hasColliderUnhovered)
            {
                UnhoverSavedCollider(raycastHit);
            }
            OnHoverCollider(raycastHit);
        }
        else
        {
            UnhoverSavedCollider(raycastHit);
        }
        



        //Mientras no este en la meta
        if (isMoving)
        {
            Vector3 rbPosition = rigidbody.position;
            if (rbPosition == target) isMoving = false;
            else
            {
                float distCovered = (Time.time - startTime) * speed;
                float fracJourney = distCovered / distanceToClickedPoint;
                Debug.Log("% " + fracJourney*100);
                
                Debug.Log("startPosition: "+startPositionBeforeClicked);
                Debug.Log("target: "+target);
                Vector3 step = Vector3.Lerp(startPositionBeforeClicked, target, fracJourney);
                rigidbody.MovePosition(step);
            }
        }

    }
    void FixedUpdate()
    {

        
        
        
    }


    void OnClickBuilding(RaycastHit hit)
    {
        MeshRenderer renderer =hit.collider.GetComponent<MeshRenderer>();
        if (renderer)
        {
            renderer.material.color = Color.red;
        }
    }
    void OnHoverCollider(RaycastHit hit)
    {
        MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
        if (renderer)
        {
            savedColorFromCollider = renderer.material.color;
            renderer.material.color = Color.blue;
        }
        renderedHoveredIn = renderer;
        hasColliderUnhovered = true;

    }
    void UnhoverSavedCollider(RaycastHit hit)
    {
        
        if (hasColliderUnhovered&&renderedHoveredIn)
        {
            renderedHoveredIn.material.color = savedColorFromCollider;
            hasColliderUnhovered = false;
        }
        
    }
    void NotOnHoverOrClick(RaycastHit hit)
    {
        MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
        if (renderer)
        {
            renderer.material.color = Color.white;
        }
    }
    void OnClickPlane(RaycastHit hit)
    {

    }
    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer; 
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit; 
        bool hasHit = Physics.Raycast(ray, out hit, distanceToBackground, layerMask);
        if (hasHit)
        {
            //Debug.Log("has hit! " + layer.ToString());
            return hit;
        }
        return null;
    }
    void RayCastAllLayers(ref RaycastHit raycastHit,ref Layer layerHit)
    {
        
        layerHit = Layer.RaycastEndStop;
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                raycastHit = hit.Value;
                //if (layerHit != layer) // if layer has changed
                //{
                //    layerHit = layer;
                //     // call the delegates
                //}
                layerHit = layer;
                
            }
        }
        
        //Debug.Log("RayCastHit : " + layerHit.ToString());
    }

}
