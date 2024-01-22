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
    
}
