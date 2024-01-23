using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDamage = 0f;
    public float splashRadius = 1.5f; // Adjust the splash radius as needed

    // Set the bullet damage
    public void SetBulletDamage(float damage)
    {
        bulletDamage = damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Get the enemy script
            BaseEnemy enemyScript = other.gameObject.GetComponent<BaseEnemy>();

            // Apply damage to the directly hit enemy
            enemyScript.Hit(bulletDamage);

            // Apply splash damage to nearby enemies
            ApplySplashDamage();

            // Destroy the bullet GameObject upon collision
            Destroy(gameObject);
        }
    }

    private void ApplySplashDamage()
    {
        // Find all enemies within the splash radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, splashRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Get the enemy script
                BaseEnemy enemyScript = collider.GetComponent<BaseEnemy>();

                // Apply splash damage to nearby enemies
                // You can adjust the amount of splash damage based on your requirements
                enemyScript.Hit(bulletDamage * 0.5f); // Example: Deal 50% of the bullet damage as splash damage
            }
        }
    }
}
