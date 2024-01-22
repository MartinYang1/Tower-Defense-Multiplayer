using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public int towerIndex;
    public TowerPlacement towerPlacement;

    private void OnMouseDown()
    {
        if (towerPlacement != null)
        {
            towerPlacement.SelectTower(towerIndex);
            Debug.Log("TowerButton Clicked. Selected Tower Index: " + towerIndex);
        }
        else
        {
            Debug.LogWarning("TowerPlacement script is not assigned!");
        }
    }
}
