using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Patrol : MonoBehaviour
{
       public Transform[] waypoints;  // Array of waypoints to walk to
    public float walkingSpeed = 2f;  // Walking speed in units per second
    public float idleTime = 5f;  // Time in seconds for the idle animation

    private Animator animator;
    private int currentWaypointIndex;
    private bool isWalking = false;
    private bool isIdle = false;
    private float idleTimer = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentWaypointIndex = 0;
        isWalking = true;
    }

    private void Update()
    {
        if (isWalking)
        {
            // Move towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, walkingSpeed * Time.deltaTime);

            // Rotate towards the current waypoint
            Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }

            // Check if reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                isWalking = false;
                isIdle = true;
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsIdle", true);
                idleTimer = 0f;
            }
        }
        else if (isIdle)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleTime)
            {
                isIdle = false;
                NextWaypoint();
            }
        }
    }

    private void NextWaypoint()
    {
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;  // Wrap around to the first waypoint
        }

        isWalking = true;
        animator.SetBool("IsWalking", true);
        animator.SetBool("IsIdle", false);
    }
}