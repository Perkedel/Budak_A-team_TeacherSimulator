using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameTextScript : MonoBehaviour
{
    public DataHandler HandleData;
    public MainMenuManager rootCanvas;
    public TextMeshProUGUI textName;
    public string AName;
    private void Awake()
    {
        HandleData = new DataHandler();
        AName = HandleData.getPlayerName();
        if(textName) textName.text = "Hello, " + rootCanvas.YourName;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (textName) textName.text = "Hello, " + rootCanvas.YourName;
    }

    // Update is called once per frame
    void Update()
    {
        AName = HandleData.getPlayerName();
        if (textName) textName.text = "Hello, " + rootCanvas.YourName;
    }
}
