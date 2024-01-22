using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletDamage = 0f;

    // Set the bullet damage
    public void SetBulletDamage(float damage)
    {
        bulletDamage = damage;
        Debug.Log("Bullet dealt" + bulletDamage + "damage");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called");

        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Get the enemy script
            BaseEnemy enemyScript = other.GetComponent<BaseEnemy>();
            Debug.Log("Bullet dealt" + bulletDamage + "damage");

            // Decrement enemy health
            if (enemyScript)
                enemyScript.Hit(bulletDamage);

            // Destroy the bullet GameObject upon collision
            Destroy(gameObject);
        }
    }
}
