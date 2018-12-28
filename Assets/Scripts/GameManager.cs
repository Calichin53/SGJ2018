using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public AudioClip[] Music, Sounds;
    public AudioSource mMusicAudioSource, mEfectsAudioSource;
    List<int> mResources;
    int mCurrentWave, mTotalWaves, mLifes, MusicIndex;
    GameState mState;
    float tmpTime;
    public float SoundDelayTimer;
    bool IntroPlayed;

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
            //mMusicAudioSource = GetComponent<AudioSource>();
            mMusicAudioSource.clip = Music[0];
            mMusicAudioSource.volume = 0.5f;
            tmpTime = SoundDelayTimer= 0;
            IntroPlayed = false;
            ChangeMusicIndex(0);

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

    void UpdateMusic()
    {
        if (!mMusicAudioSource.isPlaying)
        {
                SetLoopMusic();
        }
    }

    void UpdateSoundEfects()
    {
        SoundDelayTimer -= Time.deltaTime;
        if (SoundDelayTimer <= 0)
        { SoundDelayTimer = Random.Range(5f, 20f);
            mEfectsAudioSource.clip = Sounds[Random.Range(0, Sounds.Length-1)];
            mEfectsAudioSource.Play();
        }
    }

    void SetIntroMusic()
    { mMusicAudioSource.clip = Music[MusicIndex * 2];
        mMusicAudioSource.loop = false;
        mMusicAudioSource.Play();
        //IntroPlayed = true;
    }
    void SetLoopMusic()
    {
        mMusicAudioSource.clip = Music[MusicIndex*2+1];
        mMusicAudioSource.loop = true;
        mMusicAudioSource.Play();
    }

    public void ChangeMusicIndex(int Indice)
    {
        MusicIndex = Indice;
        //IntroPlayed = false;
        SetIntroMusic();
    }

    // Update is called once per frame
    void Update()
    {
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
                Debug.Log("Has Ganado");
                break;
            case GameState.LevelLost:
                Debug.Log("Has Perdido");
                break;
            case GameState.GameWon:
                Debug.Log("Has Ganado");
                break;
            case GameState.GameInPause:
                Debug.Log("Has Pauseado");
                break;
            default:
                break;
        }

        UpdateMusic();
        UpdateSoundEfects();
    }

    void OnInitializing()
    {
        Waves.Clear();
        Waves.Add(new Wave());
        Waves.Add(new Wave(12, CreepType.Normal, 10));
        mTotalWaves = Waves.Count;
        mCurrentWave = 0;
        MusicIndex = 0;
        mLifes = 20;
        mState = GameState.BuildingFase;
    }

    void OnBuildingFase()
    {
        tmpTime += Time.deltaTime;
        if (Waves[CurrentWave].mDelay <= tmpTime)
        {

        }
    }

    public void Changestate(GameState Estado)
    {
        mState = Estado;
    }

    public void ChangeScene(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }

    public void PlayerGetDamaged(int Dano)
    {
        mLifes -= Dano;
        
        if (mLifes <= 0)
        {   //Has perdido ps Gil
            //Show MsgPanel
            Changestate(GameState.LevelLost);
            mLifes = 0;
        }
        Debug.Log("GM: Vida - " + mLifes);
    }
}

public enum ResourceType {YinYang, Fire, Water, Gold};

public enum GameState {Initializing, BuildingFase, WaveFighting, WaveComplete, LevelWon, LevelLost, GameInPause, GameWon };
