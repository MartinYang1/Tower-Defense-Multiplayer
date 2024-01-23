using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private int currency;
    private int roundNumber = 1;

    private void Awake()
    {
        instance = this;
    }

    void OnEnable() {
        Spawner.roundOverInfo += EndRound;
    }

     void OnDisable() {
        Spawner.roundOverInfo -= EndRound;
    }

    void EndRound() {
        // do these
        roundNumber++;
        GameLogic.instance.gameUI.spawner.StartNewRound();
        IncreaseCurrency(200);

    }
    private void Start()
    {
        currency = 2000;
        GameLogic.instance.gameUI.spawner.StartNewRound();
    }
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool CanAfford(int amount)
    {
        return amount <= currency;
    }

    public void SpendCurrency(int amount)
    {
        if (CanAfford(amount))
            currency -= amount;

    }

    // Getters and setters
    public int GetCurrency() {
        return currency;
    }

}
