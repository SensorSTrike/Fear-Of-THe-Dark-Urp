using UnityEngine;

public class GlobalClickToAnimateWithDelay : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    // Name of the trigger parameter in the Animator
    [SerializeField] private string triggerName = "OnClick";

    // Delay time in seconds between each trigger click
    [SerializeField] private float delayBetweenClicks = 2f;

    // Timer to track the delay
    private float timeSinceLastClick = 0f;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Update the timer each frame
        timeSinceLastClick += Time.deltaTime;

        // Check if the left mouse button is clicked and the delay has passed
        if (Input.GetMouseButtonDown(0) && timeSinceLastClick >= delayBetweenClicks)
        {
            // Check if the Animator and triggerName are set
            if (animator != null && !string.IsNullOrEmpty(triggerName))
            {
                // Set the trigger to start the animation
                animator.SetTrigger(triggerName);

                // Reset the timer
                timeSinceLastClick = 0f;
            }
        }
    }
}