using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeScene : MonoBehaviour
{
    // Name of the scene to load when Escape is pressed
    public string targetSceneName;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Ensure a valid scene name is provided
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("Target scene name is not set in the Inspector.");
            }
        }
    }
}