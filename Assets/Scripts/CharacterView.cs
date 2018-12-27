using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour {

    Animator mAnimator;

	// Use this for initialization
	void Awake () {
        mAnimator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        mAnimator.Play(0);
	}
}
