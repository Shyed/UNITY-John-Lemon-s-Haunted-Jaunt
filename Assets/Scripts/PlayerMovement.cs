using System.Collections;
using System.Collections.Generic;
using UnityEngine; // for MonoBehaviour

public class PlayerMovement : MonoBehaviour
{
    /* ==== MOVEMENT SETTINGS ==== */
    public float turnSpeed = 20f;  // Rotation speed for turning player

    /* ==== COMPONENT REFERENCES ==== */
    Animator m_Animator;  // Controls animations
    Rigidbody m_Rigidbody; // Controls physics movement
    AudioSource m_AudioSource; // Controls walking sound effects

    /* ==== MOVEMENT VARIABLES ==== */
    Vector3 m_Movement;  // Stores movement direction
    Quaternion m_Rotation = Quaternion.identity;  // Stores player rotation

    /* ==== INITIALIZATION: Called automatically when game starts ==== */
    void Start()
    {
        m_Animator = GetComponent<Animator>(); // Get Animator component attached to player
        m_Rigidbody = GetComponent<Rigidbody>(); // Get Rigidbody component
        m_AudioSource = GetComponent<AudioSource>(); // Get AudioSource component
    }

    /* ==== PLAYER INPUT: Called at fixed intervals. Used for physics movement ==== */
    void FixedUpdate()  
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get left/right keyboard input
        float vertical = Input.GetAxis("Vertical"); // Get forward/backward keyboard input

        /* ==== MOVEMENT VECTOR ==== */
        m_Movement.Set(horizontal, 0f, vertical); // Create movement direction vector
        m_Movement.Normalize(); // Normalize movement: Prevents diagonal movement from becoming faster
        
        /* ==== INPUT CHECKING ==== */
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f); // Check if player is pressing horizontal keys
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f); // Check if player is pressing vertical keys
        bool isWalking = hasHorizontalInput || hasVerticalInput; // Player walking if either input exists
        
        /* ==== ANIMATION ==== */
        m_Animator.SetBool("IsWalking", isWalking);  // Update Animator walking state

        /* ==== FOOTSTEP AUDIO ==== */
        if(isWalking)
        {
            // Only play walking sound if not already playing
            if(!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop(); // Stop walking audio when player stops
        }

        /* ==== PLAYER ROTATION ==== */
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward); // Smoothly rotate player toward movement direction
    }

    /* ==== APPLY MOVEMENT: Called by Animator after animation updates ==== */
    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude); // Move player using Rigidbody
        m_Rigidbody.MoveRotation(m_Rotation); // Apply player rotation
    }
}

/* ==== MOVEMENT SYSTEM OVERVIEW ==== */
// 1. Get player keyboard input
// 2. Create movement direction vector
// 3. Normalize movement speed
// 4. Detect if player is walking
// 5. Trigger walking animation
// 6. Play/stop footstep audio
// 7. Rotate player toward movement direction
// 8. Apply movement and rotation using Rigidbody
