using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Adjust the speed as needed
    private Vector2 direction;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the bullet prefab.");
        }
    }
    public void SetBulletDirection(Vector2 newDirection)
    {
        direction = newDirection;

        // Calculate the rotation angle based on the direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the bullet's sprite
        transform.rotation = Quaternion.Euler(0f, 0f, angle-90);
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {

        
        // Move the bullet in the direction set by the turret
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        
    }

}