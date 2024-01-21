using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int currencyReward = 10; // Default base value for money per enemy
    public int CurrencyReward => currencyReward;
    public Transform waypoints;
    [HideInInspector]
    public int waypointIndex = 0;

    public float speed = 5f;

    // Moves the enemy continuously
    IEnumerator Move()
    {
        while (waypointIndex < waypoints.childCount) 
        {
            Transform currWaypoint = waypoints.GetChild(waypointIndex);
            waypointIndex++;
            Transform nextWaypoint = waypoints.GetChild(waypointIndex);

            float timeElapsed = 0;
            float duration = Vector2.Distance(currWaypoint.transform.position, nextWaypoint.transform.position) / speed;
            while (timeElapsed < duration)
            {
                transform.position = Vector2.Lerp(currWaypoint.transform.position, nextWaypoint.transform.position, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
        
    }
    // Method to handle enemy death
    protected virtual void EnemyDied()
    {
        // Notify LevelManager to increase currency
        LevelManager.main.IncreaseCurrency(currencyReward); // Adjust the amount as needed
    }

}
