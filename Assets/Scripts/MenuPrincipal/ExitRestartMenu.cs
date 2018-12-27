using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitRestartMenu : MonoBehaviour {
    public string menuScene;
    Canvas menu;
    bool pause=false;
    // Use this for initialization
    void Start () {
        menu=GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                menu.enabled = true;
                PauseGame();
                pause = true;
            }
            else
            {
                Debug.Log("Escape pressed again!");
                menu.enabled = false;
                pause = false;
                UnpauseGame();
            }
            
        }
	}



    public void LoadMenu()
    {
        UnpauseGame();
        SceneManager.LoadScene(menuScene, LoadSceneMode.Single);
    }
    public void RestartLevel()
    {
        UnpauseGame();
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void PauseGame()
    {
        //Cambiar esta linea por asignar estado de pausa en el gameManager
        Time.timeScale = 0f;
        //-----   
    }

    public void UnpauseGame()
    {
        //Cambiar esta linea por asignar estado de juego normal en el gameManager
        Time.timeScale = 1f;
        //-----   
    }

}
