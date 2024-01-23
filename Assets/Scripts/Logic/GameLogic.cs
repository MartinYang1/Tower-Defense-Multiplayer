using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class <c>GameLogic</c> manages all the in-game logic behind the scenes.
/// </summary>
public class GameLogic : MonoBehaviour
{
    public static GameLogic instance;

    [HideInInspector]
    public GameUI gameUI;
    public LevelManager levelManager;

    public int numLives = 100;
    public bool gameOver;

    void Awake() {
        if (!instance)
            instance = this;
        gameUI = GameObject.FindObjectOfType<GameUI>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void Update() {
        if (IsGameOver()) {
            gameOver = true;
        }
    }

    bool IsGameOver() {
        return numLives == 0;
    }
    
}
