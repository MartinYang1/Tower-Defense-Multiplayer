using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;

    private void Start()
    {
        // Set initial velocity
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;

        // Destroy the bullet after a certain time
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Optional: Add logic for what happens when a bullet hits a target
        // For example, damaging an enemy, triggering an effect, etc.

        // Destroy the bullet on impact
        Destroy(gameObject);
    }
}
