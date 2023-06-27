using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Patrol : MonoBehaviour
{
    public Transform[] wayPoints;
    public int curWaypoint = 0;
    public float distanceToWaypointToBeInRange = 0.1f;
    public float moveSpeed = 1f;
   
    public Animator animator;
    private bool isIdle = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("IsWalking", true); // Set the bool parameter to true to trigger the walking animation.


        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); // vervang dit met andere movement als je dat wilt.
        transform.LookAt(wayPoints[curWaypoint].position); // vervang dit met andere rotatie als je wilt.
        
        if (Vector3.Distance(transform.position, wayPoints[curWaypoint].position) < distanceToWaypointToBeInRange)
        {
            curWaypoint = GetNewWaypoint();
            animator.SetBool("IsWalking", false); // Set the bool parameter to false to stop the walking animation.
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