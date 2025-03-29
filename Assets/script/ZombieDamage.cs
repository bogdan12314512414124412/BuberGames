using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    public Transform player;  // Посилання на гравця
    public float damageAmount = 10f;  // Кількість шкоди, яку наносить зомбі
    public float damageInterval = 1f;  // Інтервал між нанесенням шкоди (в секундах)
    public float attackRadius = 2f;  // Радіус, в якому зомбі може завдавати шкоди

    private float lastDamageTime = 0f;  // Час останнього нанесення шкоди

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }

        // Вираховуємо відстань між зомбі та гравцем
         float distanceToPlayer = Vector3.Distance(transform.position, player.position);

       
       

         // Перевірка, чи зомбі знаходиться в межах радіусу атаки і чи настав час для нанесення шкоди
        if (distanceToPlayer <= attackRadius && Time.time - lastDamageTime >= damageInterval)
        {
            ApplyDamage();  // Наносимо шкоду
            lastDamageTime = Time.time;  // Оновлюємо час останнього нанесення шкоди
        }
    }

    void ApplyDamage()
    {
        // Отримуємо компонент PlayerHealth на об'єкті гравця
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            Debug.Log("Zombie is dealing damage to the player.");
            playerHealth.TakeDamage(damageAmount);  // Наносимо шкоду гравцю
        }
        else
        {
            Debug.LogWarning("PlayerHealth component not found on the player.");
        }
    }
}