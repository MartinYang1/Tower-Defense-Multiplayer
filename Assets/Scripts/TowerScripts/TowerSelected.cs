using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab; // Reference to your tower prefab
    public GameObject additionalObjectPrefab; // Reference to the additional object prefab

    public Vector3 spawnOffset = new Vector3(0, 0, 0); // Adjust this vector to set the spawn offset

    private bool isPlacementModeActive = false;
    private List<GameObject> placementTiles = new List<GameObject>();

    private GameObject spawnedObject; // Reference to the spawned additional object

    private void Start()
    {
        // Populate the list of placement tiles at the start of the game
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("PlacementTile");
        placementTiles.AddRange(tiles);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for simplicity
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                // Check if Tower Button is clicked
                if (hit.collider.CompareTag("TowerButton"))
                {
                    TogglePlacementMode();

                    // Spawn or respawn the additional object at the specified location
                    SpawnOrRespawnAdditionalObject();
                }
                // Check if Placement Tile is clicked
                else if (hit.collider.CompareTag("PlacementTile") && isPlacementModeActive)
                {
                    // Place tower at the clicked Placement Tile
                    PlaceTower(hit.collider.gameObject);

                    // Remove the Placement Tile from the list
                    placementTiles.Remove(hit.collider.gameObject);

                    // Destroy the Placement Tile
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void TogglePlacementMode()
    {
        isPlacementModeActive = !isPlacementModeActive;

        // Despawn the additional object if placement mode is not active
        if (!isPlacementModeActive && spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // You can add additional logic here if needed, such as changing UI to indicate placement mode
    }

    private void PlaceTower(GameObject placementTile)
    {
        // Instantiate a new tower at the position of the clicked Placement Tile
        Instantiate(towerPrefab, placementTile.transform.position, Quaternion.identity);
    }

    private void SpawnOrRespawnAdditionalObject()
    {
        // Despawn the additional object if it exists
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // Spawn a new object at the specified offset from the top right of the screen if placement mode is active
        if (isPlacementModeActive)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) + spawnOffset;
            spawnPosition.z = 0; // Ensure the object is at the correct Z position
            spawnedObject = Instantiate(additionalObjectPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
