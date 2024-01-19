using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager main;

    public int currency;

    private void Awake(){
        main = this;
    }

    private void Start(){
        currency = 100;
    }

    public void IncreaseCurrency(int amount){
        currency += amount;
    }

    public void SpendCurrency(int amount) {
        if (amount <= currency){
            // This part to add later to buy item
            currency -= amount;
        } else {
            Debug.Log("You do not have enough to purchase this item");
            return false;
        }
    }
}