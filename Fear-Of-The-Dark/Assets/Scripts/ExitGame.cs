using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void QuitGame()
    {
        // Log message for debugging
        Debug.Log("Exiting Game...");

        // For editor play mode, use this line
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop playing in the editor
#else
        Application.Quit(); // Quit the application
#endif
    }
}