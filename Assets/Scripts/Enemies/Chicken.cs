using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : BaseEnemy
{
    // Adjust the currency reward for Chicken
    [SerializeField]
    private int chickenReward = 5;  // Example: Chicken gives 5 currency

    // Property to access the chickenReward
    public int ChickenReward => chickenReward;
    // Start is called before the first frame update
    void Start()
    {
        currencyReward = chickenReward;  // Set the base class field
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
