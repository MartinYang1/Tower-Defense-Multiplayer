using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour
{
    public float despawnTime = 2f;

    private bool hasCollided = false;

    void Start()
    {
        // Invoke the Despawn method after the specified despawnTime
        Invoke("Despawn", despawnTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy") && !hasCollided)
        {
            hasCollided = true;
            // Cancel the Invoke, preventing the automatic despawn
            CancelInvoke("Despawn");
            // Invoke the Despawn method immediately
            Despawn();
        }
    }

    // Method to despawn the bullet
    void Despawn()
    {
        // Destroy the bullet GameObject
        Destroy(gameObject);
    }
}
