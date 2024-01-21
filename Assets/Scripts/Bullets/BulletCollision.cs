using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBulletCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Get the enemy script
        BaseEnemy enemyScript = other.GetComponent<BaseEnemy>();

        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Notify the enemy that it has been hit
            enemyScript.EnemyDied();

            // Destroy the enemy GameObject upon collision
            Destroy(other.gameObject);

            // Destroy the bullet GameObject as well
            Destroy(gameObject);
        }
    }
}
