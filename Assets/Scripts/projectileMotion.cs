using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 5f;  // Speed of the projectile
    private Vector3 targetPosition;

    // Set the target position for the projectile
    public void SetTargetPosition(Vector3 target)
    {
        targetPosition = target;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        // Calculate the direction towards the target
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();

        // Move the projectile towards the target
        transform.Translate(direction * speed * Time.deltaTime);

        // Rotate the projectile to face the direction (optional)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
