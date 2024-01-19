using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    [SerializeField] private int currencyWorth = 50;
    public float moveSpeed = 3f;
    public float changeDirectionInterval = 2f;


    private float timer = 0f;
    private Vector3 randomDirection;

    // Update is called once per frame
    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if enough time has passed to change direction
        if (timer >= changeDirectionInterval)
        {
            // Generate a new random direction
            randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;

            // Reset the timer after changing direction
            timer = 0f;
        }

        // Move the enemy in the random direction
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        // Ensure the enemy stays within the screen boundaries
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;

        // Clamp X position
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, Camera.main.ScreenToWorldPoint(Vector3.zero).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x);

        // Clamp Y position
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, Camera.main.ScreenToWorldPoint(Vector3.zero).y, Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y);

        // Update the position
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");

        // Check if the enemy collided with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Enemy hit by a bullet");


            // Destroy the enemy and the bullet
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
            // Add Currency
            LevelManager.main.IncreaseCurrency(currencyWorth);
        }
    }

}




