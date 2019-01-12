using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    public Transform mParentTransform;
    public Transform mLifeBarTransform;
    public Transform mColorTransform;
    public SpriteRenderer mColorRenderer;
    public Animator mAnimator;
    public AudioClip[] EnemySounds;

    AudioSource mAudioSource;
    Creep mCreep;
    NavMeshAgent mAgent;
    float mDeadDelay;

	// Use this for initialization
	void Start () {
        mCreep = new Creep(CreepType.Normal, transform.position);
        mAgent =  GetComponentInParent<NavMeshAgent>();
        mAudioSource = GetComponentInParent<AudioSource>();
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
                    mAudioSource.clip = EnemySounds[0];
                    mAudioSource.Play();
                }
                mDeadDelay -= Time.deltaTime;
                if (mDeadDelay <= 0)
                { Destroy(this.mParentTransform.gameObject); }
            }

            UpdateLifeBar();
            mCreep.Damage(3 * Time.deltaTime);
            //if (Input.GetKeyDown(KeyCode.M))
            //{ mCreep.Damage(10); }
        }
	}

    public void PlayRandomSound()
    {
        mAudioSource.clip = EnemySounds[Random.Range(1, 3)];
        mAudioSource.Play();
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

    public Creep GetCreep()
    {
        return mCreep;
    }
}
