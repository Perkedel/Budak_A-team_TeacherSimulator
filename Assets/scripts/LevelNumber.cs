using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TheLevelNumberText;
    [SerializeField] int LevelNumbering = 1;

    public void setLevelNumber(int number)
    {
        LevelNumbering = number;
    }

    private void Awake()
    {
        TheLevelNumberText = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TheLevelNumberText.text = "LEVEL " + LevelNumbering;
    }
}
