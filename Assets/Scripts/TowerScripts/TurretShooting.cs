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

    [SerializeField]
    public float turretDamage = 10f;

    private List<Transform> enemiesInRadius = new List<Transform>();
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
        // Clear the list of enemies in the radius
        enemiesInRadius.Clear();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                enemiesInRadius.Add(collider.transform);
            }
        }

        // Sort the enemies by time alive in descending order
        enemiesInRadius.Sort((a, b) =>
        {
            float timeAliveA = GetEnemyTimeAlive(a);
            float timeAliveB = GetEnemyTimeAlive(b);

           

            return timeAliveB.CompareTo(timeAliveA);
        });

        // Set the current target to the enemy with the longest time alive
        currentTarget = (enemiesInRadius.Count > 0) ? enemiesInRadius[0] : null;

        if (currentTarget != null)
        {
        
        }
        else
        {
            Debug.Log("No enemies in radius.");
        }
    }



    private float GetEnemyTimeAlive(Transform enemyTransform)
    {
        EnemyTimeAlive enemyTimeAlive = enemyTransform.GetComponent<EnemyTimeAlive>();
        return (enemyTimeAlive != null) ? enemyTimeAlive.GetTimeAlive() : 0f;
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

            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.Euler(0f, 0f, angle));

            // Access the Bullet script (assuming you have a script named Bullet attached to the bulletPrefab)
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            // Check if the script exists before setting the damage
            if (bulletScript != null)
            {
                // Set the bullet damage based on the turret's damage
                bulletScript.SetBulletDamage(turretDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
