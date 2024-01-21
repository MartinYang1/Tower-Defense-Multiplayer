using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : BaseEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Move");
        print("HI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
