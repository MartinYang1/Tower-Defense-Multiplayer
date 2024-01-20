using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour
{
    public float despawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the Despawn method after the specified despawnTime
        Invoke("Despawn", despawnTime);
    }

    // Method to despawn the bullet
    void Despawn()
    {
        // Destroy the bullet GameObject
        Destroy(gameObject);
    }
}

