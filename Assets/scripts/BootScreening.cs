using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootScreening : MonoBehaviour
{
    public float setCountdown = 5f;
    [SerializeField] float Countdown = 5f;

    public GameObject FirstTimePlayMenu;
    public GameObject MainMenu;
    public SettingMenu settingMenu;
    public DataHandler HandleData;
    public string PlayerName;

    private void Awake()
    {
        HandleData = new DataHandler();
        RandomAccessMemory.PlayerName = PlayerName = HandleData.getPlayerName();
        Countdown = setCountdown;
        RandomAccessMemory.isFirstTimePlayed = FirstTimerPeople = HandleData.FirstTimePlay();

        RandomAccessMemory.HighScore = HandleData.getPlayerHighScore();
        RandomAccessMemory.HighScoreDay = HandleData.getHighScoredDay();
        RandomAccessMemory.HighScoreMonth = HandleData.getHighScoredMonth();
        RandomAccessMemory.HighScoreYear = HandleData.getHighScoredYear();

        RandomAccessMemory.DifficultyControl = HandleData.getDifficulty();
        RandomAccessMemory.TipsNTrickControl = HandleData.getTipsNTrickEnabled();
        RandomAccessMemory.TrustBarEnable = HandleData.getTrustBarEnable();


        settingMenu.SettingInit();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void FixedUpdate()
    {
        if(Countdown >= 0f) Countdown -= Time.fixedDeltaTime;
    }

    [SerializeField] bool FirstTimerPeople;
    void MoveToFirstTimeMenu() //Move to 1st time menu? if already played before, then skip to menu
    {
        if (HandleData.FirstTimePlay())
        {
            if (FirstTimePlayMenu)
            {
                FirstTimePlayMenu.SetActive(true);
            }
        } else
        {
            if (MainMenu)
            {
                MainMenu.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Countdown <= 0f)
        {
            MoveToFirstTimeMenu();
        }
        if (FirstTimePlayMenu.activeSelf || MainMenu.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }
}
