using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] wayPoints;
    public int curWaypoint = 0;
    public float distanceToWaypointToBeInRange = 0.1f;
    public float moveSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // vervang dit met andere movement als je dat wilt.
        transform.LookAt(wayPoints[curWaypoint].position); // vervang dit met andere rotatie als je wilt.
        if(Vector3.Distance(transform.position, wayPoints[curWaypoint].position) < distanceToWaypointToBeInRange) { 
            curWaypoint = GetNewWaypoint();
        }
    }

    int GetNewWaypoint()
    {
        int newWaypoint = curWaypoint;
        while (newWaypoint == curWaypoint)
        {
            newWaypoint = Random.Range(0, wayPoints.Length);
            print(newWaypoint);
        }
        return newWaypoint;
    }
}