using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f; // Adjust the speed as needed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the bullet prefab.");
        }
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        // Move the bullet in its forward direction
        rb.velocity = transform.right * speed;
    }

}
