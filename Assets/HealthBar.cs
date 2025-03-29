using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;  // Посилання на PlayerHealth
    public Image healthBarFill;  // Змінна для зеленого Image (заповнююча частина полоски)

    void Start()
    {
        // Знайдемо PlayerHealth, якщо він ще не був вказаний в редакторі
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        // Знайдемо Image заповнення полоски здоров'я, якщо не вказано в редакторі
        if (healthBarFill == null)
        {
            healthBarFill = GetComponentInChildren<Image>();
        }
    }

    void Update()
    {
        // Оновлюємо fillAmount для полоски здоров'я відповідно до поточного здоров'я
        if (playerHealth != null && healthBarFill != null)
        {
            healthBarFill.fillAmount = playerHealth.health / playerHealth.maxHealth;  // Нормалізуємо значення
        }
    }
}