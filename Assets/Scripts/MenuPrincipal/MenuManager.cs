using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public string firstLevelScene;
    public string creditsScene;

    public Animator playAnim;
    public Animator exitAnim;
    public Animator creditsAnim;
    bool hasPressed;
    enum MenuState { PLAY=0, EXIT=1, CREDITS=2};
    private MenuState state;
    // Use this for initialization
    void Start () {
        state = 0;

    }
	
	// Update is called once per frame
	void Update () {
        hasPressed = true;
        if (Input.GetKeyDown(KeyCode.UpArrow)) state = (MenuState)(((int)(state + 2)) % 3);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) state = (MenuState)(((int)(state + 1)) % 3);
        else hasPressed = false;
        Debug.Log("state : "+ state);
        if (hasPressed)
        {
            if(state== MenuState.PLAY)
            {
                playAnim.SetBool("isSelected", true);
                exitAnim.SetBool("isSelected", false);
                creditsAnim.SetBool("isSelected", false);
            }
            else if (state == MenuState.EXIT)
            {
                exitAnim.SetBool("isSelected", true);
                playAnim.SetBool("isSelected", false);
                creditsAnim.SetBool("isSelected", false);
            }
            else if (state == MenuState.CREDITS)
            {
                creditsAnim.SetBool("isSelected", true);
                exitAnim.SetBool("isSelected", false);
                playAnim.SetBool("isSelected", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (state == MenuState.PLAY)
            {
                LoadFirstLevel();
            }
            else if (state == MenuState.EXIT)
            {
                ExitGame();
            }
            else if (state == MenuState.CREDITS)
            {
                LoadCredits();
            }
        }


    }

    



    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(firstLevelScene, LoadSceneMode.Single);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene(creditsScene, LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
