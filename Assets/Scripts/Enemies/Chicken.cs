using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
