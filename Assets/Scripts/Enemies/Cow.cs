using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : BaseEnemy
{
    // Adjust the currency reward for Cow
    [SerializeField]
    private int cowReward = 5;  // Example: Chicken gives 5 currency

    // Property to access the cowReward
    public int CowReward => cowReward;
    // Start is called before the first frame update
    void Start()
    {
        currencyReward = cowReward;  // Set the base class field
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
