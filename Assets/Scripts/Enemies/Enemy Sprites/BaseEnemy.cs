using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int currencyReward = 10; // Default base value for money per enemy
    public int CurrencyReward => currencyReward;
    public Transform waypoints;
    [HideInInspector]
    public int waypointIndex = 0;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float initialHealth = 5f;
    private float health;
    [SerializeField]
    private GameObject healthBarReference;
    [HideInInspector]

    protected virtual void Awake() {
        health = initialHealth;
    }

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
        Destroy(gameObject);
        
    }
    // Method to handle enemy death
    protected virtual void EnemyDied()
    {
        // Notify LevelManager to increase currency
        LevelManager.main.IncreaseCurrency(currencyReward); // Adjust the amount as needed
    }

    // Getters and setters

    public float GetSpeed() {
        return speed;
    }

    public void ChangeSpeed(float speed) {
        this.speed = speed;
    }

    /// <summary>
    /// Decrements health from an enemy
    /// </summary>
    /// <param name="health">hitpoints to be decreased by</param>
    public void Hit(float damage)
    {
        this.health -= damage;

        transform.GetChild(0).GetComponent<Slider>().value = this.health / this.initialHealth;

        if (this.health <= 0)
        {
            EnemyDied();
            Destroy(gameObject);
        }
    }

    public GameObject GetHealthBarReference() {
        return healthBarReference;
    }

}
