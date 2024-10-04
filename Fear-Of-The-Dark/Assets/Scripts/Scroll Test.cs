using UnityEngine;

public class ScrollAnimatorParameter : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string parameterName = "parameter"; // The name of the parameter to change
    private int currentValue = 1; // Initial value of the parameter
    private float scrollCooldown = 1.0f; // Cooldown time between changes in seconds
    private float lastScrollTime; // To keep track of the last time the scroll input was registered

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Try to get Animator component attached to the same GameObject
        }

        animator.SetInteger(parameterName, currentValue); // Set initial value
        lastScrollTime = -scrollCooldown; // Ensures the first scroll is immediately allowed
    }

    void Update()
    {
        // Check for mouse wheel scroll input and enforce cooldown
        if (Time.time - lastScrollTime >= scrollCooldown)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll > 0f)
            {
                // Scrolling up, increase the parameter
                currentValue++;
                if (currentValue > 4)
                {
                    currentValue = 1; // Wrap back to 1 if going beyond 4
                }
                lastScrollTime = Time.time; // Reset the cooldown timer
            }
            else if (scroll < 0f)
            {
                // Scrolling down, decrease the parameter
                currentValue--;
                if (currentValue < 1)
                {
                    currentValue = 4; // Wrap back to 4 if going below 1
                }
                lastScrollTime = Time.time; // Reset the cooldown timer
            }

            // Update the Animator parameter
            animator.SetInteger(parameterName, currentValue);
        }
    }
}