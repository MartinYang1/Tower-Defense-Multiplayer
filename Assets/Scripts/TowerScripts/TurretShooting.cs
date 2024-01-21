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
        CheckForEnemies();
        RotateTowardsTarget();
        UpdateShootingTimer();
        TryShoot();
    }

    private void CheckForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                currentTarget = collider.transform;
                return;
            }
        }

        currentTarget = null;
    }

    private void RotateTowardsTarget()
    {
        if (currentTarget != null)
        {
            Vector2 direction = currentTarget.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    private void UpdateShootingTimer()
    {
        shootingTimer += Time.deltaTime;
    }

    private void TryShoot()
    {
        if (shootingTimer >= shootingCooldown && currentTarget != null)
        {
            Shoot();
            shootingTimer = 0f;
        }
    }

    private void Shoot()
    {
        if (currentTarget != null)
        {
            Vector2 direction = currentTarget.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.Euler(0f, 0f, angle));
            // Adjust any bullet properties or behaviors as needed
            // For example, you might want to set the target for homing bullets.
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
