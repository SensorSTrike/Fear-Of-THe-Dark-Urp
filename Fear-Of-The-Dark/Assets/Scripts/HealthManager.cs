using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar;  // Reference to the health bar slider
    public Image healthFill;  // Reference to the Fill image inside the slider
    public float maxHealth = 100f;  // Maximum health
    private float currentHealth;

    // Colors for full health (green) and no health (red)
    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        // Set the current health to the max health at the start
        currentHealth = maxHealth;

        // Initialize the health bar values
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        // Set the health bar color to green (full health) at the start
        healthFill.color = fullHealthColor;
    }

    // Function to reduce health
    public void TakeDamage(float damageAmount)
    {
        // Reduce the current health by the damage amount
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);  // Ensure health doesn't drop below 0

        // Update the health bar slider value
        healthBar.value = currentHealth;

        // Calculate the health percentage (0 = no health, 1 = full health)
        float healthPercentage = currentHealth / maxHealth;

        // Change the color based on the health percentage
        healthFill.color = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);

        // Optional: Output current health to the console
        Debug.Log("Current Health: " + currentHealth);
    }
}
