using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : BaseEnemy
{
    // Adjust the currency reward for Rabbit
    [SerializeField]
    private int rabbitReward = 5;  // Example: Rabbit gives 5 currency

    // Property to access the rabbitReward
    public int RabbitReward => rabbitReward;
    private Animator anim;

    protected override void Awake() {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameLogic.instance.gameUI.spawner.transform);

        //currencyReward = rabbitReward;  // Set the base class field
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Move()
    {
        while (waypointIndex < waypoints.childCount - 1) 
        {
            Transform currWaypoint = waypoints.GetChild(waypointIndex);
            waypointIndex++;
            Transform nextWaypoint = waypoints.GetChild(waypointIndex);

            anim.SetInteger("MoveDirection", getDirection(currWaypoint, nextWaypoint));

            float timeElapsed = 0;
            float duration = Vector2.Distance(currWaypoint.transform.position, nextWaypoint.transform.position) / GetSpeed();
            while (timeElapsed < duration)
            {
                transform.position = Vector2.Lerp(currWaypoint.transform.position, nextWaypoint.transform.position, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
        Destroy(gameObject);
    }

    // Returns the direction the rabbit should move once it
    // hits a waypoint.
    int getDirection(Transform currWaypoint, Transform nextWaypoint) {
        Vector2 displacement = nextWaypoint.transform.position - currWaypoint.transform.position;
        if (Mathf.Abs(displacement.y) > Mathf.Abs(displacement.x)) {
            // verticaL direction
            return (displacement.y < 0) ? 1: 4;
        }
        else {
            // horizontal direction
            return (displacement.x < 0) ? 2: 3;
        }
    }
}
