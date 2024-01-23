using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public int currency;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 5000;
    }
    private void Update()
    {
        Debug.Log(currency);
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
        {
            currency -= amount;
            // Add logic here to handle the actual purchase or item acquisition
        }
        else
        {
            Debug.Log("You do not have enough to purchase this item");
        }
    }
}
