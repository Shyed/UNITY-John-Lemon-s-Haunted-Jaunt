using System.Collections; // Allows use of basic collections
using System.Collections.Generic; // Allows use of generic collections
using UnityEngine; // Import Unity engine functions/classes
using UnityEngine.SceneManagement; // Allows scene loading/restarting

// GameEnding class: Handles game win/lose ending states
public class GameEnding : MonoBehaviour
{
    /* ==== ENDING SETTINGS ===== */
    public float fadeDuration = 1f; // How long fade animation lasts
    public float displayImageDuration = 1f; // How long ending screen stays visible
    public GameObject player; // Reference to player object
    public CanvasGroup exitBackgroundImageCanvasGroup; // UI fade image for successful escape ending
    public AudioSource exitAudio; // Escape ending sound
    public CanvasGroup caughtBackgroundImageCanvasGroup; // UI fade image for caught/death ending
    public AudioSource caughtAudio; // Caught ending sound
    
    /* ==== GAME STATE VARIABLES ==== */
    bool m_IsPlayerAtExit; // True when player reaches exit
    bool m_IsPlayerCaught; // True when player gets caught
    float m_Timer; // Timer used for fade effect
    bool m_HasAudioPlayed; // Prevents audio from playing repeatedly

    /* ==== EXIT DETECTION: Called when another object enters trigger ==== */
    void OnTriggerEnter(Collider other) 
    {
        // Check if trigger object is player
        if(other.gameObject == player) 
        {
            m_IsPlayerAtExit = true; // Player reached exit
        }
    }

     /* ==== PLAYER CAUGHT: Called by enemy system when player is caught ==== */
    public void CaughtPlayer()   
    {
        m_IsPlayerCaught = true; // Trigger lose state
    }

     /* ==== UPDATE LOOP: Called every frame ==== */
    void Update() 
    {
        // If player escaped
        if(m_IsPlayerAtExit)  
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio); // Run win ending
        } // If player got caught
        else if(m_IsPlayerCaught) 
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio); // Run lose ending
        }
    }

     /* ==== END LEVEL LOGIC Handles: fade effect, ending audio, restarting/quitting ==== */
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)  // Fade the Canvas Group and quit the game
    {
        // Play audio only once
        if(!m_HasAudioPlayed) 
        {
            audioSource.Play(); // Play ending sound
            m_HasAudioPlayed = false;   // would allow repeated audio playback.
        }
        m_Timer += Time.deltaTime;  // Increase timer over time
        imageCanvasGroup.alpha = m_Timer / fadeDuration; // Fade UI image in gradually

        // After fade + display duration
        if(m_Timer > fadeDuration + displayImageDuration) 
        {
            // Restart level if player lost
            if(doRestart) 
            {
                SceneManager.LoadScene(0); // Reload first scene
            } // Otherwise quit game
            else 
            {
                Application.Quit(); // Close application
            }
        }
    }
}
