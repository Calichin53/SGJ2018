using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBehaviour : MonoBehaviour {

    public Text LifeText, WavesText, YYText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTextsInDisplay();
	}

    void UpdateTextsInDisplay()
    {
        LifeText.text = GameManager.instance.Lifes.ToString();
        WavesText.text = GameManager.instance.CurrentWave + " / " + GameManager.instance.TotalWaves;
        YYText.text = GameManager.instance.GetResource(ResourceType.YinYang).ToString();

    }
}
