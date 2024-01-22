using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceAboveInvisible : MonoBehaviour
{
    // Reference to the invisible parent object
    public Transform invisibleObject;

    // Offset to place the object slightly above the invisible object
    public float yOffset = 1f;

    void Update()
    {
        // Place the object slightly above the invisible object
        if (invisibleObject != null)
        {
            Vector3 newPosition = invisibleObject.position + Vector3.up * yOffset;
            transform.position = newPosition;
        }
    }
}
