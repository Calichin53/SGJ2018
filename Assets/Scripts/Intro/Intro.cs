using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    Image FondoColor;
    Color color;
    public AudioClip[] Pasos;
    public AudioSource Audio;
    public float StepRate, FadeAlphaRate, GeneralDelay;
    public Text floro;
    float tmpTimer;
    bool OkDelay;

	// Use this for initialization
	void Start () {
        FondoColor = GetComponent<Image>();
        tmpTimer = 0;
        OkDelay = false;
        floro.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        tmpTimer += Time.deltaTime;
        
        if (tmpTimer >= StepRate)
        {
            tmpTimer -= StepRate;
            PlayAnotherStep();
        }
        GeneralDelay -= Time.deltaTime;
        if (GeneralDelay <= 0f)
        { OkDelay = true;
            floro.gameObject.SetActive(true);
        }

        if (OkDelay)
        {
            color = FondoColor.color;
            color.a -= FadeAlphaRate * Time.deltaTime;
            FondoColor.color = color;
            if (FondoColor.color.a <= 0.2f)
            {
                FadeAlphaRate *= -1;
                floro.text = "Da Pr0t3kToR of da Neitur";
            }
            if (FondoColor.color.a >= 1f)
            {
                Debug.Log("FIN");
                SceneManager.LoadScene("Menu");
            }
        }

        Audio.volume = 1.2f - FondoColor.color.a;
    }

    void PlayAnotherStep()
    {
        Audio.clip = Pasos[Random.Range(0, 3)];
        Audio.Play();
    }

}
