using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndPlaceAboveInvisible : MonoBehaviour
{
    // Reference to the invisible parent object
    public Transform invisibleObject;

    // Offset to place the object slightly above the invisible object
    public float yOffset = 1f;

    private Vector3 originalInvisibleObjectPosition;

    void Start()
    {
        // Store the original position of the invisible object
        if (invisibleObject != null)
        {
            originalInvisibleObjectPosition = invisibleObject.position;
        }
    }

    void Update()
    {
        // Keep the visible object upright
        transform.rotation = Quaternion.identity;

        // Update the position of the invisible object
        if (invisibleObject != null)
        {
            invisibleObject.position = originalInvisibleObjectPosition;

            // Place the object slightly above the invisible object
            Vector3 newPosition = invisibleObject.position + Vector3.up * yOffset;
            transform.position = newPosition;
        }
    }
}

