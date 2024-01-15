using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;  // Speed of the enemy

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Move the enemy forward
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy has collided with a bullet
        if (other.CompareTag("Bullet"))
        {
            // Optional: Add logic for what happens when an enemy is hit by a bullet
            // For example, reducing health, triggering an effect, etc.

            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}

