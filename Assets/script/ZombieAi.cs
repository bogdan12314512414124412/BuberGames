using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 2f;
    public float moveSpeed = 3.5f;
    public float attackDelay = 1f;
    public float stopDistance = 1f; // Дистанція на якій зомбі зупиняється
    public float maxCloseDistance = 0.5f; // Максимальна відстань, на якій зомбі не повинні бути занадто близько до ігрока

    private NavMeshAgent agent;
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = moveSpeed;
        agent.stoppingDistance = stopDistance; // Налаштовуємо на потрібну дистанцію зупинки
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned!");
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Якщо зомбі знаходиться в межах діапазону атаки, зупиняємо його та запускаємо атаку
        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            agent.isStopped = true;  // Зупиняємо зомбі
            StartAttack();
        }
        // Якщо зомбі знаходиться за межами атаки, але не надто близько до ігрока, рухаємо його до ігрока
        else if (distanceToPlayer > attackRange && distanceToPlayer > stopDistance)
        {
            agent.isStopped = false;  // Продовжуємо рухатися до гравця
            animator.SetBool("IsWalking", true);
            agent.SetDestination(player.position);
        }
        else
        {
            // Коли зомбі достатньо близько до ігрока, зупиняємо анімацію ходьби
            animator.SetBool("IsWalking", false);
        }

        // Додаємо перевірку, чи зомбі занадто близько до ігрока
        if (distanceToPlayer < maxCloseDistance)
        {
            // Відхиляємося на маленьку відстань назад, якщо зомбі занадто близько до ігрока
            Vector3 directionAwayFromPlayer = (transform.position - player.position).normalized;
            Vector3 newPosition = transform.position + directionAwayFromPlayer * 0.5f; // Відсунути зомбі на 0.5 метра
            agent.SetDestination(newPosition); // Оновлюємо позицію зомбі
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack"); // Запускаємо анімацію атаки
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay); // Затримка після атаки
        isAttacking = false;
    }
}