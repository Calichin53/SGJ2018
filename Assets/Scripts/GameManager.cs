using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public AudioClip[] Music;
    public AudioSource mAudioSource;
    List<int> mResources;
    int mCurrentWave, mTotalWaves, mLifes;
    GameState mState;
    float tmpTime;

    public List<Wave> Waves;
    public List<Creep> CreepsInLevel;
    public MainCharacter Character;
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
            mAudioSource = GetComponent<AudioSource>();
            mAudioSource.clip = Music[0];
            mAudioSource.volume = 0.5f;
            tmpTime = 0;

            Waves = new List<Wave>();

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

    public void PauseGame()
    {
        //Pausar o Continuar el juego
    }

    public void RestartLevel()
    {
        //Reinicia el Nivel Actual
    }

    void SetLoopMusic()
    {
        mAudioSource.clip = Music[1];
        mAudioSource.Play();
        mAudioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!mAudioSource.isPlaying)
        {
            SetLoopMusic();
        }

        switch (mState)
        {
            case GameState.Initializing:
                OnInitializing();
                tmpTime = 0;
                break;
            case GameState.BuildingFase://Tiempo de retraso previo a la salida de una oleada

                break;
            case GameState.WaveFighting:
                break;
            case GameState.WaveComplete:
                //CreepFactory.NewCreepofType(CreepType.Air);
                break;
            case GameState.LevelWon:
                break;
            case GameState.LevelLost:
                break;
            case GameState.GameWon:
                break;
            case GameState.GameInPause:
                break;
            default:
                break;
        }
    }

    void OnInitializing()
    {
        Waves.Clear();
        Waves.Add(new Wave());
        Waves.Add(new Wave(12, CreepType.Normal, 10));
        mTotalWaves = Waves.Count;
        mCurrentWave = 0;
        mState = GameState.BuildingFase;
    }

    void OnBuildingFase()
    {
        tmpTime += Time.deltaTime;
        if (Waves[CurrentWave].mDelay <= tmpTime)
        {

        }
    }
}

public enum ResourceType {YinYang, Fire, Water, Gold};

public enum GameState {Initializing, BuildingFase, WaveFighting, WaveComplete, LevelWon, LevelLost, GameInPause, GameWon };
