using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    List<int> mResources;
    int mCurrentWave, mTotalWaves, mLifes;
    GameState mState;
    public int CurrentWave { get { return mCurrentWave; } }
    public int TotalWaves { get { return mTotalWaves; } set { mTotalWaves = value; } }
    public int Lifes { get { return mLifes; }set { mLifes = value; } }


	// Use this for initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            mResources = new List<int>();
            mState = GameState.Initializing;

            for (int i = 0; i < 4; i++)//Reemplazar con la cantidad de recursos
            {
                mResources.Add(0);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetResource(ResourceType Recurso)
    { return mResources[(int)Recurso]; }

    public void AddResource(ResourceType TipoRecurso, int CantidadRecurso)
    {
        mResources[(int)TipoRecurso] += CantidadRecurso;
    }

    public void ConfigWave()
    { //Configuración inicial de la Oleada
    }

    public void StartWave()
    {// Inicio de la oleada
    }


}

public enum ResourceType {Gold, Gem, Fire, Water};

public enum GameState {Initializing, BuildingFase, WaveFighting, WaveComplete, LevelWon, LevelLost, GameInPause, GameWon };
