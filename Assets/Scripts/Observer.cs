using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    /* ==== REFERENCES ==== */
    public Transform player; // Reference to player transform
    public GameEnding gameEnding; // Reference to game ending system

    bool m_IsPlayerInRange; // Tracks if player is inside detection range

     /* ==== PLAYER DETECTION ==== */
    void OnTriggerEnter (Collider other)
    {
        // Check if object entering trigger is player
        if (other.transform == player) 
        { 
            m_IsPlayerInRange = true; // Player entered enemy vision range
        }
    }

    void OnTriggerExit (Collider other) // Check if object leaving trigger is player
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;  // Player left enemy vision range
        }
    }

    /* ==== LINE OF SIGHT CHECK ==== */
    void Update ()
    {
        // Only check visibility if player is nearby
        if (m_IsPlayerInRange) 
        {
            Vector3 direction = player.position - transform.position + Vector3.up; // Calculate direction from enemy to player. Vector3.up slightly raises ray upward
            Ray ray = new Ray(transform.position, direction); // Create ray pointing toward player
            RaycastHit raycastHit;  // Stores raycast collision info

            // Shoot invisible ray forward
            if(Physics.Raycast(ray, out raycastHit)) 
            {
                if (raycastHit.collider.transform == player) // Check if ray directly hit player
                {
                    gameEnding.CaughtPlayer(); // Trigger game over
                }
            }
        }
    }
}
