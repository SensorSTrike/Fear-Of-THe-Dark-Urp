using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider healthBar;
    public Image healthFill;
    public float maxHealth = 100f;
    private float currentHealth;

    public Color fullHealthColor = Color.green;
    public Color lowHealthColor = Color.red;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        healthFill.color = fullHealthColor;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        healthBar.value = currentHealth;

        float healthPercentage = currentHealth / maxHealth;

        healthFill.color = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);

        Debug.Log("Current Health: " + currentHealth);
    }
}
