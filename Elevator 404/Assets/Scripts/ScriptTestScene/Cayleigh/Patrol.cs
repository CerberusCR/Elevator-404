using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] wayPoints;
    public int curWaypoint = 0;
    public float distanceToWaypointToBeInRange = 0.1f;
    public Animator animatorIdleOrRolling;
    public float moveSpeed = 3f;
    
    private bool holding = false;
    private bool AnimationStarted = false;

    // Update is called once per frame
    void Update()
    {
        // hou de wacht, blijf even stil staan
        if (!holding)
        { 
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // vervang dit met andere movement als je dat wilt.
        }

        // kijk alvast in de richting van het vogende waypoint
        transform.LookAt(wayPoints[curWaypoint].position); // vervang dit met andere rotatie als je wilt.

        // controleer of we in de buurt van het volgende waypoint zijn
        if (Vector3.Distance(transform.position, wayPoints[curWaypoint].position) < distanceToWaypointToBeInRange)
        {
            // blijf even de wacht houden
            holding = true;

            // pak alvast het volgende punt
            curWaypoint = GetNewWaypoint();

            // als de idle animatie nog niet is gestart
            if(AnimationStarted == false)
            {
                // dan starten we de idle animation
                AnimationStarted = true;
                Invoke("startAnimation", 0.0f);
            }
 
        }
    }

    private void startAnimation()
    {
        animatorIdleOrRolling.SetBool("IsIdle", true);
        animatorIdleOrRolling.SetBool("IsWalking", false);
        // we wachten voor 5 seconden voordat we weer gaan rollen
        Invoke("startRollingAgain", 5.0f);
    }

    private void startRollingAgain()
    {
        holding = false;
        animatorIdleOrRolling.SetBool("IsIdle", false);
        animatorIdleOrRolling.SetBool("IsWalking", true);
        AnimationStarted = false;
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