using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Import Unity navigation/AI system

public class WaypointPatrol : MonoBehaviour
{
    /* ==== NAVIGATION SETTINGS ==== */
    public NavMeshAgent navMeshAgent; // AI navigation agent component
    public Transform[] waypoints; // Array of patrol waypoints

    /* ==== PATROL VARIABLES ==== */
    int m_CurrentWaypointIndex; // Current waypoint index

    /* ==== INITIALIZATION ==== */
    void Start ()
    {
        navMeshAgent.SetDestination (waypoints[0].position); // Move AI toward first waypoint
    }

    /* ==== PATROL LOGIC ==== */
    void Update ()
    {
        // Check if AI reached current destination
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; // Move to next waypoint. % waypoints.Length loops back to 0. after reaching last waypoint
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position); // Set new destination waypoint
        }
    }
}
