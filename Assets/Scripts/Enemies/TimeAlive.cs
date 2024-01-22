using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimeAlive : MonoBehaviour
{
    private float timeAlive = 0f;

    private void Update()
    {
        IncrementTimeAlive(Time.deltaTime);
    }

    // Method to increment the time alive
    public void IncrementTimeAlive(float deltaTime)
    {
        timeAlive += deltaTime;
    }

    // Method to get the time alive
    public float GetTimeAlive()
    {
        return timeAlive;
    }
}
