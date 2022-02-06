using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePane : MonoBehaviour
{

    private TextMeshProUGUI tulisanScore;
    // Start is called before the first frame update
    void Start()
    {
        tulisanScore = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tulisanScore.text = ("Score: " + RandomAccessMemory.Score.ToString());
    }
}
