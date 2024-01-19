using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private int currencyWorth = 50;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject upon collision
            Destroy(other.gameObject);

            // Add Currency
            LevelManager.main.IncreaseCurrency(currencyWorth);


            // Destroy the bullet GameObject as well
            Destroy(gameObject);
        }
    }
}
