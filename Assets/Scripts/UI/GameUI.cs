using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
/// Class <c>GameUI</c> controls most of the features relating to UI.
/// This is attached to the Background gameobject.
/// This class holds all the references to important gameobjects.
/// </summary>
public class GameUI : MonoBehaviour
{
    public Spawner spawner;
    public Canvas canvas;

    [SerializeField]
    private TextMeshProUGUI livesText, roundText, currencyText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "Currency: " +
        GameLogic.instance.levelManager.GetCurrency().ToString();  
        roundText.text = "Round: " +
        GameLogic.instance.levelManager.GetRound().ToString();   
        livesText.text = GameLogic.instance.numLives.ToString();    
    }
}
