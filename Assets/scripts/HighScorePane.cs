using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.TextCore;
using TMPro;

public class HighScorePane : MonoBehaviour
{
    //Ambil data high score dan munculkan
    public TextMeshProUGUI TulisanHighScoreArea;
    [SerializeField] private float HighScoreNumber;
    [SerializeField] private float Level;
    [SerializeField] private string Date;
    [SerializeField] private string Timering;

    private void Awake()
    {
        //fungsi ambil data dan munculkan
    }
    // Start is called before the first frame update
    void Start()
    {
        DataHandler dh = new DataHandler();
        TulisanHighScoreArea = GetComponent<TextMeshProUGUI>();
        TulisanHighScoreArea.text = ("HighScore: " + dh.getPlayerHighScore().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
