using UnityEngine;

public class SidebarButton : MonoBehaviour
{
    public GameObject mySidebar;
    public float moveDistance = 200f;
    public float moveDuration = 0.5f;

    private bool isSidebarVisible = false;
    private Vector3 initialSidebarPosition;

    private void Start()
    {
        // Record the initial position of the sidebar
        initialSidebarPosition = mySidebar.transform.position;
    }

    private void OnMouseDown()
    {
        ToggleSidebar();
    }

    private void ToggleSidebar()
    {
        if (isSidebarVisible)
        {
            // If the sidebar is visible, move it off-screen
            MoveSidebarOffScreen();
        }
        else
        {
            // If the sidebar is not visible, move it onto the screen
            MoveSidebarOnScreen();
        }

        // Toggle the visibility state
        isSidebarVisible = !isSidebarVisible;
    }

    private void MoveSidebarOnScreen()
    {
        StartCoroutine(MoveSidebar(initialSidebarPosition.x + moveDistance));
    }

    private void MoveSidebarOffScreen()
    {
        StartCoroutine(MoveSidebar(initialSidebarPosition.x));
    }

    private System.Collections.IEnumerator MoveSidebar(float targetX)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = mySidebar.transform.position;

        while (elapsedTime < moveDuration)
        {
            float newX = Mathf.Lerp(startPosition.x, targetX, elapsedTime / moveDuration);
            mySidebar.transform.position = new Vector3(newX, startPosition.y, startPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly at the target
        mySidebar.transform.position = new Vector3(targetX, startPosition.y, startPosition.z);
    }
}
