using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviourScript : MonoBehaviour {

    public Transform mParentTransform;
    public Transform mLifeBarTransform;
    public Transform mColorTransform;
    public SpriteRenderer mColorRenderer;
    public Animator mAnimator;
    Creep mCreep;
    NavMeshAgent mAgent;
    float mDeadDelay;

	// Use this for initialization
	void Start () {
        mCreep = new Creep(CreepType.Normal, transform.position);
        mAgent =  GetComponentInParent<NavMeshAgent>();
        mAgent.destination=GameObject.FindGameObjectWithTag("PathEnd").transform.position;
        mDeadDelay = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        if (mCreep != null)
        {
            mCreep.Position = mParentTransform.position;
            if (!mCreep.isAlive())
            {
                //Animación de muerte
                if (mDeadDelay >= 3f)
                {
                    mAgent.destination = transform.position;
                    mAnimator.Play("Muerte_Rapida");
                }
                mDeadDelay -= Time.deltaTime;
                if (mDeadDelay <= 0)
                { Destroy(this.gameObject); }
            }

            UpdateLifeBar();
            mCreep.Damage(2 * Time.deltaTime);
            //if (Input.GetKeyDown(KeyCode.M))
            //{ mCreep.Damage(10); }
        }
	}

    void UpdateLifeBar()
    {
        mLifeBarTransform.LookAt(Camera.main.transform);
        mColorRenderer.color = GetBarColor();
        //mColorTransform.position = GetBarPosition();
        mColorTransform.localPosition = GetBarPosition();
        mColorRenderer.size = new Vector2(mCreep.currentRangeHP(), 0.1f);
        

    }

    Color GetBarColor()
    {
        return new Color(1f - mCreep.currentRangeHP(), mCreep.currentRangeHP(), 0);
    }

    Vector3 GetBarPosition()
    {
        return new Vector3((1f-mCreep.currentRangeHP())/ 4f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PathEnd")
            Debug.Log("Llegamos por OnTrigger");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PathEnd")
            Debug.Log("Llegamos por Collision");
    }
}
