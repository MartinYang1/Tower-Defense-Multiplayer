using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTile : MonoBehaviour
{
    private static GameObject selectedTowerPrefab; // Reference to the selected tower prefab

    void Update()
    {
        // Check if the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is a PlacementTile
                if (hit.collider.CompareTag("PlacementTile"))
                {
                    // Place the selected tower at the clicked tile
                    PlaceTower(hit.collider.gameObject.transform.position);
                }
            }
        }
    }

    public static void SetSelectedTower(GameObject towerPrefab)
    {
        selectedTowerPrefab = towerPrefab;
    }

    void PlaceTower(Vector3 position)
    {
        // Check if a tower prefab is selected
        if (selectedTowerPrefab != null)
        {
            // Instantiate the selected tower at the clicked position
            Instantiate(selectedTowerPrefab, position, Quaternion.identity);
        }
    }
}
