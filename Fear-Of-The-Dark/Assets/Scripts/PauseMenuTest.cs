using UnityEngine;

public class PauseMenuTest : MonoBehaviour
{
    // Reference to the UI panel for the pause menu (ensure this is the panel itself, not the Canvas)
    public GameObject pauseMenuUI;

    // Boolean to track the game's pause state
    private bool isPaused = false;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause state
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Method to pause the game
    void PauseGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true); // Show the pause menu
            Time.timeScale = 0; // Freeze game time
            isPaused = true;
        }
        else
        {
            Debug.LogWarning("PauseMenuUI is not assigned in the Inspector.");
        }
    }

    // Method to resume the game
    void ResumeGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Hide the pause menu
            Time.timeScale = 1; // Resume game time
            isPaused = false;
        }
    }
}