using UnityEngine;

public class TowerSpriteUpdater : MonoBehaviour
{
    public Sprite[] towerSprites; // Array of tower sprites for different levels
    private SpriteRenderer towerSpriteRenderer; // Reference to the SpriteRenderer component in "TowerSprite"

    // Reference to the parent TowerLevelText script
    private TowerLevelText towerLevelText;

    private int lastUpdateCount = -1; // Track the last observed update count

    private void Start()
    {
        // Find and store the SpriteRenderer component in "TowerSprite"
        towerSpriteRenderer = GetComponent<SpriteRenderer>();

        // Find and store the parent TowerLevelText script
        towerLevelText = transform.parent.GetComponent<TowerLevelText>();

        // Ensure that towerSpriteRenderer and towerLevelText are not null
        if (towerSpriteRenderer == null || towerLevelText == null)
        {
            Debug.LogError("TowerSpriteUpdater: Missing required components.");
            enabled = false; // Disable the script to prevent errors
        }

        // Set the initial tower sprite based on the parent's update count
        UpdateTowerSprite();
    }

    private void Update()
    {
        // Check if the parent's update count has changed
        if (towerLevelText != null && lastUpdateCount != towerLevelText.GetUpdateCount())
        {
            // Update the tower sprite based on the parent's update count
            UpdateTowerSprite();
        }
    }

    private void UpdateTowerSprite()
    {
        // Update the tower sprite based on the parent's update count
        int levelThreshold = 3;
        int currentSpriteIndex = Mathf.Min(towerLevelText.GetUpdateCount() / levelThreshold, towerSprites.Length - 1);
        towerSpriteRenderer.sprite = towerSprites[currentSpriteIndex];

        // Update the last observed update count
        lastUpdateCount = towerLevelText.GetUpdateCount();
    }
}
