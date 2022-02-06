using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    DataHandler HandleData;

    private void Awake()
    {
        HandleData = new DataHandler();

        intDifficultyPower = HandleData.getDifficulty();
        RandomAccessMemory.DifficultyControl = intDifficultyPower;

        volMusic = HandleData.getVolumeMusic();
        volFX = HandleData.getVolumeSound();
        RandomAccessMemory.volumeControlMusic = volMusic;
        RandomAccessMemory.volumeControlSound = volFX;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] ToggleGroup[] GamePlayToggle;
    [SerializeField] bool SettingInited = false;
    public void SettingInit()
    {
        

        SettingInited = true;
    }

    [Header("Gameplay Controls")]
    [SerializeField] int intDifficultyPower;
    public enum Difficulties { Easy, Medium, Hard}
    public Difficulties SelectDifficulty;
    public void setDifficulty(Difficulties value)
    {
        if (SettingInited)
        {
            switch (value)
            {
                case Difficulties.Easy:
                    intDifficultyPower = 0;
                    break;
                case Difficulties.Medium:
                    intDifficultyPower = 1;
                    break;
                case Difficulties.Hard:
                    intDifficultyPower = 2;
                    break;
                default:
                    intDifficultyPower = 0;
                    break;
            }
            RandomAccessMemory.DifficultyControl = intDifficultyPower;
        }
    }
    public void setDifficulty(int value)
    {
        if (SettingInited)
        {
            switch (value)
            {
                case 0:
                    setDifficulty(Difficulties.Easy);
                    break;
                case 1:
                    setDifficulty(Difficulties.Medium);
                    break;
                case 2:
                    setDifficulty(Difficulties.Hard);
                    break;
                default:
                    setDifficulty(Difficulties.Easy);
                    break;
            }
        }
    }
    public void setTipsNTrick(bool value)
    {
        if (SettingInited)
        {
            switch (value)
            {
                case true:
                    break;
                case false:
                    break;
            }
            RandomAccessMemory.TipsNTrickControl = value;
        }
    }
    public void setTrustBarEnable(bool value)
    {
        if (SettingInited)
        {
            RandomAccessMemory.TrustBarEnable = value;
        }
    }

    
    [Header("Audio Controls")]
    // https://www.youtube.com/watch?v=YOaYQrN1oYQ Brackey Setting Menu
    public AudioMixer MainMixer;
    public float volMusic, volFX;
    public void SetVolumeMusic(float volume)
    {
        if (SettingInited)
        {
            if (MainMixer)
            {
                MainMixer.SetFloat("MusicVolume", volume);
                RandomAccessMemory.volumeControlMusic = volume;
                volMusic = volume;
            }
        }
    }

    public void SetVolumeFX(float volume)
    {
        if (SettingInited)
        {
            if (MainMixer)
            {
                MainMixer.SetFloat("SFXVolume", volume);
                RandomAccessMemory.volumeControlSound = volume;
                volFX = volume;
            }
        }
    }

    public void backToMenu() //This is apply button
    {
        HandleData.setDifficulty(intDifficultyPower);
        HandleData.setTipsNTrickEnabled(RandomAccessMemory.TrustBarEnable);
        HandleData.setVolumeMusic(volMusic);
        HandleData.setVolumeSound(volFX);
        HandleData.SaveToData();
    }
}
