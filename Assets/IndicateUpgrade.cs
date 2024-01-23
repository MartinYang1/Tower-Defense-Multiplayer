using System.Collections;
using UnityEngine;

public class TowerLevelText : MonoBehaviour
{
    public float textSize = 1.0f; // Adjustable text size
    public int upgradeCost = 50; // Sample upgrade cost

    private GameObject levelTextObject;
    private TextMesh textMesh;
    private int updateCount = 0; // Track the number of updates

    private GameObject upgradeCostObject;
    private TextMesh upgradeCostTextMesh;

    private void Start()
    {
        // Ensure the text objects are created and initialized
        CreateLevelTextObject();
        CreateUpgradeCostObject();
        ShowLevelText(0);
    }

    private void CreateLevelTextObject()
    {
        if (levelTextObject == null)
        {
            levelTextObject = new GameObject("LevelText");
            textMesh = levelTextObject.AddComponent<TextMesh>();

            // Set the filter mode to Point for pixel-like rendering
            textMesh.font.material.mainTexture.filterMode = FilterMode.Point;
            textMesh.color = Color.black;
            textMesh.anchor = TextAnchor.MiddleCenter;

            // Increase font size for clarity
            textMesh.fontSize = 100;

            // Set the position above the tower
            levelTextObject.transform.SetParent(transform); // Set the tower as the parent
            levelTextObject.transform.localPosition = Vector3.up * 2f; // Adjust the height as needed

            // Disable the text object initially
            levelTextObject.SetActive(false);
        }
    }

    private void CreateUpgradeCostObject()
    {
        if (upgradeCostObject == null)
        {
            upgradeCostObject = new GameObject("UpgradeCostText");
            upgradeCostTextMesh = upgradeCostObject.AddComponent<TextMesh>();

            // Set the filter mode to Point for pixel-like rendering
            upgradeCostTextMesh.font.material.mainTexture.filterMode = FilterMode.Point;

            upgradeCostTextMesh.anchor = TextAnchor.MiddleCenter;
            upgradeCostTextMesh.color = Color.black;
            // Increase font size for clarity
            upgradeCostTextMesh.fontSize = 50;

            // Set the position below the tower
            upgradeCostObject.transform.SetParent(transform); // Set the tower as the parent
            upgradeCostObject.transform.localPosition = Vector3.down * 1f; // Adjust the height as needed

            // Disable the text object initially
            upgradeCostObject.SetActive(false);
        }
    }

    public void ShowLevelText(float displayDuration)
    {
        // Ensure the text objects are created and initialized
        CreateLevelTextObject();
        CreateUpgradeCostObject();

        // Enable the text objects
        levelTextObject.SetActive(true);
        upgradeCostObject.SetActive(true);

        // Increment the update count
        updateCount ++;

        // Set the text to indicate the tower's update count
        textMesh.GetComponent<Renderer>().sortingLayerName = "UI";
        textMesh.GetComponent<Renderer>().sortingOrder = 1;
        textMesh.text = "LVL: " + updateCount;

        // Set the text size
        textMesh.fontSize = Mathf.RoundToInt(textSize * 1000); // Adjust the multiplier as needed
        textMesh.characterSize = 0.01f;

        // Set the upgrade cost text
        upgradeCostTextMesh.GetComponent<Renderer>().sortingLayerName = "UI";
        upgradeCostTextMesh.GetComponent<Renderer>().sortingOrder = 1;
        upgradeCostTextMesh.text = "Cost: " + upgradeCost;

        // Set the text size
        upgradeCostTextMesh.fontSize = Mathf.RoundToInt(textSize * 500); // Adjust the multiplier as needed
        upgradeCostTextMesh.characterSize = 0.01f;
    }
}
