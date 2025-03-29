using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;  // Початкове здоров'я героя
    public float maxHealth = 100f;  // Максимальне здоров'я героя
    public float healthRegenRate = 1f;  // Швидкість відновлення здоров'я (якщо потрібно)

    // Метод для отримання шкоди
    public void TakeDamage(float damage)
    {
        health -= damage;  // Зменшуємо здоров'я на величину шкоди
        health = Mathf.Clamp(health, 0, maxHealth);  // Переконуємось, що здоров'я не стане меншим за 0

        if (health <= 0)
        {
            Die();  // Якщо здоров'я досягло нуля, викликаємо метод смерті
        }

        // Виведення здоров'я в консоль для налагодження (можна прибрати)
        Debug.Log("Player Health: " + health);
    }

    // Метод для смерті героя
    void Die()
    {
        // Логіка смерті героя (наприклад, анімація смерті, перезапуск сцени тощо)
        Debug.Log("Player has died!");
        // Наприклад, можна відключити контролер руху або перемістити героя на екрані смерті
        // gameObject.SetActive(false);  // Вимкнення героя
        // або перезапуск сцени
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Перезапуск поточної сцени
    }
}