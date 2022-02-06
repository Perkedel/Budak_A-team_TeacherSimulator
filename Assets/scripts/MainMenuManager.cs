using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //Do not disable. put on root Canvas gameobject
    public DataHandler HandleData;
    [SerializeField] float CurrentScore;
    [SerializeField] float HighScore;
    public string YourName;
    void StartApplication()
    {
        HandleData = new DataHandler();
        RandomAccessMemory.isFirstTimePlayed = HandleData.FirstTimePlay();

        RandomAccessMemory.Score = CurrentScore = HandleData.getPlayerCurrentScoreFromDisk();
        RandomAccessMemory.HighScore = HighScore = HandleData.getPlayerHighScore();

        RandomAccessMemory.PlayerName = YourName = HandleData.getPlayerName();

        RandomAccessMemory.HighScoreDay = HandleData.getHighScoredDay();
        RandomAccessMemory.HighScoreMonth = HandleData.getHighScoredMonth();
        RandomAccessMemory.HighScoreYear = HandleData.getHighScoredYear();
    }
    private void Awake()
    {
        StartApplication();
    }

    public void debugDeleteFirstTimePlay()
    {
        HandleData.deleteFirstTimePlay();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setName(string txt)
    {
        if(txt == "")
        {
            txt = "[REDACTED]";
        }
        YourName = txt;
        RandomAccessMemory.PlayerName = YourName;
        HandleData.setPlayerName(YourName);
    }

    public InputField FirstTimeNameInput;
    public void ConfirmName()
    {
        if(YourName != FirstTimeNameInput.text)
        {
            if(FirstTimeNameInput) YourName = FirstTimeNameInput.text;
        } else
        {
        }
        RandomAccessMemory.PlayerName = YourName;
        HandleData.setPlayerName(YourName);
        HandleData.setFirstTimePlay(false);
        HandleData.SaveToData();
    }

    public string getName()
    {
        RandomAccessMemory.PlayerName = HandleData.getPlayerName();
        return RandomAccessMemory.PlayerName;
    }

    public void viewHighScore()
    {

    }

    void Update()
    {
        
    }

    public void exitGame()
    {
        HandleData.SaveToData();
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
