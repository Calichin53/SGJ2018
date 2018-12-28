using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour {
    //public string menuScene;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
	}



    public void LoadMenu()
    {
        GameManager.instance.ChangeMusicIndex(0);
        //SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    
}
