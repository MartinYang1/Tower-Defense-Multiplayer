using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndShoot : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public float shootingCooldown = 2f;
    public float detectionRadius = 5f;

    private Transform currentTarget;
    private float shootingTimer = 0f;

    private void Update()
    {
        // Check for enemies in the detection radius
        CheckForEnemies();

        // Rotate towards the current target
        RotateTowardsTarget();

        // Update shooting timer
        shootingTimer += Time.deltaTime;

        // Check if it's time to shoot
        if (shootingTimer >= shootingCooldown)
        {
            // Shoot at the current target
            Shoot();
            // Reset the shooting timer
            shootingTimer = 0f;
        }
    }

    private void CheckForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Set the current target to the first detected enemy with the "Enemy" tag
                currentTarget = collider.transform;
                return; // Stop checking once an enemy is found
            }
        }

        // No enemies detected, reset the current target
        currentTarget = null;
    }

    private void RotateTowardsTarget()
    {
        if (currentTarget != null)
        {
            Vector2 direction = currentTarget.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        if (currentTarget != null)
        {
            // Calculate the direction to the target
            Vector2 direction = currentTarget.position - transform.position;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Debug.Log("Bullet Angle: " + angle);

            // Instantiate and shoot a bullet with the correct rotation
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.Euler(0f, 0f, angle));
            Debug.Log("Bullet Instantiated");

            // Adjust any bullet properties or behaviors as needed
            // For example, you might want to set the target for homing bullets.
        }
    }



    // Visualize the detection radius in the Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
