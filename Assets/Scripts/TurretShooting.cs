using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float shootingInterval = 2f;

    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if enough time has passed to shoot again
        if (timer >= shootingInterval)
        {

              FireBullet();
              timer = 0f;
            
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Bullet prefab must have Rigidbody2D component for shooting.");
        }
    }
}
