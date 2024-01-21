using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform waypoints;
    private int waypointIndex = 0;

    [SerializeField]
    private float speed = 5f;

    IEnumerator Move()
    {
        while (waypointIndex < waypoints.childCount) 
        {
            Transform currWaypoint = waypoints.GetChild(waypointIndex);
            waypointIndex++;
            Transform nextWaypoint = waypoints.GetChild(waypointIndex);

            float timeElapsed = 0;
            float duration = Vector2.Distance(currWaypoint.transform.position, nextWaypoint.transform.position) / speed;
            while (timeElapsed < duration)
            {
                transform.position = Vector2.Lerp(currWaypoint.transform.position, nextWaypoint.transform.position, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
        
    }

}
