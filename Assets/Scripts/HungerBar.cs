using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider easeHungerSlider;

    public HealthBar healthBar;  // Referencja do HealthBar

    public float maxHunger = 100f;
    public float hunger;
    private float lerpSpeed = 0.05f;
    private float hungerDecayRate = 0.01f;  // Rate at which hunger decreases per second

    void Start()
    {
        hunger = maxHunger;
        InvokeRepeating("DecreaseHungerOverTime", 2f, 2f);  // Start decreasing hunger after 1 second, repeatedly every second
    }

    void Update()
    {
        if (hungerSlider.value != hunger)
        {
            hungerSlider.value = Mathf.Max(hunger, 0);
        }

        if (hungerSlider.value != easeHungerSlider.value)
        {
            easeHungerSlider.value = Mathf.Lerp(easeHungerSlider.value, hunger, lerpSpeed);
        }

        // Regeneracja zdrowia, jeœli poziom g³odu jest wy¿szy ni¿ 70
        if (hunger > 70 && healthBar != null)
        {
            healthBar.health = Mathf.Min(healthBar.maxHealth, healthBar.health + 1 * Time.deltaTime);
        }
    }

    // Called every second
    void DecreaseHungerOverTime()
    {
        DecreaseHunger(hungerDecayRate);
    }

    public void DecreaseHunger(float amount)
    {
        hunger = Mathf.Max(hunger - amount, 0);
    }
}