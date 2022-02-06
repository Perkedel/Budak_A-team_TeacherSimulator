using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GameFinished : MonoBehaviour
{
    [SerializeField] private int SetStatus;
    public TextMeshProUGUI FinishTitle;
    public DataHandler handleData;
    public GameplayManager gameManager;
    public Button NextLevelButton;
    public AudioSource SpeakerSource;
    public AudioSource MusicSource;

    public AudioClip WinChickenDinner;
    public AudioClip LosChickenGarbag;
    public AudioClip QuitQuitQuit;
    public bool hasAudioPlayed = false;

    public int SetStatus1
    {
        get
        {
            return SetStatus;
        }

        set
        {
            hasAudioPlayed = false;
            RandomAccessMemory.Score = gameManager.GameScore;
            GameFinishingFunctions();
            SetStatus = value;
        }
    }

    public bool WonNewHighScore
    {
        get
        {
            return wonNewHighScore;
        }

        set
        {
            wonNewHighScore = value;
        }
    }
    private void Awake()
    {
        hasAudioPlayed = false;
        handleData = new DataHandler();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    void GameFinishingFunctions()
    {
        if (MusicSource)
        {
            MusicSource.Stop();
        }
        switch (SetStatus)
        {
            case -1:
                //if (SpeakerSource && QuitQuitQuit) SpeakerSource.PlayOneShot(QuitQuitQuit);
                NextLevelButton.gameObject.SetActive(false);
                wonNewHighScore = false;
                FinishTitle.text = "You Quit";
                break;
            case 0:
                NextLevelButton.gameObject.SetActive(true);
                //if(SpeakerSource && WinChickenDinner) SpeakerSource.PlayOneShot(WinChickenDinner);
                if (RandomAccessMemory.Score > RandomAccessMemory.HighScore)
                {
                    wonNewHighScore = true;
                    gameManager.GameHighScore = gameManager.GameScore;
                    RandomAccessMemory.Score = gameManager.GameScore;
                    RandomAccessMemory.HighScore = RandomAccessMemory.Score;
                    //RandomAccessMemory.HighScoreDay = SaatIni.Day;
                    //RandomAccessMemory.HighScoreMonth = SaatIni.Month;
                    //RandomAccessMemory.HighScoreYear = SaatIni.Year;

                    //Use RAM instead not current handle data score
                    FinishTitle.text = "You Win!\nYou get a new HighScore!";
                }
                else
                {
                    RandomAccessMemory.Score = gameManager.GameScore;
                    wonNewHighScore = false;
                    FinishTitle.text = "You Win!\n";
                }
                break;
            case 1:
                //if (SpeakerSource && LosChickenGarbag) SpeakerSource.PlayOneShot(LosChickenGarbag);
                NextLevelButton.gameObject.SetActive(false);
                wonNewHighScore = false;
                FinishTitle.text = "You Lose";
                break;
            default:
                //if (SpeakerSource && WinChickenDinner) SpeakerSource.PlayOneShot(WinChickenDinner);
                NextLevelButton.gameObject.SetActive(true);
                wonNewHighScore = false;
                FinishTitle.text = "You whatt?!";
                break;
        }
    }
    void GameFinishingFunctions(bool JustText)
    {
        if (!JustText)
        {
            GameFinishingFunctions();
        } else
        {
            if (MusicSource)
            {
                MusicSource.Stop();
            }
            switch (SetStatus)
            {
                case -1:
                    if (!hasAudioPlayed)
                    {
                        if (SpeakerSource && QuitQuitQuit) SpeakerSource.PlayOneShot(QuitQuitQuit);
                    }
                    NextLevelButton.gameObject.SetActive(false);
                    FinishTitle.text = "You Quit";
                    break;
                case 0:
                    if (!hasAudioPlayed)
                    {
                        if (SpeakerSource && QuitQuitQuit) SpeakerSource.PlayOneShot(WinChickenDinner);
                    }
                    NextLevelButton.gameObject.SetActive(true);
                    if (RandomAccessMemory.Score > RandomAccessMemory.HighScore)
                    {
                        FinishTitle.text = "You Win!\nYou get a new HighScore!";
                    }
                    else
                    {
                        FinishTitle.text = "You Win!\n";
                    }
                    break;
                case 1:
                    if (!hasAudioPlayed)
                    {
                        if (SpeakerSource && QuitQuitQuit) SpeakerSource.PlayOneShot(LosChickenGarbag);
                    }
                    NextLevelButton.gameObject.SetActive(false);
                    FinishTitle.text = "You Lose";
                    break;
                default:
                    if (!hasAudioPlayed)
                    {
                        if (SpeakerSource && QuitQuitQuit) SpeakerSource.PlayOneShot(WinChickenDinner);
                    }
                    NextLevelButton.gameObject.SetActive(true);
                    FinishTitle.text = "You whatt?!";
                    break;
            }
            hasAudioPlayed = true;
        }
    }

    [SerializeField] bool wonNewHighScore = false;
    // Update is called once per frame
    void Update()
    {
        //-1 = quited
        //0 = win
        //1 = lose
        //Moved to game Finished Function and avoided per frame update to avoid hog up.
        GameFinishingFunctions(true);
    }

    public void SaveGame()
    {
        //handleData.addPlayerCurrentScore 
        if (wonNewHighScore)
        {
            handleData.setPlayerHighScore(RandomAccessMemory.HighScore);
            handleData.setHighScoredDate();
        }
        if (SetStatus == 0)
        {
            handleData.setPlayerCurrentScore(RandomAccessMemory.Score);
        }
        handleData.setLevelNumber(gameManager.LevelNumbering);
        handleData.SaveToData();
    }
}
