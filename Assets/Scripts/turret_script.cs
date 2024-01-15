using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform firePoint;     // Point where bullets are spawned
    public LayerMask targetLayer;   // Layer of the objects to be considered as targets
    public float rotationSpeed = 5f;
    public float fireRate = 1f;     // Bullets fired per second
    public GameObject bulletPrefab; // Add this line to reference the bullet prefab

    private void Start()
    {
        InvokeRepeating("FireBullet", 0f, 1f / fireRate);
    }

    private void Update()
    {
        AimAtTarget();
    }

    private void AimAtTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, /* Turret's detection range */, targetLayer);

        if (targets.Length > 0)
        {
            Transform target = targets[0].transform;

            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void FireBullet()
    {
        // Instantiate bullet prefab at the firePoint position and rotation
        // Make sure you have a bullet prefab assigned in the Unity Editor
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }
}


