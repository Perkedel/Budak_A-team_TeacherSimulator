using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public static class RandomAccessMemory
{
    //Kelas ini adalah kelas static. untuk menyimpan nilai variable selama proses berjalan
    // tidak perlu taruh script ini ke object manapun!
    // tinggal panggil RandomAccessMemory.Example() misalnya. bahkan bisa set variable melalui RandomAccessMemory.SampleVar = true misalnya.

    public static void Example()
    {
        //fungsi disini
    }

    public static bool SampleVar = false;

    //Tidak peduli objek hilang, ganti Scene, dsb. nilai disini akan tetap selama game ini berlangsung.
    //Jika Anda quit, maka nilai variable disini akan hilang! kembali seperti semula bila mulai game ini lagi.
    //Selamat mencoba!

    public static string PlayerName;
    public static float Score;
    public static float HighScore;
    public static int HighScoreDay;
    public static int HighScoreMonth;
    public static int HighScoreYear;
    public static Timer timering;
    public static int LevelNumber;

    public static float volumeControlMusic;
	public static float volumeControlSound;
	public static int DifficultyControl;

    public static bool TipsNTrickControl;
    

    public static bool debugIngame;

    public static bool isFirstTimePlayed = true; //untuk tutorial. jika script lain membaca ini true, maka jalankan tutorial misalkan.

    public static bool TrustBarEnable = true;

}
